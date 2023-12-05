Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomSwitch
    Inherits Control

    Private isOn As Boolean = False

    Public Event SwitchStateChanged(sender As Object, e As EventArgs)

    Public Sub New()
        Me.Size = New Size(80, 40)
        Me.BackColor = Color.Gray
        Me.DoubleBuffered = True
        Me.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        ToggleSwitch()
    End Sub

    Private Sub ToggleSwitch()
        isOn = Not isOn
        Me.Invalidate()
        RaiseEvent SwitchStateChanged(Me, EventArgs.Empty)

    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Using g As Graphics = e.Graphics
            ' Draw the background
            Dim bgColor As Color = If(isOn, Color.Green, Color.Gray)
            Using bgBrush As New SolidBrush(bgColor)
                g.FillRectangle(bgBrush, ClientRectangle)
            End Using

            ' Draw the switch button
            Dim buttonColor As Color = Color.White
            Dim buttonX As Integer = If(isOn, Width - Height, 0)
            Using buttonBrush As New SolidBrush(buttonColor)
                g.FillEllipse(buttonBrush, New Rectangle(buttonX, 0, Height, Height))
            End Using
        End Using
    End Sub
    Public Property IsOnState() As Boolean
        Get
            Return isOn
        End Get
        Set(value As Boolean)
            If isOn <> value Then
                isOn = value
                Me.Invalidate() ' Redraw the control
            End If
        End Set
    End Property

End Class
