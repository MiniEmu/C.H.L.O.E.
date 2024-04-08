<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSVEditorForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DataGridView1 = New DataGridView()
        AddRowButton = New Button()
        DeleteRowButton = New Button()
        SaveButton = New Button()
        CancelButton1 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(11, 16)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(777, 307)
        DataGridView1.TabIndex = 0
        ' 
        ' AddRowButton
        ' 
        AddRowButton.Location = New Point(25, 337)
        AddRowButton.Name = "AddRowButton"
        AddRowButton.Size = New Size(75, 23)
        AddRowButton.TabIndex = 1
        AddRowButton.Text = "Add Row"
        AddRowButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteRowButton
        ' 
        DeleteRowButton.Location = New Point(106, 337)
        DeleteRowButton.Name = "DeleteRowButton"
        DeleteRowButton.Size = New Size(75, 23)
        DeleteRowButton.TabIndex = 2
        DeleteRowButton.Text = "Delete Row"
        DeleteRowButton.UseVisualStyleBackColor = True
        ' 
        ' SaveButton
        ' 
        SaveButton.Location = New Point(187, 337)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(75, 23)
        SaveButton.TabIndex = 3
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' CancelButton1
        ' 
        CancelButton1.Location = New Point(268, 337)
        CancelButton1.Name = "CancelButton1"
        CancelButton1.Size = New Size(75, 23)
        CancelButton1.TabIndex = 4
        CancelButton1.Text = "Cancel"
        CancelButton1.UseVisualStyleBackColor = True
        ' 
        ' CSVEditorForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 369)
        Controls.Add(CancelButton1)
        Controls.Add(SaveButton)
        Controls.Add(DeleteRowButton)
        Controls.Add(AddRowButton)
        Controls.Add(DataGridView1)
        Name = "CSVEditorForm"
        Text = "System Configuration"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents AddRowButton As Button
    Friend WithEvents DeleteRowButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents CancelButton1 As Button
End Class
