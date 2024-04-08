<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CHLOEMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CHLOEMain))
        NameLabel = New Label()
        RomPath = New TextBox()
        FileMask = New TextBox()
        GetFileList = New Button()
        SelectRom = New OpenFileDialog()
        SelectedRom = New Label()
        LaunchButton = New Button()
        EmuPath = New TextBox()
        EmuExe = New TextBox()
        EmuArgs = New TextBox()
        SystemPicker = New ComboBox()
        SysImage = New PictureBox()
        SysEditButton = New Button()
        CType(SysImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' NameLabel
        ' 
        NameLabel.AutoSize = True
        NameLabel.Location = New Point(12, 9)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New Size(288, 15)
        NameLabel.TabIndex = 0
        NameLabel.Text = "Computerized Helper to Load Omnifarious Emulators"
        ' 
        ' RomPath
        ' 
        RomPath.Location = New Point(33, 158)
        RomPath.Name = "RomPath"
        RomPath.ReadOnly = True
        RomPath.Size = New Size(323, 23)
        RomPath.TabIndex = 2
        RomPath.Text = "D:\MAME\roms\pv2000"
        ' 
        ' FileMask
        ' 
        FileMask.Location = New Point(33, 184)
        FileMask.Name = "FileMask"
        FileMask.ReadOnly = True
        FileMask.Size = New Size(323, 23)
        FileMask.TabIndex = 3
        FileMask.Text = "Zip|*.zip"
        ' 
        ' GetFileList
        ' 
        GetFileList.Enabled = False
        GetFileList.Location = New Point(362, 183)
        GetFileList.Name = "GetFileList"
        GetFileList.Size = New Size(75, 23)
        GetFileList.TabIndex = 1
        GetFileList.Text = "&Pick File"
        GetFileList.UseVisualStyleBackColor = True
        ' 
        ' SelectRom
        ' 
        SelectRom.AddExtension = False
        SelectRom.AddToRecent = False
        SelectRom.CheckFileExists = False
        SelectRom.CheckPathExists = False
        SelectRom.Filter = "Zip files|*.zip"
        SelectRom.InitialDirectory = "c:\"
        SelectRom.OkRequiresInteraction = True
        SelectRom.Title = "Select ROM to launch."
        ' 
        ' SelectedRom
        ' 
        SelectedRom.AutoSize = True
        SelectedRom.Location = New Point(33, 212)
        SelectedRom.Name = "SelectedRom"
        SelectedRom.Size = New Size(37, 15)
        SelectedRom.TabIndex = 4
        SelectedRom.Text = ".........."
        ' 
        ' LaunchButton
        ' 
        LaunchButton.Enabled = False
        LaunchButton.Location = New Point(362, 232)
        LaunchButton.Name = "LaunchButton"
        LaunchButton.Size = New Size(104, 23)
        LaunchButton.TabIndex = 5
        LaunchButton.Text = "&Launch game!"
        LaunchButton.UseVisualStyleBackColor = True
        ' 
        ' EmuPath
        ' 
        EmuPath.Location = New Point(33, 73)
        EmuPath.Name = "EmuPath"
        EmuPath.ReadOnly = True
        EmuPath.Size = New Size(323, 23)
        EmuPath.TabIndex = 6
        EmuPath.Text = "D:\MAME"
        ' 
        ' EmuExe
        ' 
        EmuExe.Location = New Point(33, 102)
        EmuExe.Name = "EmuExe"
        EmuExe.ReadOnly = True
        EmuExe.Size = New Size(323, 23)
        EmuExe.TabIndex = 7
        EmuExe.Text = "mame.exe"
        ' 
        ' EmuArgs
        ' 
        EmuArgs.Location = New Point(32, 131)
        EmuArgs.Name = "EmuArgs"
        EmuArgs.Size = New Size(323, 23)
        EmuArgs.TabIndex = 8
        EmuArgs.Text = "pv2000 -cart ""${RomName}"""
        ' 
        ' SystemPicker
        ' 
        SystemPicker.DropDownWidth = 323
        SystemPicker.FormattingEnabled = True
        SystemPicker.Location = New Point(33, 39)
        SystemPicker.Name = "SystemPicker"
        SystemPicker.Size = New Size(322, 23)
        SystemPicker.TabIndex = 9
        ' 
        ' SysImage
        ' 
        SysImage.Location = New Point(369, 40)
        SysImage.Name = "SysImage"
        SysImage.Size = New Size(97, 85)
        SysImage.SizeMode = PictureBoxSizeMode.StretchImage
        SysImage.TabIndex = 10
        SysImage.TabStop = False
        ' 
        ' SysEditButton
        ' 
        SysEditButton.Location = New Point(33, 234)
        SysEditButton.Name = "SysEditButton"
        SysEditButton.Size = New Size(99, 23)
        SysEditButton.TabIndex = 11
        SysEditButton.Text = "Edit Systems"
        SysEditButton.UseVisualStyleBackColor = True
        ' 
        ' CHLOEMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(536, 269)
        Controls.Add(SysEditButton)
        Controls.Add(SysImage)
        Controls.Add(SystemPicker)
        Controls.Add(EmuArgs)
        Controls.Add(EmuExe)
        Controls.Add(EmuPath)
        Controls.Add(LaunchButton)
        Controls.Add(SelectedRom)
        Controls.Add(GetFileList)
        Controls.Add(FileMask)
        Controls.Add(RomPath)
        Controls.Add(NameLabel)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "CHLOEMain"
        Text = "C.H.L.O.E."
        CType(SysImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents NameLabel As Label
    Friend WithEvents RomPath As TextBox
    Friend WithEvents FileMask As TextBox
    Friend WithEvents GetFileList As Button
    Friend WithEvents SelectRom As OpenFileDialog
    Friend WithEvents SelectedRom As Label
    Friend WithEvents LaunchButton As Button
    Friend WithEvents EmuPath As TextBox
    Friend WithEvents EmuExe As TextBox
    Friend WithEvents EmuArgs As TextBox
    Friend WithEvents SystemPicker As ComboBox
    Friend WithEvents SysImage As PictureBox
    Friend WithEvents SysEditButton As Button

End Class
