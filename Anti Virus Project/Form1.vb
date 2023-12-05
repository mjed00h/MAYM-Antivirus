Imports System.Management
Imports System.Reflection
Imports System.Threading

Public Class Form1
    Private WithEvents m_MediaConnectWatcher As ManagementEventWatcher
    Public USBDriveName As String
    Public USBDriveLetter As String

    Private drag As Boolean
    Private mouseX As Integer
    Private mouseY As Integer



    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or &H20000
            cp.ExStyle = cp.ExStyle Or 33554432
            Const WS_MINIMIZEBOX As Integer = &H20000
            cp.Style = cp.Style Or WS_MINIMIZEBOX

            Return cp
        End Get
    End Property

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        AllFunctions.HomeButton()
    End Sub

    Private Sub btnProtection_Click(sender As Object, e As EventArgs) Handles btnProtection.Click
        AllFunctions.ProtectionButton()
    End Sub

    Private Sub btnPrivacy_Click(sender As Object, e As EventArgs) Handles btnPrivacy.Click
        AllFunctions.PrivacyButton()
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        AllFunctions.StatusButton()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmClose.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, Panel2.MouseDown, Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            AllFunctions.ReleaseCapture()
            AllFunctions.SendMessage(Handle, AllFunctions.WM_NCLBUTTONDOWN, AllFunctions.HT_CAPTION, 0)
        End If
    End Sub


    Public Sub StartDetection()
        ' __InstanceOperationEvent will trap both Creation and Deletion of class instances
        Dim query2 As New WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 " _
  & "WHERE TargetInstance ISA 'Win32_DiskDrive'")

        m_MediaConnectWatcher = New ManagementEventWatcher
        m_MediaConnectWatcher.Query = query2
        m_MediaConnectWatcher.Start()
    End Sub

    Private Sub Arrived(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles m_MediaConnectWatcher.EventArrived


        Dim mbo, obj As ManagementBaseObject

        ' the first thing we have to do is figure out if this is a creation or deletion event
        mbo = CType(e.NewEvent, ManagementBaseObject)
        ' next we need a copy of the instance that was either created or deleted
        obj = CType(mbo("TargetInstance"), ManagementBaseObject)

        Select Case mbo.ClassPath.ClassName
            Case "__InstanceCreationEvent"
                If obj("InterfaceType") = "USB" Then
                    Try
                        AllFunctions.letternumber = (obj("Caption"))
                        AllFunctions.lettername = " (Drive letter " & GetDriveLetterFromDisk(obj("Name")) & ")"
                        AllFunctions.driveletter = GetDriveLetterFromDisk(obj("Name")) & "\"
                        AllFunctions.driveDirectory = GetDriveLetterFromDisk(obj("Name")) & "\"
                        Try

                        Catch ex As Exception

                        End Try
                        CtlScan1.BringToFront()
                        CtlScan1.Button1.PerformClick()
                        Console.WriteLine("USB Inserted")



                    Catch ex As Exception

                    End Try
                Else

                End If

        End Select
    End Sub

    Private Function GetDriveLetterFromDisk(ByVal Name As String) As String
        Dim oq_part, oq_disk As ObjectQuery
        Dim mos_part, mos_disk As ManagementObjectSearcher
        Dim obj_part, obj_disk As ManagementObject
        Dim ans As String = ""

        Name = Replace(Name, "\", "\\")

        oq_part = New ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID=""" & Name & """} WHERE AssocClass = Win32_DiskDriveToDiskPartition")
        mos_part = New ManagementObjectSearcher(oq_part)
        For Each obj_part In mos_part.Get()

            oq_disk = New ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=""" & obj_part("DeviceID") & """} WHERE AssocClass = Win32_LogicalDiskToPartition")
            mos_disk = New ManagementObjectSearcher(oq_disk)
            For Each obj_disk In mos_disk.Get()
                ans &= obj_disk("Name") & ","
            Next
        Next

        Return ans.Trim(","c)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        StartDetection()
        AllFunctions.getTheme()
    End Sub

    Private Sub btnResults_Click(sender As Object, e As EventArgs) Handles btnResults.Click
        AllFunctions.ResultsButton()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AllFunctions.SettingsButton()
    End Sub
    Private Sub ChangeLabelForeColors(ByVal newColor As Color)
        For Each control As Control In Me.Controls
            If TypeOf control Is Label Then
                Dim labelControl As Label = DirectCast(control, Label)
                labelControl.ForeColor = newColor
            End If
        Next
    End Sub

    Private Sub CtlHome1_Load(sender As Object, e As EventArgs) Handles CtlHome1.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
