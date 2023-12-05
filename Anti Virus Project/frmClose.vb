Public Class frmClose
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            AllFunctions.ReleaseCapture()
            AllFunctions.SendMessage(Handle, AllFunctions.WM_NCLBUTTONDOWN, AllFunctions.HT_CAPTION, 0)
        End If
    End Sub

    Private Sub frmClose_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeLabelForeColors(My.Settings.foreColor)
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