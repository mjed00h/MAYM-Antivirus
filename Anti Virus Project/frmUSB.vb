Imports System.Reflection
Imports System.Threading

Public Class frmUSB
    Private counter As Integer = 15

    Private counter2 As Integer = 30
    Private Sub frmUSB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeLabelForeColors(My.Settings.foreColor)
        Form1.Hide()
        Label3.Text = AllFunctions.letternumber
        Label1.Text = AllFunctions.lettername

        ' Get the screen dimensions
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height

        ' Position the form at the bottom-right corner of the screen
        Me.Left = screenWidth - Me.Width * 1
        Me.Top = screenHeight - Me.Height * 1

        ' Make the form always on top
        Me.TopMost = True

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'btnSkip.Text = "OKAY " & counter & " (s)"
        counter -= 1
        If counter = 0 Then
            Timer1.Stop()
            'btnSkip.Text = "OKAY"
            'btnSkip.Enabled = True
        End If
    End Sub

    Private Sub btnSkip_Click(sender As Object, e As EventArgs) Handles btnSkip.Click
        Form1.Show()

        Form1.CtlScan1.Button1.PerformClick()
        Form1.CtlScan1.BringToFront()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        If Form1.Visible = False Then
            Form1.CtlScan1.FolderBrowserDialog1.SelectedPath = AllFunctions.driveDirectory

        Else
            Form1.CtlScan1.FolderBrowserDialog1.SelectedPath = AllFunctions.driveDirectory

            Form1.CtlScan1.Button1.PerformClick()

        End If

    End Sub
    Private Sub ChangeLabelForeColors(ByVal newColor As Color)
        For Each control As Control In Me.Controls
            If TypeOf control Is Label Then
                Dim labelControl As Label = DirectCast(control, Label)
                labelControl.ForeColor = newColor
            End If
        Next
    End Sub

End Class