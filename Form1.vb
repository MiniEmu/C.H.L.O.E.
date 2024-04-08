Imports System.IO

Public Class CHLOEMain
    REM   Public My.MyApplication.SystemInfo(,) As String
    Public selectedSystem As String
    Private Sub GetFileList_Click(sender As Object, e As EventArgs) Handles GetFileList.Click

        SelectRom.InitialDirectory = RomPath.Text
        SelectRom.Filter = FileMask.Text
        SelectRom.FileName = ""
        SelectRom.ShowDialog()

    End Sub

    Private Sub SelectRom_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SelectRom.FileOk
        SelectedRom.Text = SelectRom.FileName
        For i As Integer = 1 To My.MyApplication.SystemInfo.GetLength(0) - 1 ' Start from 1 to skip header row
            If My.MyApplication.SystemInfo(i, 0) = selectedSystem Then
                ' Populate Textboxes with values from the corresponding row
                EmuArgs.Text = My.MyApplication.SystemInfo(i, 1)
                EmuPath.Text = My.MyApplication.SystemInfo(i, 2)
                EmuExe.Text = My.MyApplication.SystemInfo(i, 3)
                RomPath.Text = My.MyApplication.SystemInfo(i, 5)
                FileMask.Text = My.MyApplication.SystemInfo(i, 6)
                Exit For ' Exit the loop once the system is found
            End If
        Next
        Dim LaunchCodes As String
        REM  LaunchCodes = "pv2000 -cart " & SelectedRom.Text
        Dim SelRom As String = """" & SelectedRom.Text & """"
        LaunchCodes = Replace(EmuArgs.Text, "${RomName}", SelRom)
        EmuArgs.Text = LaunchCodes
        LaunchButton.Enabled = True
    End Sub

    Private Sub LaunchButton_Click(sender As Object, e As EventArgs) Handles LaunchButton.Click
        Try
            Dim Emulator As New ProcessStartInfo
            Emulator.WorkingDirectory = EmuPath.Text
            Emulator.FileName = EmuExe.Text
            Emulator.Arguments = EmuArgs.Text
            Emulator.UseShellExecute = True
            Emulator.WindowStyle = ProcessWindowStyle.Normal
            Dim proc As Process = Process.Start(Emulator)

            If proc IsNot Nothing Then
                Dim pid As Integer = proc.Id
                REM   MessageBox.Show("The PID of the launched process is: " & pid.ToString(), "Process ID", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Throw New Exception("Failed to start the process.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error launching the program: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CHLOEMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        REM CHLOE_Systems.csv
        REM 1-System Name	2-Arguments	3-Emulator path	4-Emulator EXE	5-System Image 6-ROM Path	7-File Mask(s)

        If File.Exists("D:\CHLOE\CHLOE_Systems.csv") Then
            Dim FileReader As String() = File.ReadAllLines("D:\CHLOE\CHLOE_Systems.csv")

            ' Initialize My.MyApplication.SystemInfo array with dimensions matching the CSV file
            ReDim Preserve My.MyApplication.SystemInfo(FileReader.Length - 1, 7)

            ' Populate header row
            Dim headerRow = FileReader(0).Split(","c)
            For j As Integer = 0 To headerRow.Length - 1
                My.MyApplication.SystemInfo(0, j) = headerRow(j).Trim()
            Next

            ' Populate remaining rows
            For i As Integer = 1 To FileReader.Length - 1
                Dim FileLine() = FileReader(i).Split(","c)
                For j As Integer = 0 To FileLine.Length - 1
                    My.MyApplication.SystemInfo(i, j) = FileLine(j).Trim()
                Next
            Next

            ' Populate ComboBox with System Names
            For i As Integer = 1 To FileReader.Length - 1 ' Start from 1 to skip header row
                SystemPicker.Items.Add(My.MyApplication.SystemInfo(i, 0))
            Next
        End If
    End Sub


    Private Sub SystemPicker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SystemPicker.SelectedIndexChanged
        ' Get the selected system name from the ComboBox
        selectedSystem = SystemPicker.SelectedItem.ToString()
        ' Variable to store the index of the selected system
        Dim selectedIndex As Integer = -1
        SysImage.Image = Nothing

        ' Search for the selected system in the My.MyApplication.SystemInfo array
        For i As Integer = 1 To My.MyApplication.SystemInfo.GetLength(0) - 1 ' Start from 1 to skip header row
            If My.MyApplication.SystemInfo(i, 0) = selectedSystem Then
                ' Store the index of the selected system
                selectedIndex = i
                ' Populate Textboxes with values from the corresponding row
                EmuArgs.Text = My.MyApplication.SystemInfo(i, 1)
                EmuPath.Text = My.MyApplication.SystemInfo(i, 2)
                EmuExe.Text = My.MyApplication.SystemInfo(i, 3)
                RomPath.Text = My.MyApplication.SystemInfo(i, 5)
                FileMask.Text = My.MyApplication.SystemInfo(i, 6)
                Exit For ' Exit the loop once the system is found
            End If
        Next
        ' Check if a valid index was found for the selected system
        If selectedIndex <> -1 Then
            ' Check if System Image is not NULL and points to an existing image file
            Dim imagePath As String = My.MyApplication.SystemInfo(selectedIndex, 4)
            If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                ' Display the system image in the PictureBox
                SysImage.Image = Image.FromFile(imagePath)
            Else
                ' Clear the PictureBox if no valid image is found
                SysImage.Image = Nothing
            End If
        End If
        SelectedRom.Text = ".........."
        GetFileList.Enabled = True
        LaunchButton.Enabled = False
    End Sub

    Private Sub SysEditButton_Click(sender As Object, e As EventArgs) Handles SysEditButton.Click
        ' Create and show the CSV editor form
        Dim editorForm As New CSVEditorForm()
        editorForm.ShowDialog()
    End Sub
End Class
