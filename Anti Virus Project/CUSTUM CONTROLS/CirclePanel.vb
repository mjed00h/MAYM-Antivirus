Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class CircularPanel
    Inherits Panel

    Public Sub New()
        ' Set some initial properties
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Using g As Graphics = e.Graphics
            ' Create a circular path
            Dim path As New GraphicsPath()
            path.AddEllipse(ClientRectangle)

            ' Set the panel's region to the circular path
            Me.Region = New Region(path)

            ' Fill the circular panel with a color or image
            Dim fillColor As Color = Color.LightBlue ' Change this to your desired fill color
            Using fillBrush As New SolidBrush(fillColor)
                g.FillPath(fillBrush, path)
            End Using

            ' Optionally, you can draw a border around the circular panel
            Dim borderColor As Color = Color.DarkBlue ' Change this to your desired border color
            Using borderPen As New Pen(borderColor, 2) ' Change the width if needed
                g.DrawPath(borderPen, path)
            End Using
        End Using
    End Sub
End Class
