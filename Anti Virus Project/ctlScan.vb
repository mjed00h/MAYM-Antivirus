Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class ctlScan

    Private md5Hashes As New HashSet(Of String)() ' Store MD5 hashes in memory

    Private Const Md5HashFilePath As String = "main.db"
    Private TargetMd5Hashes As List(Of String)
    Private fileHash As String ' Declare fileHash at a higher scope

    Private Sub LoadTargetMd5Hashes()
        ' Read MD5 hashes from the file into a list
        TargetMd5Hashes = New List(Of String)

        If File.Exists(Md5HashFilePath) Then
            TargetMd5Hashes.AddRange(File.ReadLines(Md5HashFilePath))
        Else
            MessageBox.Show("MD5 hash file does not exist.")
        End If
    End Sub




    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.SendToBack()
    End Sub
    Private Sub AddItemToListView(fileName As String, status As String, fileType As String, color As Color)
        Dim item As New ListViewItem(fileName)
        item.SubItems.Add(fileType) ' Add file type as a sub-item
        item.SubItems.Add(status)
        item.ForeColor = color

        ' Add the item to the ListView
        Form1.CtlScan1.ListView1.Items.Add(item)
    End Sub


    Private Sub AddInfectedFileToListView(fileName As String)
        ' Add an infected file to the new ListView
        Dim item As New ListViewItem(fileName)
        item.SubItems.Add("Infected")

    End Sub

    Private Sub AddItemToListView(fileName As String, result As String, color As Color)
        Dim item As New ListViewItem(fileName)
        item.SubItems.Add(result)
        item.ForeColor = color

        ' Add the item to the ListView
        ListView1.Items.Add(item)
    End Sub

    Private Function CalculateMD5(filePath As String) As String
        Using md5 As MD5 = MD5.Create()
            Using stream As FileStream = File.OpenRead(filePath)
                Dim hashBytes As Byte() = md5.ComputeHash(stream)
                Dim hashStringBuilder As New StringBuilder()

                For Each hashByte As Byte In hashBytes
                    hashStringBuilder.Append(hashByte.ToString("x2"))
                Next

                Return hashStringBuilder.ToString()
            End Using
        End Using
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDeepScan.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Clear()
            ListView1.Items.Clear()
        Else
            Exit Sub
        End If

        On Error Resume Next

        For Each strFile As String In System.IO.Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.AllDirectories)
            ListBox1.Items.Add(strFile)
        Next
        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' Initialization code
        LoadTargetMd5Hashes()
        ProgressBar3.Maximum = ListBox1.Items.Count
        frmUSB.ProgressBar3.Maximum = ListBox1.Items.Count
        lblTotal.Text = ProgressBar3.Value.ToString() & "%"

        lblTotal.Text = ListBox1.Items.Count.ToString()
        ListBox1.Enabled = False

        If ProgressBar3.Value < ProgressBar3.Maximum Then

            Try
                ListBox1.SelectedIndex += 1
                lbllast.Text = ListBox1.SelectedItem.ToString()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                ' Get the file extension
                Dim fileExtension As String = Path.GetExtension(ListBox1.SelectedItem.ToString()).ToLower()

                ' Calculate the MD5 hash of the currently scanned file
                fileHash = CalculateMD5(ListBox1.SelectedItem.ToString())

                If TargetMd5Hashes.Contains(fileHash) Then
                    ' File matches one of the target MD5 hashes, mark it as a threat
                    AddItemToListView(ListBox1.SelectedItem.ToString(), "Threat", fileExtension, Color.Red)

                    ' Add the infected file to the ListView on frmThredScreen
                    Form1.Virus_Cheast1.AddInfectedFileToListView(ListBox1.SelectedItem.ToString())
                Else
                    ' File does not match any target MD5 hash, mark it as clean
                    AddItemToListView(ListBox1.SelectedItem.ToString(), "Clean", fileExtension, Color.Green)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            ' Update labels and progress bar
            ProgressBar3.Increment(1)
            ProgressBar4.Increment(1)
            lblVirus.Text = Form1.Virus_Cheast1.ListView1.Items.Count.ToString()

        Else
            ' Finalization code
            ListView1.Enabled = True
            Timer1.Stop()

            If Form1.Virus_Cheast1.ListView1.Items.Count > 0 Then
                MessageBox.Show("Scanning has been completed. There were " & vbCrLf & Form1.CtlScan1.ListView1.Items.Count & " viruses detected. Please review the list and choose an action.")
                My.Settings.lastScanned = FolderBrowserDialog1.SelectedPath
                My.Settings.recordsFound = Form1.CtlScan1.ListView1.Items.Count.ToString
                My.Settings.Save()

            Else
                MessageBox.Show("Scanning has been completed." & vbCrLf & " No viruses were found.")
                My.Settings.lastScanned = FolderBrowserDialog1.SelectedPath
                My.Settings.recordsFound = Form1.CtlScan1.ListView1.Items.Count.ToString
                My.Settings.Save()

            End If

            ' Reset progress bar
            ProgressBar3.Value = 0
            ProgressBar4.Value = 0
        End If
    End Sub

    Private Sub btnProtection_Click(sender As Object, e As EventArgs) Handles btnSmartScan.Click
        FolderBrowserDialog1.SelectedPath = "C:\Riot Games"

        Try
            For Each strDir As String In System.IO.Directory.GetDirectories(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.TopDirectoryOnly)
                For Each strFile As String In System.IO.Directory.GetFiles(strDir, "*.*", SearchOption.AllDirectories)
                    ListBox1.Items.Add(strFile)
                Next
            Next
            Timer1.Start()
            ProgressBar3.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.SelectedPath = AllFunctions.driveDirectory
        On Error Resume Next

        For Each strDir As String In System.IO.Directory.GetDirectories(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.TopDirectoryOnly)
            For Each strFile As String In System.IO.Directory.GetFiles(strDir, "*.*", SearchOption.AllDirectories)
                ListBox1.Items.Add(strFile)
            Next
        Next

        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Are you sure you want to abort the scan?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Timer1.Stop()

            ' Get the selected folder path
            Dim selectedFolderPath As String = FolderBrowserDialog1.SelectedPath

            If Form1.CtlScan1.ListView1.Items.Count > 0 Then
                ' Scanning completed with viruses detected
                MessageBox.Show("Scanning has been completed. There were " & Form1.CtlScan1.ListView1.Items.Count & " files detected. Please review the list and choose an action.")

                ' Set the lastScanned and recordsFound properties in My.Settings
                My.Settings.lastScanned = selectedFolderPath
                My.Settings.recordsFound = Form1.CtlScan1.ListView1.Items.Count.ToString()

                ' Save the settings
                My.Settings.Save()

                ' Reset progress bars
                ProgressBar3.Value = 0
                ProgressBar4.Value = 0
            Else
                ' Scanning completed with no viruses detected
                MessageBox.Show("Scanning has been completed." & vbCrLf & " No viruses were found.")

                ' Set the lastScanned and recordsFound properties in My.Settings
                My.Settings.lastScanned = selectedFolderPath
                My.Settings.recordsFound = "0" ' Set to 0 since no viruses were found

                ' Save the settings
                My.Settings.Save()

                ' Reset progress bars
                ProgressBar3.Value = 0
                ProgressBar4.Value = 0
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.SelectedPath = AllFunctions.driveletter

        On Error Resume Next

        For Each strDir As String In System.IO.Directory.GetDirectories(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.TopDirectoryOnly)
            For Each strFile As String In System.IO.Directory.GetFiles(strDir, "*.*", SearchOption.AllDirectories)
                ListBox1.Items.Add(strFile)
            Next
        Next

        Timer1.Start()
    End Sub

    Private Sub ctlScan_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub ctlScan_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub lbllast_Click(sender As Object, e As EventArgs) Handles lbllast.Click

    End Sub
End Class
