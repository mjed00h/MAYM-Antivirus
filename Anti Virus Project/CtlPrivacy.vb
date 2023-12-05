Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class CtlPrivacy
    Private Sub CtlPrivacy_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If CheckBox1.Checked = False Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If CheckBox2.Checked = False Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If CheckBox3.Checked = False Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If CheckBox4.Checked = False Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            PictureBox2.Image = My.Resources._ON
        Else
            PictureBox2.Image = My.Resources.off
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            PictureBox3.Image = My.Resources._ON
        Else
            PictureBox3.Image = My.Resources.off
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            PictureBox5.Image = My.Resources._ON
        Else
            PictureBox5.Image = My.Resources.off
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            PictureBox1.Image = My.Resources._ON
        Else
            PictureBox1.Image = My.Resources.off
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
