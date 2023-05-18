Imports System.IO
Imports System.Windows
Imports MySql.Data.MySqlClient

Public Class Form4
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            Call Connect_to_DB()
            Dim mycmd As New MySqlCommand

            Dim cmd As New MySqlCommand("SELECT * FROM products", myconn)
            Dim adapter As New MySqlDataAdapter(cmd)

            Dim ds As New DataSet()
            adapter.Fill(ds, "products")
            DataGridView1.DataSource = ds.Tables("products")
            Call Disconnect_to_DB()

        End With
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        Form5.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form6.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hide()
        Form7.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim backup As New SaveFileDialog
        backup.InitialDirectory = "C:\"
        backup.Title = "Database Backup"
        backup.CheckFileExists = False
        backup.CheckPathExists = False
        backup.DefaultExt = "sql"
        backup.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*"
        backup.RestoreDirectory = True

        If backup.ShowDialog = Windows.Forms.DialogResult.OK Then
            Call Connect_to_DB()
            Dim cmd As MySqlCommand = New MySqlCommand
            cmd.Connection = myconn
            Dim mb As MySqlBackup = New MySqlBackup(cmd)
            mb.ExportToFile(backup.FileName)
            myconn.Close()
            MessageBox.Show("Database Successfully Backup!", "BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf backup.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Return
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv"
        openFileDialog.ShowDialog()

        ' If the user selected a file, read it into a DataTable and bind it to the DataGridView.
        If openFileDialog.FileName <> "" Then
            Dim dt As New DataTable()
            Dim fileReader As New StreamReader(openFileDialog.FileName)
            Dim line As String = fileReader.ReadLine()
            Dim columns As String() = line.Split(",")
            For Each column As String In columns
                dt.Columns.Add(column.Trim())
            Next
            While Not fileReader.EndOfStream
                line = fileReader.ReadLine()
                Dim fields As String() = line.Split(",")
                dt.Rows.Add(fields)
            End While
            fileReader.Close()
            DataGridView2.DataSource = dt
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Form8.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
