Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class Virus_Cheast
    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Public Function DeleteFilesToRecycleBin(listView As ListView) As Boolean
        Try
            For Each selectedItem As ListViewItem In listView.CheckedItems
                Dim filePath As String = selectedItem.Text

                If File.Exists(filePath) Then
                    ' Use the FileSystem.DeleteFile method to move to the recycle bin
                    FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin)
                    MessageBox.Show("All Threat Deleted Successfully!")
                End If
            Next

            Return True ' Deletion succeeded
        Catch ex As Exception
            MessageBox.Show("Error deleting files: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' Deletion failed
        End Try
    End Function
    Private Sub DeleteSelectedItemsAndFiles(listView As ListView)
        ' Iterate through selected items in reverse order to avoid index issues
        For i As Integer = listView.CheckedItems.Count - 1 To 0 Step -1
            Dim filePath As String = listView.SelectedItems(i).Text
            Try
                ' Delete the file from the file system
                File.Delete(filePath)
                MessageBox.Show("Threat Deleted Successfully!")
            Catch ex As Exception
                ' Handle any errors that may occur during file deletion
                MessageBox.Show("Error deleting file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Remove the item from the ListView
            listView.Items.Remove(listView.CheckedItems(i))
        Next
    End Sub

    Private Sub DeleteAllItemsAndFiles(listView As ListView)
        ' Iterate through all items in reverse order to avoid index issues
        For i As Integer = listView.Items.Count - 1 To 0 Step -1
            Dim filePath As String = listView.Items(i).Text
            Try
                ' Delete the file from the file system
                File.Delete(filePath)
                MessageBox.Show("All Threat Deleted Successfully!")
            Catch ex As Exception
                ' Handle any errors that may occur during file deletion
                MessageBox.Show("Error deleting file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Remove the item from the ListView
            listView.Items.RemoveAt(i)
        Next
    End Sub


    Public Sub AddInfectedFileToListView(fileName As String)
        ' Add an infected file to the ListView on InfectedFilesScreen
        Dim item As New ListViewItem(fileName)
        item.SubItems.Add("Infected")
        ListView1.Items.Add(item)
        item.ForeColor = Color.Red ' Set the foreColor color to red
    End Sub
    Private Sub QuarantineSelectedFiles()
        ' Get the path to the Quarantine folder
        Dim quarantineFolder As String = Path.Combine(Application.StartupPath, "Quarantine")

        ' Create the Quarantine folder if it doesn't exist
        If Not Directory.Exists(quarantineFolder) Then
            Directory.CreateDirectory(quarantineFolder)
        End If

        ' Iterate through selected items (infected files) in the ListView
        For Each selectedItem As ListViewItem In ListView1.CheckedItems
            Dim filePath As String = selectedItem.Text

            Try
                ' Build the destination path in the Quarantine folder
                Dim destinationPath As String = Path.Combine(quarantineFolder, Path.GetFileName(filePath))

                ' Check if the file already exists in the Quarantine folder
                If File.Exists(destinationPath) Then
                    ' You can rename the file or handle it as needed
                    destinationPath = Path.Combine(quarantineFolder, $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now:yyyyMMddHHmmssfff}{Path.GetExtension(filePath)}")
                End If

                ' Move the file to the Quarantine folder
                File.Move(filePath, destinationPath)


                ' Remove the item from the ListView
                ListView1.Items.Remove(selectedItem)
                MessageBox.Show("Threat Quarantined Successfully!")
            Catch ex As Exception
                ' Handle any errors that may occur during file movement
                MessageBox.Show("Error quarantining file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        QuarantineSelectedFiles()
        ListQuarantineFiles()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For Each item As ListViewItem In ListView1.Items
                item.Checked = True
            Next
        Else
            For Each item As ListViewItem In ListView1.Items
                item.Checked = False
            Next
        End If
    End Sub

    Private Sub ListQuarantineFiles()

        ' Get the path to the Quarantine folder
        Dim quarantineFolder As String = Path.Combine(Application.StartupPath, "Quarantine")

        ' Check if the Quarantine folder exists
        If Directory.Exists(quarantineFolder) Then
            ' Clear the ListView before populating it
            ListView2.Items.Clear()
            ' Get a list of files in the Quarantine folder
            Dim quarantineFiles() As String = Directory.GetFiles(quarantineFolder)

            ' Iterate through the files and add them to the ListView
            For Each filePath As String In quarantineFiles
                Dim item As New ListViewItem(Path.GetFileName(filePath)) ' Use only the file name
                item.SubItems.Add("Quarantine")
                item.ForeColor = Color.Blue ' Set the background color to red

                ' Add the item to the ListView
                ListView2.Items.Add(item)
            Next
        End If
    End Sub

    Private Sub DeleteAllQuarantineFiles()
        ' Get the path to the Quarantine folder
        Dim quarantineFolder As String = Path.Combine(Application.StartupPath, "Quarantine")

        ' Check if the Quarantine folder exists
        If Directory.Exists(quarantineFolder) Then
            ' Iterate through all items in reverse order to avoid index issues
            For i As Integer = ListView2.Items.Count - 1 To 0 Step -1
                Dim fileName As String = ListView2.Items(i).Text
                Dim filePath As String = Path.Combine(quarantineFolder, fileName)

                Try
                    ' Delete the file from the file system
                    File.Delete(filePath)
                    MessageBox.Show("All Files Deleted from the Qurantine Successfully!")
                    ' Remove the item from the ListView
                    ListView2.Items.RemoveAt(i)
                Catch ex As Exception
                    ' Handle any errors that may occur during file deletion
                    MessageBox.Show("Error deleting file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DeleteAllQuarantineFiles()
    End Sub

    Private Sub Virus_Cheast_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeLabelForeColors(My.Settings.foreColor)
        ListQuarantineFiles()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DeleteAllItemsAndFiles(ListView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DeleteSelectedItemsAndFiles(ListView1)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            For Each item As ListViewItem In ListView2.Items
                item.Checked = True
            Next
        Else
            For Each item As ListViewItem In ListView2.Items
                item.Checked = False
            Next
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
