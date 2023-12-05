<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnResults = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.btnPrivacy = New System.Windows.Forms.Button()
        Me.btnProtection = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CtlHome1 = New Anti_Virus_Project.CtlHome()
        Me.CtlProtection1 = New Anti_Virus_Project.CtlProtection()
        Me.CtlPrivacy1 = New Anti_Virus_Project.CtlPrivacy()
        Me.Virus_Cheast1 = New Anti_Virus_Project.Virus_Cheast()
        Me.Update_software1 = New Anti_Virus_Project.update_software()
        Me.Settings1 = New Anti_Virus_Project.Settings()
        Me.CtlScan1 = New Anti_Virus_Project.ctlScan()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1402, 62)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1272, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 31)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(36, 28)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(22, 23)
        Me.Panel5.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel4.Location = New System.Drawing.Point(20, 15)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(22, 23)
        Me.Panel4.TabIndex = 0
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.Control
        Me.Button6.Location = New System.Drawing.Point(1310, 12)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 35)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "_"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(1354, 12)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(40, 35)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "X"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Anti_Virus_Project.My.Resources.Resources.icons8_notification_48px
        Me.PictureBox3.Location = New System.Drawing.Point(1236, 12)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(38, 38)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(161, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Free Antivirus"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(63, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MAYM"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnResults)
        Me.Panel2.Controls.Add(Me.btnStatus)
        Me.Panel2.Controls.Add(Me.btnPrivacy)
        Me.Panel2.Controls.Add(Me.btnProtection)
        Me.Panel2.Controls.Add(Me.btnHome)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 62)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(130, 870)
        Me.Panel2.TabIndex = 1
        '
        'btnResults
        '
        Me.btnResults.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResults.ForeColor = System.Drawing.Color.White
        Me.btnResults.Image = Global.Anti_Virus_Project.My.Resources.Resources.icons8_virus_research_45px
        Me.btnResults.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnResults.Location = New System.Drawing.Point(4, 446)
        Me.btnResults.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnResults.Name = "btnResults"
        Me.btnResults.Size = New System.Drawing.Size(123, 108)
        Me.btnResults.TabIndex = 19
        Me.btnResults.Text = "Results"
        Me.btnResults.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnResults.UseVisualStyleBackColor = False
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatus.ForeColor = System.Drawing.Color.White
        Me.btnStatus.Image = Global.Anti_Virus_Project.My.Resources.Resources.icons8_dashboard_45px
        Me.btnStatus.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStatus.Location = New System.Drawing.Point(3, 335)
        Me.btnStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(123, 108)
        Me.btnStatus.TabIndex = 6
        Me.btnStatus.Text = "Manager"
        Me.btnStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'btnPrivacy
        '
        Me.btnPrivacy.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnPrivacy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrivacy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrivacy.ForeColor = System.Drawing.Color.White
        Me.btnPrivacy.Image = Global.Anti_Virus_Project.My.Resources.Resources.icons8_fingerprint_45px
        Me.btnPrivacy.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrivacy.Location = New System.Drawing.Point(3, 225)
        Me.btnPrivacy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPrivacy.Name = "btnPrivacy"
        Me.btnPrivacy.Size = New System.Drawing.Size(123, 108)
        Me.btnPrivacy.TabIndex = 5
        Me.btnPrivacy.Text = "Privacy"
        Me.btnPrivacy.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrivacy.UseVisualStyleBackColor = False
        '
        'btnProtection
        '
        Me.btnProtection.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnProtection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProtection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProtection.ForeColor = System.Drawing.Color.White
        Me.btnProtection.Image = Global.Anti_Virus_Project.My.Resources.Resources.icons8_padlock_45px
        Me.btnProtection.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProtection.Location = New System.Drawing.Point(3, 114)
        Me.btnProtection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProtection.Name = "btnProtection"
        Me.btnProtection.Size = New System.Drawing.Size(123, 108)
        Me.btnProtection.TabIndex = 4
        Me.btnProtection.Text = "Protection"
        Me.btnProtection.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProtection.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.White
        Me.btnHome.Image = Global.Anti_Virus_Project.My.Resources.Resources.icons8_protect_45px
        Me.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHome.Location = New System.Drawing.Point(3, 3)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(123, 108)
        Me.btnHome.TabIndex = 3
        Me.btnHome.Text = "Home"
        Me.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1, 871)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 60)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "SETTINGS"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Panel3.Controls.Add(Me.CtlHome1)
        Me.Panel3.Controls.Add(Me.CtlProtection1)
        Me.Panel3.Controls.Add(Me.CtlPrivacy1)
        Me.Panel3.Controls.Add(Me.Virus_Cheast1)
        Me.Panel3.Controls.Add(Me.Update_software1)
        Me.Panel3.Controls.Add(Me.Settings1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(130, 62)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1272, 870)
        Me.Panel3.TabIndex = 2
        '
        'CtlHome1
        '
        Me.CtlHome1.BackColor = System.Drawing.Color.DarkCyan
        Me.CtlHome1.Location = New System.Drawing.Point(-3, 3)
        Me.CtlHome1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CtlHome1.Name = "CtlHome1"
        Me.CtlHome1.Size = New System.Drawing.Size(1272, 866)
        Me.CtlHome1.TabIndex = 0
        '
        'CtlProtection1
        '
        Me.CtlProtection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.CtlProtection1.Location = New System.Drawing.Point(0, 3)
        Me.CtlProtection1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CtlProtection1.Name = "CtlProtection1"
        Me.CtlProtection1.Size = New System.Drawing.Size(1272, 871)
        Me.CtlProtection1.TabIndex = 1
        '
        'CtlPrivacy1
        '
        Me.CtlPrivacy1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.CtlPrivacy1.Location = New System.Drawing.Point(2, 3)
        Me.CtlPrivacy1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CtlPrivacy1.Name = "CtlPrivacy1"
        Me.CtlPrivacy1.Size = New System.Drawing.Size(1272, 871)
        Me.CtlPrivacy1.TabIndex = 2
        '
        'Virus_Cheast1
        '
        Me.Virus_Cheast1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Virus_Cheast1.Location = New System.Drawing.Point(0, 6)
        Me.Virus_Cheast1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Virus_Cheast1.Name = "Virus_Cheast1"
        Me.Virus_Cheast1.Size = New System.Drawing.Size(1272, 866)
        Me.Virus_Cheast1.TabIndex = 3
        '
        'Update_software1
        '
        Me.Update_software1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Update_software1.Location = New System.Drawing.Point(-3, 6)
        Me.Update_software1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Update_software1.Name = "Update_software1"
        Me.Update_software1.Size = New System.Drawing.Size(1272, 865)
        Me.Update_software1.TabIndex = 4
        '
        'Settings1
        '
        Me.Settings1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Settings1.Location = New System.Drawing.Point(0, 0)
        Me.Settings1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Settings1.Name = "Settings1"
        Me.Settings1.Size = New System.Drawing.Size(1272, 871)
        Me.Settings1.TabIndex = 5
        '
        'CtlScan1
        '
        Me.CtlScan1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.CtlScan1.Location = New System.Drawing.Point(0, 63)
        Me.CtlScan1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CtlScan1.Name = "CtlScan1"
        Me.CtlScan1.Size = New System.Drawing.Size(1400, 871)
        Me.CtlScan1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1402, 932)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CtlScan1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnHome As Button
    Friend WithEvents btnStatus As Button
    Friend WithEvents btnPrivacy As Button
    Friend WithEvents btnProtection As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CtlHome1 As CtlHome
    Friend WithEvents CtlProtection1 As CtlProtection
    Friend WithEvents CtlScan1 As ctlScan
    Friend WithEvents Button1 As Button
    Friend WithEvents CtlPrivacy1 As CtlPrivacy
    Friend WithEvents btnResults As Button
    Friend WithEvents Virus_Cheast1 As Virus_Cheast
    Friend WithEvents Label3 As Label
    Friend WithEvents Update_software1 As update_software
    Friend WithEvents Settings1 As Settings
End Class
