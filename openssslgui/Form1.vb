Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports OpenSSL.Crypto
Imports System.Text
Public Class frmMain
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDecodeIn.AllowDrop = True
        txtNodesIn.AllowDrop = True
        lblStatusBar.Text = "Version " + Application.ProductVersion + " - " + Application.CompanyName
    End Sub

    Private Sub txtDecodeIn_DragDrop(sender As Object, e As DragEventArgs) Handles txtDecodeIn.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

        If files.Count = 1 Then
            Dim infile = files.GetValue(0)
            If infile.EndsWith(".crt") Or infile.EndsWith(".csr") Or infile.EndsWith(".cer") Or infile.EndsWith(".pem") Then
                txtDecodeOut.Text = ""
                txtDecodeIn.Text = File.ReadAllText(infile).Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                Decode()
            End If
        End If
    End Sub

    Private Sub txtDecodeIn_DragEnter(sender As Object, e As DragEventArgs) Handles txtDecodeIn.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Decode()
        txtDecodeOut.Text = ""
        Try
            File.WriteAllText(Path.GetTempPath() + "opensslgui-in.txt", txtDecodeIn.Text)

            'Good, by I prefer to use the OpenSSL.net library only
            'Dim Cert As X509Certificate2 = New X509Certificate2(X509Certificate.CreateFromCertFile(Path.GetTempPath() + "opensslgui-in.txt"))
            'Dim SN = String.Join(":", Cert.GetSerialNumberString().Select(Function(x, n) New With {x, n}).GroupBy(Function(x) x.n \ 2, Function(x) x.x).Select(Function(y) New String(y.ToArray())))
            'txtDecodeOut.Text += "Name: " + Cert.Subject + vbNewLine
            'txtDecodeOut.Text += "Issuer: " + Cert.Issuer + vbNewLine
            'txtDecodeOut.Text += "Serial Number: " + SN + vbNewLine
            'txtDecodeOut.Text += "Valid From: " + Cert.GetEffectiveDateString + vbNewLine
            'txtDecodeOut.Text += "Valid To: " + Cert.GetExpirationDateString + vbNewLine
            'For Each extension As X509Extension In Cert.Extensions
            '    If extension.Oid.FriendlyName.ToString = "Subject Alternative Name" Then
            '        txtDecodeOut.Text += "== SAN ==" + vbNewLine
            '        txtDecodeOut.Text += extension.Format(True)
            '    End If
            'Next

            If txtDecodeIn.Text.Contains("BEGIN NEW CERTIFICATE REQUEST") Then
                Dim Req = New OpenSSL.X509.X509Request(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"))
                txtDecodeOut.Text += "Name: " + Req.Subject.Common.ToString + vbNewLine

            Else
                Dim MSCert As X509Certificate2 = New X509Certificate2(X509Certificate.CreateFromCertFile(Path.GetTempPath() + "opensslgui-in.txt"))
                Dim SN = String.Join(":", MSCert.GetSerialNumberString().Select(Function(x, n) New With {x, n}).GroupBy(Function(x) x.n \ 2, Function(x) x.x).Select(Function(y) New String(y.ToArray())))
                Dim Cert = New OpenSSL.X509.X509Certificate(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"))
                txtDecodeOut.Text += "Name: " + Cert.Subject.Common.ToString + vbNewLine
                txtDecodeOut.Text += "Issuer: " + Cert.Issuer.OneLine + vbNewLine
                txtDecodeOut.Text += "Serial Number: " & SN & vbNewLine
                txtDecodeOut.Text += "Valid From: " + Cert.NotBefore.ToShortDateString + vbNewLine
                txtDecodeOut.Text += "Valid To: " + Cert.NotAfter.ToShortDateString + vbNewLine
                For Each extension In Cert.Extensions
                    If extension.Name = "X509v3 Subject Alternative Name" Then
                        txtDecodeOut.Text += "== SAN ==" + vbNewLine
                        txtDecodeOut.Text += extension.ToString.Replace(",", vbNewLine).Replace(" ", "")
                    End If
                Next
            End If
            'Dim Cert = New OpenSSL.X509.X509Request(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"));


        Catch ex As Exception
            txtDecodeOut.Text = "[invalid element]" + vbNewLine
            txtDecodeOut.Text += ex.Message
        End Try
    End Sub
    Private Function PasswordHandler(verify As Boolean, userdata As Object) As String
        Return txtNodesPass.Text
    End Function
    Private Sub DecodeNodes()
        txtNodesOut.Text = ""
        File.WriteAllText(Path.GetTempPath() + "opensslgui-in.txt", txtNodesIn.Text)
        'Dim rsacontext = OpenSSL.Crypto.RSA.FromPrivateKey(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"), "text", Nothing)
        Try
            Dim rsacontext = OpenSSL.Crypto.RSA.FromPrivateKey(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"))
            txtNodesOut.Text = rsacontext.PrivateKeyAsPEM.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
        Catch ex As Exception
            Try
                Dim rsacontext = OpenSSL.Crypto.RSA.FromPrivateKey(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"), AddressOf PasswordHandler, Nothing)
                txtNodesOut.Text += rsacontext.PrivateKeyAsPEM.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            Catch ex2 As Exception
                txtNodesOut.Text += "[invalid element or wrong password]" + vbNewLine
                txtNodesOut.Text += ex2.Message
            End Try
        End Try
    End Sub
    Private Sub txtNodesIn_TextChanged(sender As Object, e As EventArgs) Handles txtNodesIn.TextChanged
        DecodeNodes()
    End Sub
    Private Sub txtNodesIn_DragDrop(sender As Object, e As DragEventArgs) Handles txtNodesIn.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

        If files.Count = 1 Then
            Dim infile = files.GetValue(0)
            If infile.EndsWith(".key") Or infile.EndsWith(".pem") Then
                txtNodesOut.Text = ""
                txtNodesIn.Text = File.ReadAllText(infile).Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                DecodeNodes()
            End If
        End If
    End Sub

    Private Sub txtNodesIn_DragEnter(sender As Object, e As DragEventArgs) Handles txtNodesIn.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub txtNodesPass_TextChanged(sender As Object, e As EventArgs) Handles txtNodesPass.TextChanged
        DecodeNodes()
    End Sub

    Private Sub txtDecodeIn_TextChanged(sender As Object, e As EventArgs) Handles txtDecodeIn.TextChanged
        Decode()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
