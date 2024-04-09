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
        Dim SysfilePath = Path.Combine(Application.StartupPath, "CHLOE_Systems.csv")
        If File.Exists(SysfilePath) Then

        Else
            ' Create the CSV file and populate it with the provided values
            Dim lines As New List(Of String)()

            ' Add the header line
            lines.Add("System Name,Arguments,Emu Path,Emu EXE,System Image,Rom Path,File Mask(s)")

            ' Add the data lines
            lines.Add("Casio Loopy,casloopy -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\CassioLoopy.png,D:\MAME\roms\casloopy,zip|*.zip|bin|*.bin")
            lines.Add("Aamber Pegasus,pegasus -rom1 ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\pegasus.png,D:\MAME\roms\pegasus,zip|*.zip|bin|*.bin")
            lines.Add("APF Imagination Machine,apfimag -cart basic -cass ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\apf_mp1000.png,D:\MAME\roms\apfimag_cass,zip|*.zip|wav|*.wav")
            lines.Add("Apogee BK-01,apogee -cass ${RomName},D:\MAME,mame.exe,Null,D:\MAME\roms\apogee,zip|*.zip|rka|*.rka")
            lines.Add("Casio PV-2000,pv2000 -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\pv1000.png,D:\MAME\roms\pv2000,zip|*.zip|bin|*.bin")
            lines.Add("Dragon Data Dragon,dragon64 -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\dragon32-64.png,D:\MAME\roms\dragon64,zip|*.zip|bin|*.bin")
            lines.Add("Interton VC 4000,vc4000 -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\VC4000.jpg,D:\MAME\roms\vc4000,zip|*.zip|bin|*.bin")
            lines.Add("Lviv PC-01,lviv -cass ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\lviv.png,D:\MAME\roms\lviv,zip|*.zip|lvX|*.lv*")
            lines.Add("Mattel Aquarius,aquarius -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\Aquarius.png,D:\MAME\roms\aquarius_cart,zip|*.zip|bin|*.bin")
            lines.Add("Philips VG 5000,vg5k -cass ${RomName},D:\MAME,mame.exe,Null,D:\MAME\roms\vg5k,zip|*.zip|k7|*.k7")
            lines.Add("VM Labs NUON,n501 -cart ${RomName},D:\MAME,mame.exe,Null,D:\MAME\roms\n501,zip|*.zip|iso|*.iso|cd|*.cd")
            lines.Add("Sega VMU,svmu -quik ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\svmu.png,D:\MAME\roms\svmu,zip|*.zip|vms|*.vms")
            lines.Add("APF M-1000,apfm1000 -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\apf_mp1000.png,D:\MAME\roms\apfm1000,zip|*.zip|bin|*.bin")
            lines.Add("Socrates,Socrates -cart ${RomName},D:\MAME,mame.exe,D:\CHLOE\Images\socrates.png,D:\MAME\roms\socrates,zip|*.zip|u1|*.u1")
            lines.Add("Nintendo 3DS,${RomName},D:\RetroBat\emulators\citra,citra-qt.exe,Null,D:\Arcade\collections\Nintendo 3DS\roms,zip|*.zip|7z|*.7z|3ds|*.3ds")

            ' Write the lines to the CSV file
            File.WriteAllLines(SysfilePath, lines)


        End If
        Dim FileReader As String() = File.ReadAllLines(SysfilePath)
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
