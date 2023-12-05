Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class AllFunctions
    Public Shared lettername As String = ""
    Public Shared letternumber As String = ""
    Public Shared driveletter As String = ""
    Public Shared driveDirectory As String = ""
    Public Shared defaultScanDirectory As String = My.Settings.defaultScanDirectory
    Public Shared baseColor As Color = My.Settings.defaultColor
    Public Shared secondaryColor As Color = My.Settings.primaryColor

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2


    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Public Shared Sub HomeButton()
        With Form1
            .btnHome.BackColor = baseColor
            .btnPrivacy.BackColor = secondaryColor
            .btnProtection.BackColor = secondaryColor
            .btnStatus.BackColor = secondaryColor
            .btnResults.BackColor = secondaryColor
            .CtlHome1.BringToFront()
        End With
    End Sub

    Public Shared Sub ProtectionButton()
        With Form1
            .btnHome.BackColor = secondaryColor
            .btnPrivacy.BackColor = secondaryColor
            .btnProtection.BackColor = baseColor
            .btnStatus.BackColor = secondaryColor
            .btnResults.BackColor = secondaryColor
            .CtlProtection1.BringToFront()
        End With
    End Sub

    Public Shared Sub PrivacyButton()
        With Form1
            .btnHome.BackColor = secondaryColor
            .btnPrivacy.BackColor = baseColor
            .btnProtection.BackColor = secondaryColor
            .btnStatus.BackColor = secondaryColor
            .btnResults.BackColor = secondaryColor
            .CtlPrivacy1.BringToFront()
        End With
    End Sub

    Public Shared Sub StatusButton()
        With Form1
            .btnHome.BackColor = secondaryColor
            .btnPrivacy.BackColor = secondaryColor
            .btnProtection.BackColor = secondaryColor
            .btnStatus.BackColor = baseColor
            .btnResults.BackColor = secondaryColor
            .Update_software1.BringToFront()
        End With
    End Sub
    Public Shared Sub ResultsButton()
        With Form1
            .btnHome.BackColor = secondaryColor
            .btnPrivacy.BackColor = secondaryColor
            .btnProtection.BackColor = secondaryColor
            .btnStatus.BackColor = secondaryColor
            .btnResults.BackColor = baseColor
            .Virus_Cheast1.BringToFront()
        End With
    End Sub


    Public Const Md5HashFilePath As String = "main.db"
    Public TargetMd5Hashes As List(Of String)

    Public Shared Sub SettingsButton()
        With Form1
            .btnHome.BackColor = secondaryColor
            .btnPrivacy.BackColor = secondaryColor
            .btnProtection.BackColor = secondaryColor
            .btnStatus.BackColor = secondaryColor
            .btnResults.BackColor = secondaryColor
            .Settings1.BringToFront()
        End With
    End Sub
    Public Shared Sub getTheme()
        With Form1
            .Panel1.BackColor = My.Settings.primaryColor
            .Panel2.BackColor = My.Settings.primaryColor
            .Button5.BackColor = My.Settings.primaryColor
            .Button6.BackColor = My.Settings.primaryColor
            .PictureBox3.BackColor = My.Settings.primaryColor
            .btnHome.BackColor = My.Settings.defaultColor
            .btnProtection.BackColor = My.Settings.primaryColor
            .btnPrivacy.BackColor = My.Settings.primaryColor
            .btnResults.BackColor = My.Settings.primaryColor
            .btnStatus.BackColor = My.Settings.primaryColor
        End With

        frmClose.BackColor = My.Settings.secondaryColor
        frmClose.Panel1.BackColor = My.Settings.secondaryColor
        frmUSB.Panel1.BackColor = My.Settings.secondaryColor
        frmUSB.Button5.BackColor = My.Settings.secondaryColor

        With Form1.CtlHome1
            .BackColor = My.Settings.secondaryColor
            .Button3.BackColor = My.Settings.defaultColor
            .Button4.BackColor = My.Settings.defaultColor
            .Button5.BackColor = My.Settings.defaultColor
            .Panel4.BackColor = My.Settings.defaultColor
            .Button2.BackColor = My.Settings.secondaryColor
            .Button1.BackColor = My.Settings.secondaryColor
            .Panel1.BackColor = My.Settings.homeColor
            .Panel2.BackColor = My.Settings.homeColor
            .Panel3.BackColor = My.Settings.homeColor
        End With

        With Form1.CtlPrivacy1
            .BackColor = My.Settings.secondaryColor
        End With

        With Form1.CtlProtection1
            .BackColor = My.Settings.secondaryColor
        End With
        With Form1.CtlScan1
            .BackColor = My.Settings.secondaryColor
        End With
        With Form1.Settings1
            .BackColor = My.Settings.secondaryColor
        End With
        With Form1.Update_software1
            .BackColor = My.Settings.secondaryColor
        End With
        With Form1.Virus_Cheast1
            .TabPage1.BackColor = My.Settings.secondaryColor
            .TabPage2.BackColor = My.Settings.secondaryColor
            .BackColor = My.Settings.secondaryColor
        End With

    End Sub





End Class
