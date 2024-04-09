Imports System.IO
Public Class CSVEditorForm
    ' Define a DataTable to store the CSV data
    Public csvDataTable As New DataTable()

    Private Sub CSVEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load CSV data into the DataGridView
        ' Assuming your CSV data is stored in SystemInfo array


        For i As Integer = 0 To My.MyApplication.SystemInfo.GetLength(1) - 2 ' Adjust loop to exclude the 8th column
            csvDataTable.Columns.Add("Column " & (i + 1))
        Next

        For i As Integer = 1 To My.MyApplication.SystemInfo.GetLength(0) - 1 ' Start from 1 to skip header row
            Dim rowData(My.MyApplication.SystemInfo.GetLength(1) - 2) As String ' Adjust array size to match the number of columns
            ' Extract values from SystemInfo row and store in rowData array
            For j As Integer = 0 To My.MyApplication.SystemInfo.GetLength(1) - 2 ' Adjust loop to exclude the 8th column
                rowData(j) = My.MyApplication.SystemInfo(i, j)
            Next

            ' Add rowData array to the DataTable
            csvDataTable.Rows.Add(rowData)
        Next

        DataGridView1.DataSource = csvDataTable
        DataGridView1.Columns(0).HeaderText = "System Name"
        DataGridView1.Columns(1).HeaderText = "Arguments"
        DataGridView1.Columns(2).HeaderText = "Emu Path"
        DataGridView1.Columns(3).HeaderText = "Emu EXE"
        DataGridView1.Columns(4).HeaderText = "System Image"
        DataGridView1.Columns(5).HeaderText = "Rom Path"
        DataGridView1.Columns(6).HeaderText = "File Mask(s)"
    End Sub

    ' Add a new row to the DataGridView
    Private Sub AddRowButton_Click(sender As Object, e As EventArgs) Handles AddRowButton.Click
        csvDataTable.Rows.Add()
    End Sub

    ' Delete the selected row from the DataGridView
    Private Sub DeleteRowButton_Click(sender As Object, e As EventArgs) Handles DeleteRowButton.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim SysfilePath = Path.Combine(Application.StartupPath, "CHLOE_Systems.csv")
        Try
            ' Save changes to the CSV file
            Using writer As New StreamWriter(SysfilePath)
                ' Write the header row
                Dim headerRow As New List(Of String)
                For Each column As DataGridViewColumn In DataGridView1.Columns
                    headerRow.Add(column.HeaderText)
                Next
                writer.WriteLine(String.Join(",", headerRow))

                ' Write the data rows
                For Each dgvRow As DataGridViewRow In DataGridView1.Rows
                    Dim rowData As New List(Of String)
                    For Each cell As DataGridViewCell In dgvRow.Cells
                        If cell.Value IsNot Nothing Then
                            rowData.Add(cell.Value.ToString())
                        Else
                            rowData.Add("") ' Empty cell if value is Nothing
                        End If
                    Next
                    writer.WriteLine(String.Join(",", rowData))
                Next
            End Using

            ' Clear and repopulate the array from the newly saved CSV file
            If File.Exists(SysfilePath) Then
                Dim FileReader As String() = File.ReadAllLines(SysfilePath)

                ' Clear the array and reallocate memory
                ReDim My.MyApplication.SystemInfo(FileReader.Length - 2, 7)

                ' Populate remaining rows
                For i As Integer = 1 To FileReader.Length - 1
                    Dim FileLine() = FileReader(i).Split(","c)
                    For j As Integer = 0 To FileLine.Length - 1
                        My.MyApplication.SystemInfo(i - 1, j) = FileLine(j).Trim()
                    Next
                Next
            End If

            ' Close the form
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel editing and close the form
    Private Sub CancelButton1_Click(sender As Object, e As EventArgs) Handles CancelButton1.Click
        ' Close the form without saving changes
        Me.Close()
    End Sub
End Class

