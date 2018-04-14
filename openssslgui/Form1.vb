Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports OpenSSL.Crypto
Imports System.Text
Public Class frmMain
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDecodeIn.AllowDrop = True
        txtNodesIn.AllowDrop = True
        lblStatusBar.Text = "Version " + Application.ProductVersion
    End Sub

    Private Sub txtDecodeIn_DragDrop(sender As Object, e As DragEventArgs) Handles txtDecodeIn.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

        If files.Count = 1 Then
            Dim infile = files.GetValue(0)
            If infile.EndsWith(".crt") Or infile.EndsWith(".pem") Then
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
            Dim Cert As X509Certificate2 = New X509Certificate2(X509Certificate.CreateFromCertFile(Path.GetTempPath() + "opensslgui-in.txt"))

            Dim SN = String.Join(":", Cert.GetSerialNumberString().Select(Function(x, n) New With {x, n}).GroupBy(Function(x) x.n \ 2, Function(x) x.x).Select(Function(y) New String(y.ToArray())))
            txtDecodeOut.Text += "Name: " + Cert.Subject + vbNewLine
            'txtDecodeOut.Text += "SAN: " +
            txtDecodeOut.Text += "Issuer: " + Cert.Issuer + vbNewLine
            txtDecodeOut.Text += "Serial Number: " + SN + vbNewLine
            txtDecodeOut.Text += "Valid From: " + Cert.GetEffectiveDateString + vbNewLine
            txtDecodeOut.Text += "Valid To: " + Cert.GetExpirationDateString + vbNewLine
            For Each extension As X509Extension In Cert.Extensions
                If extension.Oid.FriendlyName.ToString = "Subject Alternative Name" Then
                    txtDecodeOut.Text += "== SAN ==" + vbNewLine
                    txtDecodeOut.Text += extension.Format(True)
                End If
            Next
        Catch ex As Exception
            txtDecodeOut.Text = "[invalid element]"
        End Try
    End Sub
    Private Function PasswordHandler(verify As Boolean, userdata As Object) As String
        Return txtNodesPass.Text
    End Function
    Private Sub DecodeNodes()
        File.WriteAllText(Path.GetTempPath() + "opensslgui-in.txt", txtNodesIn.Text)
        'Dim rsacontext = OpenSSL.Crypto.RSA.FromPrivateKey(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"), "text", Nothing)
        Try
            Dim rsacontext = OpenSSL.Crypto.RSA.FromPrivateKey(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"))
            txtNodesOut.Text += rsacontext.PrivateKeyAsPEM.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
        Catch ex As Exception
            Try
                Dim rsacontext = OpenSSL.Crypto.RSA.FromPrivateKey(OpenSSL.Core.BIO.File(Path.GetTempPath() + "opensslgui-in.txt", "r"), AddressOf PasswordHandler, Nothing)
                txtNodesOut.Text = rsacontext.PrivateKeyAsPEM.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            Catch ex2 As Exception
                txtNodesOut.Text = "[invalid content]"
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
End Class
