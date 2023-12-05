Imports System.Threading
Imports System
Imports System.Drawing
Imports System.Reflection
Public Class Settings
    Private countdown As TimeSpan = TimeSpan.FromHours(1)
    Private startTime As DateTime
    Private countdwonTimer As Timer


    Private Sub cmbLaunch_CheckedChanged(sender As Object, e As EventArgs) Handles cmbLaunch.CheckedChanged
        If cmbLaunch.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "MyApplication", Application.ExecutablePath)
            My.Settings.launchonstartup = True
            My.Settings.Save()
        Else
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue("MyApplication")
            My.Settings.launchonstartup = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub cmbCustomHour_CheckedChanged(sender As Object, e As EventArgs) Handles  cmbCustomHour.CheckedChanged
        If cmbCustomHour.Checked = True Then
            lblHour.Visible = True
            My.Settings.scan1Hour = True
            My.Settings.Save()
            StartCountDown()
        Else
            lblHour.Visible = False
            Timer1.Stop()
            My.Settings.scan1Hour = False
            My.Settings.Save()
        End If
    End Sub
    Private Sub StartCountDown()
        startTime = DateTime.Now
        Timer1.Enabled = True
        MessageBox.Show("Scan Every 1 Hour has been Started")
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim remainingTime As TimeSpan = countdown - (DateTime.Now - startTime)
        If remainingTime.TotalMilliseconds <= 0 Then
            Timer1.Enabled = False
            StartScan()
            StartCountDown()
        Else
            lblHour.Text = remainingTime.ToString("hh\:mm\:ss")
        End If
    End Sub

    Private Sub StartScan()

        With Form1
            .CtlScan1.FolderBrowserDialog1.SelectedPath = AllFunctions.defaultScanDirectory
            .CtlScan1.Button3.PerformClick()
        End With

        Form1.CtlScan1.ListBox1.Items.Clear()

        On Error Resume Next

        For Each strFile As String In System.IO.Directory.GetFiles(AllFunctions.defaultScanDirectory, "*.*", IO.SearchOption.AllDirectories)
            Form1.CtlScan1.ListBox1.Items.Add(strFile)
        Next
        Form1.CtlScan1.Timer1.Start()

    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeLabelForeColors(My.Settings.foreColor)
        Me.BindSysColors()
        TextBox1.Text = My.Settings.defaultScanDirectory
        If My.Settings.launchonstartup = True Then
            cmbLaunch.Checked = True
        Else
            cmbLaunch.Checked = False
        End If

        If My.Settings.scan1Hour = True Then
            cmbCustomHour.Checked = True
        Else
            cmbCustomHour.Checked = False
        End If

        If My.Settings.useTheme = True Then
            GroupBox3.Enabled = True
            With Form1.Settings1
                .CheckBox2.Checked = True


            End With
        Else
            GroupBox3.Enabled = False
            With Form1.Settings1
                .PictureBox3.Image = My.Resources._ON
                .CheckBox2.Checked = False
            End With
        End If

        Panel3.BackColor = My.Settings.primaryColor
        Panel2.BackColor = My.Settings.secondaryColor
        Panel1.BackColor = My.Settings.defaultColor
        Panel4.BackColor = My.Settings.homeColor
        Panel10.BackColor = My.Settings.foreColor
        ChangeLabelForeColors(My.Settings.foreColor)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles  Button1.Click
        Dim f As New FolderBrowserDialog
        If f.ShowDialog = DialogResult.OK Then
            TextBox1.Text = f.SelectedPath.ToString
            My.Settings.defaultScanDirectory = TextBox1.Text
            My.Settings.Save()
        End If
    End Sub




    Private Sub BindSysColors()
        'binding combobox with systemcolor vaues

        'assign combobox drawmode
        cmbSysColor.DrawMode = DrawMode.OwnerDrawFixed
        cmbSysColor.ItemHeight = 20

        ComboBox1.DrawMode = DrawMode.OwnerDrawFixed
        ComboBox1.ItemHeight = 20

        ComboBox2.DrawMode = DrawMode.OwnerDrawFixed
        ComboBox2.ItemHeight = 20

        ComboBox3.DrawMode = DrawMode.OwnerDrawFixed
        ComboBox3.ItemHeight = 20

        ComboBox4.DrawMode = DrawMode.OwnerDrawFixed
        ComboBox4.ItemHeight = 20


        Dim colType As Type = GetType(System.Drawing.Color)


        For Each prop As PropertyInfo In colType.GetProperties()
            If prop.PropertyType Is GetType(System.Drawing.Color) Then
                cmbSysColor.Items.Add(prop.Name)
                ComboBox1.Items.Add(prop.Name)
                ComboBox2.Items.Add(prop.Name)
                ComboBox3.Items.Add(prop.Name)
                ComboBox4.Items.Add(prop.Name)
            End If
        Next
    End Sub


    Private Sub cmbSysColor_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles cmbSysColor.DrawItem
        'Drawing the itemsinto the combobox.

        'exit if there is no item
        If e.Index = -1 Then
            Exit Sub
        End If


        'declare a colorbrush
        Dim sysBrush As Brush = New SolidBrush(Color.FromName(DirectCast(cmbSysColor.Items(e.Index), String)))

        'Drawing rectangles for the color values
        e.Graphics.DrawRectangle(New Pen(Brushes.Black), e.Bounds.Left + 2, e.Bounds.Top + 2, 30, e.Bounds.Height - 5)
        e.Graphics.FillRectangle(sysBrush, e.Bounds.Left + 3, e.Bounds.Top + 3, 29, e.Bounds.Height - 6)

        'Draw the name of the color
        e.Graphics.DrawString(DirectCast(cmbSysColor.Items(e.Index), String), cmbSysColor.Font, Brushes.Black, 35, e.Bounds.Top + 2)

    End Sub
    Private Sub ComboBox1_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox1.DrawItem
        'Drawing the itemsinto the combobox.

        'exit if there is no item
        If e.Index = -1 Then
            Exit Sub
        End If


        'declare a colorbrush
        Dim sysBrush As Brush = New SolidBrush(Color.FromName(DirectCast(ComboBox1.Items(e.Index), String)))

        'Drawing rectangles for the color values
        e.Graphics.DrawRectangle(New Pen(Brushes.Black), e.Bounds.Left + 2, e.Bounds.Top + 2, 30, e.Bounds.Height - 5)
        e.Graphics.FillRectangle(sysBrush, e.Bounds.Left + 3, e.Bounds.Top + 3, 29, e.Bounds.Height - 6)

        'Draw the name of the color
        e.Graphics.DrawString(DirectCast(ComboBox1.Items(e.Index), String), ComboBox1.Font, Brushes.Black, 35, e.Bounds.Top + 2)

    End Sub
    Private Sub ComboBox2_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox2.DrawItem
        'Drawing the itemsinto the combobox.

        'exit if there is no item
        If e.Index = -1 Then
            Exit Sub
        End If


        'declare a colorbrush
        Dim sysBrush As Brush = New SolidBrush(Color.FromName(DirectCast(ComboBox2.Items(e.Index), String)))

        'Drawing rectangles for the color values
        e.Graphics.DrawRectangle(New Pen(Brushes.Black), e.Bounds.Left + 2, e.Bounds.Top + 2, 30, e.Bounds.Height - 5)
        e.Graphics.FillRectangle(sysBrush, e.Bounds.Left + 3, e.Bounds.Top + 3, 29, e.Bounds.Height - 6)

        'Draw the name of the color
        e.Graphics.DrawString(DirectCast(ComboBox2.Items(e.Index), String), ComboBox2.Font, Brushes.Black, 35, e.Bounds.Top + 2)

    End Sub
    Private Sub ComboBox3_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox3.DrawItem
        'Drawing the itemsinto the combobox.

        'exit if there is no item
        If e.Index = -1 Then
            Exit Sub
        End If


        'declare a colorbrush
        Dim sysBrush As Brush = New SolidBrush(Color.FromName(DirectCast(ComboBox3.Items(e.Index), String)))

        'Drawing rectangles for the color values
        e.Graphics.DrawRectangle(New Pen(Brushes.Black), e.Bounds.Left + 2, e.Bounds.Top + 2, 30, e.Bounds.Height - 5)
        e.Graphics.FillRectangle(sysBrush, e.Bounds.Left + 3, e.Bounds.Top + 3, 29, e.Bounds.Height - 6)

        'Draw the name of the color
        e.Graphics.DrawString(DirectCast(ComboBox3.Items(e.Index), String), ComboBox3.Font, Brushes.Black, 35, e.Bounds.Top + 2)

    End Sub
    Private Sub ComboBox4_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox4.DrawItem
        'Drawing the itemsinto the combobox.

        'exit if there is no item
        If e.Index = -1 Then
            Exit Sub
        End If


        'declare a colorbrush
        Dim sysBrush As Brush = New SolidBrush(Color.FromName(DirectCast(ComboBox4.Items(e.Index), String)))

        'Drawing rectangles for the color values
        e.Graphics.DrawRectangle(New Pen(Brushes.Black), e.Bounds.Left + 2, e.Bounds.Top + 2, 30, e.Bounds.Height - 5)
        e.Graphics.FillRectangle(sysBrush, e.Bounds.Left + 3, e.Bounds.Top + 3, 29, e.Bounds.Height - 6)

        'Draw the name of the color
        e.Graphics.DrawString(DirectCast(ComboBox4.Items(e.Index), String), ComboBox4.Font, Brushes.Black, 35, e.Bounds.Top + 2)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Get the selected color name from the ComboBox
        Dim selectedColorName As String = DirectCast(ComboBox1.SelectedItem, String)

        ' Use Color.FromName to get the Color object for the selected color name
        Dim selectedColor As Color = Color.FromName(selectedColorName)

        ' Set the background color of Panel3 to the selected color
        Panel1.BackColor = selectedColor
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Get the selected color name from the ComboBox
        Dim selectedColorName As String = DirectCast(ComboBox2.SelectedItem, String)

        ' Use Color.FromName to get the Color object for the selected color name
        Dim selectedColor As Color = Color.FromName(selectedColorName)

        ' Set the background color of Panel3 to the selected color
        Panel2.BackColor = selectedColor
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ' Get the selected color name from the ComboBox
        Dim selectedColorName As String = DirectCast(ComboBox3.SelectedItem, String)

        ' Use Color.FromName to get the Color object for the selected color name
        Dim selectedColor As Color = Color.FromName(selectedColorName)

        ' Set the background color of Panel3 to the selected color
        Panel4.BackColor = selectedColor
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ' Get the selected color name from the ComboBox
        Dim selectedColorName As String = DirectCast(ComboBox4.SelectedItem, String)

        ' Use Color.FromName to get the Color object for the selected color name
        Dim selectedColor As Color = Color.FromName(selectedColorName)

        ' Set the background color of Panel3 to the selected color
        Panel10.BackColor = selectedColor
    End Sub
    Private Sub cmbSysColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSysColor.SelectedIndexChanged
        ' Get the selected color name from the ComboBox
        Dim selectedColorName As String = DirectCast(cmbSysColor.SelectedItem, String)

        ' Use Color.FromName to get the Color object for the selected color name
        Dim selectedColor As Color = Color.FromName(selectedColorName)

        ' Set the background color of Panel3 to the selected color
        Panel3.BackColor = selectedColor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With My.Settings
            .primaryColor = Color.FromArgb(0, 0, 0)
            .secondaryColor = Color.FromArgb(255, 0, 0)
            .defaultColor = Color.FromArgb(0, 0, 0)
            .homeColor = Color.FromArgb(0, 0, 139)
            .foreColor = Color.White
            .Save()
        End With
        AllFunctions.getTheme()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            PictureBox3.Image = My.Resources._ON
        Else
            PictureBox3.Image = My.Resources.off
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If CheckBox2.Checked = True Then
            CheckBox2.Checked = False
            GroupBox3.Enabled = False
            My.Settings.useTheme = True
            My.Settings.Save()
        Else
            CheckBox2.Checked = True
            GroupBox3.Enabled = True
            My.Settings.useTheme = True
            My.Settings.Save()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With My.Settings
            .primaryColor = Panel3.BackColor
            .secondaryColor = Panel2.BackColor
            .defaultColor = Panel1.BackColor
            .homeColor = Panel4.BackColor
            .foreColor = Panel10.BackColor
            .Save()
        End With
        AllFunctions.getTheme()
    End Sub

    Private Sub ChangeLabelForeColors(ByVal newColor As Color)
        For Each control As Control In Me.Controls
            If TypeOf control Is Label Then
                Dim labelControl As Label = DirectCast(control, Label)
                labelControl.ForeColor = newColor
            End If
        Next
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
End Class

