Imports Microsoft.Win32

Public Class update_software
    Private Sub ListInstalledSoftware()
        Try
            ' Create the DataGridView and add columns

            dataGridView.Columns.Add("Software Name", "Software Name")
            dataGridView.Columns.Add("Version", "Version")

            ' Create a DataGridViewImageColumn for the "Icon" column
            Dim iconColumn As New DataGridViewImageColumn()
            iconColumn.Name = "Icon"
            iconColumn.HeaderText = "Icon"
            dataGridView.Columns.Add(iconColumn)

            dataGridView.Columns.Add("Uninstall", "Uninstall")

            ' Get the list of installed software
            Dim uninstallKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")

            For Each subkeyName As String In uninstallKey.GetSubKeyNames()
                Dim subkey As RegistryKey = uninstallKey.OpenSubKey(subkeyName)

                Dim softwareName As String = TryCast(subkey.GetValue("DisplayName"), String)
                Dim version As String = TryCast(subkey.GetValue("DisplayVersion"), String)

                ' Filter out items with no display name or version
                If Not String.IsNullOrEmpty(softwareName) AndAlso Not String.IsNullOrEmpty(version) Then
                    ' Use a default icon in case the icon is missing
                    Dim icon As Icon = SystemIcons.Application

                    ' Try to get the icon from the UninstallString
                    Dim uninstallString As String = TryCast(subkey.GetValue("UninstallString"), String)
                    If Not String.IsNullOrEmpty(uninstallString) Then
                        Dim iconPath As String = uninstallString.Replace(" /I", "")
                        If System.IO.File.Exists(iconPath) Then
                            icon = Icon.ExtractAssociatedIcon(iconPath)
                        End If
                    End If

                    ' Add the icon to the DataGridView
                    Dim row As DataGridViewRow = dataGridView.Rows(dataGridView.Rows.Add({softwareName, version, IconToImage(icon), "Uninstall"}))
                    ' Set the width of the "Software Name" column
                    row.Cells("Software Name").Style.WrapMode = DataGridViewTriState.True
                    row.Cells("Software Name").Style.Padding = New Padding(5) ' Adjust padding as needed
                    row.Cells("Software Name").Style.Alignment = DataGridViewContentAlignment.MiddleLeft

                    ' Set the row height (adjust as needed)
                    row.Height = 30 ' Increase the height as needed to accommodate larger text
                End If
            Next

            ' Adjust the "Software Name" column width
            dataGridView.Columns("Software Name").Width = 550

            ' Set width for other columns (adjust as needed)
            dataGridView.Columns("Icon").Width = 50
            dataGridView.Columns("Uninstall").Width = 70
            dataGridView.Columns("Uninstall").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dataGridView.Columns("Uninstall").CellTemplate.Style.BackColor = Color.Red
            dataGridView.Columns("Uninstall").CellTemplate.Style.ForeColor = Color.White
            dataGridView.AllowUserToAddRows = False ' Remove the empty row at the bottom

            ' Add the DataGridView to your form
            Me.Controls.Add(dataGridView)

            ' Handle the Uninstall button click event
            AddHandler dataGridView.CellClick, AddressOf DataGridViewCellClick
        Catch ex As Exception
            MessageBox.Show("Error listing installed software: " & ex.Message)
        End Try
    End Sub

    Private Function IconToImage(icon As Icon) As Image
        If icon Is Nothing Then
            Return Nothing
        End If

        Dim image As New Bitmap(icon.Width, icon.Height)
        Using g As Graphics = Graphics.FromImage(image)
            g.DrawIcon(icon, 0, 0)
        End Using

        Return image
    End Function



    Private Sub UninstallButtonClick(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        Dim softwareName As String = DirectCast(button.Tag, String)
        ' Perform the uninstall operation using softwareName
        ' Replace this with your actual uninstall logic
        MessageBox.Show("Uninstall " & softwareName)
    End Sub

    Private Function GetSoftwareIcon(softwareName As String) As Icon
        Return SystemIcons.Application
    End Function

    Private Sub DataGridViewCellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 3 Then ' Check for Uninstall button click
            Dim softwareName As String = DirectCast(DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("Software Name").Value, String)
            Dim uninstallCommand As String = GetUninstallCommand(softwareName)

            If Not String.IsNullOrEmpty(uninstallCommand) Then
                Try
                    ' Run the uninstall command
                    Dim processStartInfo As New ProcessStartInfo("cmd.exe", $"/c {uninstallCommand}")
                    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Dim process As New Process With {
                    .StartInfo = processStartInfo
                }
                    process.Start()
                    process.WaitForExit()

                    ' Update the DataGridView or perform any other actions as needed
                    MessageBox.Show($"{softwareName} has been uninstalled.")

                Catch ex As Exception
                    MessageBox.Show($"Error uninstalling {softwareName}: {ex.Message}")
                End Try
            Else
                MessageBox.Show($"{softwareName} uninstall command not found.")
            End If
        End If
    End Sub

    Private Function GetUninstallCommand(softwareName As String) As String
        ' Try to find the uninstall command for the specified softwareName
        Dim uninstallKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")

        For Each subkeyName As String In uninstallKey.GetSubKeyNames()
            Dim subkey As RegistryKey = uninstallKey.OpenSubKey(subkeyName)
            Dim displayName As String = TryCast(subkey.GetValue("DisplayName"), String)

            If Not String.IsNullOrEmpty(displayName) AndAlso displayName = softwareName Then
                Dim uninstallString As String = TryCast(subkey.GetValue("UninstallString"), String)

                If Not String.IsNullOrEmpty(uninstallString) Then
                    Return uninstallString
                End If
            End If
        Next

        Return String.Empty
    End Function

    Private Sub update_software_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeLabelForeColors(My.Settings.foreColor)
        ListInstalledSoftware()
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
