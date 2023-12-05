Imports System.Net.NetworkInformation
Public Class CtlProtection

    ' Enable a network adapter
    Public Shared Sub EnableNetworkAdapter(adapterName As String)
        Try
            Dim networkInterface As NetworkInterface = GetNetworkInterfaceByName(adapterName)
            If networkInterface IsNot Nothing Then
                'networkInterface.Enable()
                Console.WriteLine($"Enabled network adapter: {adapterName}")
            Else
                Console.WriteLine($"Network adapter '{adapterName}' not found.")
            End If
        Catch ex As Exception
            Console.WriteLine($"Error enabling network adapter: {ex.Message}")
        End Try
    End Sub

    ' Disable a network adapter
    Public Shared Sub DisableNetworkAdapter(adapterName As String)
        Try
            Dim networkInterface As NetworkInterface = GetNetworkInterfaceByName(adapterName)
            If networkInterface IsNot Nothing Then
                'networkInterface.Disable()
                Console.WriteLine($"Disabled network adapter: {adapterName}")
            Else
                Console.WriteLine($"Network adapter '{adapterName}' not found.")
            End If
        Catch ex As Exception
            Console.WriteLine($"Error disabling network adapter: {ex.Message}")
        End Try
    End Sub

    ' Get a network interface by name
    Private Shared Function GetNetworkInterfaceByName(adapterName As String) As NetworkInterface
        Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        For Each networkInterface As NetworkInterface In networkInterfaces
            If networkInterface.Name = adapterName Then
                Return networkInterface
            End If
        Next
        Return Nothing
    End Function

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            PictureBox2.Image = My.Resources._ON
            PictureBox3.Image = My.Resources._ON
            Label3.Text = "is protecting you!"
            ' Enable the network adapter here
            EnableNetworkAdapter("YourNetworkAdapterName")
            My.Settings.protection = True
            My.Settings.Save()
        Else
            PictureBox2.Image = My.Resources.off
            PictureBox3.Image = My.Resources.off
            Label3.Text = "is NOT protecting you!"
            My.Settings.protection = False
            My.Settings.Save()
            ' Disable the network adapter here
            DisableNetworkAdapter("YourNetworkAdapterName")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            PictureBox2.Image = My.Resources._ON
            PictureBox3.Image = My.Resources._ON
            Label3.Text = "is protecting you!"
            ' Enable the network adapter here
            EnableNetworkAdapter("YourNetworkAdapterName")
            My.Settings.protection = True
            My.Settings.Save()
        Else
            PictureBox2.Image = My.Resources.off
            PictureBox3.Image = My.Resources.off
            Label3.Text = "is NOT protecting you!"
            My.Settings.protection = False
            My.Settings.Save()
            ' Disable the network adapter here
            DisableNetworkAdapter("YourNetworkAdapterName")
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If CheckBox2.Checked = False Then
            CheckBox2.Checked = True

        Else
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If CheckBox1.Checked = False Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CtlProtection_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeLabelForeColors(My.Settings.foreColor)
        If My.Settings.protection = True Then
            CheckBox1.Checked = True
            CheckBox2.Checked = True
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
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

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
