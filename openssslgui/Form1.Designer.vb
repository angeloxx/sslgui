<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDecodeIn = New System.Windows.Forms.TextBox()
        Me.txtDecodeOut = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNodesPassword = New System.Windows.Forms.Label()
        Me.txtNodesPass = New System.Windows.Forms.TextBox()
        Me.txtNodesIn = New System.Windows.Forms.TextBox()
        Me.txtNodesOut = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(702, 444)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDecodeIn)
        Me.TabPage1.Controls.Add(Me.txtDecodeOut)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(694, 418)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DecodeX509"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 30)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Input" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(CRT/CSR)"
        '
        'txtDecodeIn
        '
        Me.txtDecodeIn.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDecodeIn.Location = New System.Drawing.Point(75, 6)
        Me.txtDecodeIn.Multiline = True
        Me.txtDecodeIn.Name = "txtDecodeIn"
        Me.txtDecodeIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDecodeIn.Size = New System.Drawing.Size(613, 129)
        Me.txtDecodeIn.TabIndex = 1
        '
        'txtDecodeOut
        '
        Me.txtDecodeOut.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDecodeOut.Location = New System.Drawing.Point(6, 141)
        Me.txtDecodeOut.Multiline = True
        Me.txtDecodeOut.Name = "txtDecodeOut"
        Me.txtDecodeOut.ReadOnly = True
        Me.txtDecodeOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDecodeOut.Size = New System.Drawing.Size(682, 271)
        Me.txtDecodeOut.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.lblNodesPassword)
        Me.TabPage2.Controls.Add(Me.txtNodesPass)
        Me.TabPage2.Controls.Add(Me.txtNodesIn)
        Me.TabPage2.Controls.Add(Me.txtNodesOut)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(694, 418)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "NoDES"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 30)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Input" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Key)"
        '
        'lblNodesPassword
        '
        Me.lblNodesPassword.AutoSize = True
        Me.lblNodesPassword.Location = New System.Drawing.Point(6, 112)
        Me.lblNodesPassword.Name = "lblNodesPassword"
        Me.lblNodesPassword.Size = New System.Drawing.Size(61, 15)
        Me.lblNodesPassword.TabIndex = 5
        Me.lblNodesPassword.Text = "Password"
        '
        'txtNodesPass
        '
        Me.txtNodesPass.Location = New System.Drawing.Point(75, 109)
        Me.txtNodesPass.Name = "txtNodesPass"
        Me.txtNodesPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNodesPass.Size = New System.Drawing.Size(613, 20)
        Me.txtNodesPass.TabIndex = 4
        '
        'txtNodesIn
        '
        Me.txtNodesIn.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNodesIn.Location = New System.Drawing.Point(75, 6)
        Me.txtNodesIn.Multiline = True
        Me.txtNodesIn.Name = "txtNodesIn"
        Me.txtNodesIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNodesIn.Size = New System.Drawing.Size(613, 93)
        Me.txtNodesIn.TabIndex = 3
        '
        'txtNodesOut
        '
        Me.txtNodesOut.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNodesOut.Location = New System.Drawing.Point(6, 140)
        Me.txtNodesOut.Multiline = True
        Me.txtNodesOut.Name = "txtNodesOut"
        Me.txtNodesOut.ReadOnly = True
        Me.txtNodesOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNodesOut.Size = New System.Drawing.Size(682, 272)
        Me.txtNodesOut.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 459)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(726, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(0, 17)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 481)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SSLGui"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtDecodeIn As TextBox
    Friend WithEvents txtDecodeOut As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatusBar As ToolStripStatusLabel
    Friend WithEvents txtNodesIn As TextBox
    Friend WithEvents txtNodesOut As TextBox
    Friend WithEvents txtNodesPass As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNodesPassword As Label
End Class
