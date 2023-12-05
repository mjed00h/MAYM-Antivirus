Public Class CtlHome
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.CtlScan1.BringToFront()
        Form1.CtlScan1.btnSmartScan.PerformClick()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.CtlScan1.BringToFront()
        Form1.CtlScan1.btnDeepScan.PerformClick()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.CtlScan1.BringToFront()
        Form1.CtlScan1.btnOthers.PerformClick()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.btnResults.PerformClick()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.btnResults.PerformClick()
    End Sub

    Private Sub CtlHome_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeLabelForeColors(My.Settings.foreColor)
        lblLastScanned.Text = My.Settings.lastScanned
        lblRecordsFound.Text = My.Settings.recordsFound
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
