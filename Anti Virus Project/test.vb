

Imports System.IO
Imports System.Text

Public Class test

    Private Sub LockFolder(directoryPath As String, encryptionKey As String)
        Try
            ' Encrypt the folder content
            For Each filePath As String In Directory.GetFiles(directoryPath)
                EncryptFile(filePath, encryptionKey)
            Next

            ' Rename the folder to hide it
            Directory.Move(directoryPath, directoryPath & ".locked")
        Catch ex As Exception
            MessageBox.Show("Error locking the folder: " & ex.Message)
        End Try
    End Sub

    Private Sub UnlockFolder(lockedFolderPath As String, encryptionKey As String)
        Try
            ' Rename the folder to restore it
            Directory.Move(lockedFolderPath, lockedFolderPath.Substring(0, lockedFolderPath.Length - 7))

            ' Decrypt the folder content
            For Each filePath As String In Directory.GetFiles(lockedFolderPath.Substring(0, lockedFolderPath.Length - 7))
                DecryptFile(filePath, encryptionKey)
            Next
        Catch ex As Exception
            MessageBox.Show("Error unlocking the folder: " & ex.Message)
        End Try
    End Sub

    Private Sub EncryptFile(filePath As String, encryptionKey As String)
        Try
            Dim text As String = File.ReadAllText(filePath)
            Dim encryptedText As String = XOREncrypt(text, encryptionKey)
            File.WriteAllText(filePath, encryptedText)
        Catch ex As Exception
            MessageBox.Show("Error encrypting the file: " & ex.Message)
        End Try
    End Sub

    Private Sub DecryptFile(filePath As String, encryptionKey As String)
        Try
            Dim encryptedText As String = File.ReadAllText(filePath)
            Dim decryptedText As String = XOREncrypt(encryptedText, encryptionKey)
            File.WriteAllText(filePath, decryptedText)
        Catch ex As Exception
            MessageBox.Show("Error decrypting the file: " & ex.Message)
        End Try
    End Sub

    Private Function XOREncrypt(text As String, key As String) As String
        Dim encryptedText As New StringBuilder(text.Length)

        For i As Integer = 0 To text.Length - 1
            encryptedText.Append(ChrW(AscW(text(i)) Xor AscW(key(i Mod key.Length))))
        Next

        Return encryptedText.ToString()
    End Function

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim folderPath As String = "C:\test" ' Replace with the folder path you want to lock
        Dim encryptionKey As String = "1234567890" ' Replace with your encryption key
        LockFolder(folderPath, encryptionKey)
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim lockedFolderPath As String = "C:\test" ' Replace with the locked folder path
        Dim encryptionKey As String = "1234567890" ' Replace with your encryption key
        UnlockFolder(lockedFolderPath, encryptionKey)
    End Sub
End Class