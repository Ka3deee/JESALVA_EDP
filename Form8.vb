Imports System.Data.Common
Imports Excel = Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient

Public Class Form8
    Public sqlColumns As String = "product_id as product_id, product_name as product_name, description as description, size as size, price as price"

    Private Sub Load_Data_to_Grid(ByVal strsql As String)
        Dim myreader As MySqlDataReader
        Dim mycommand As New MySqlCommand
        Dim mydataAdapter As New MySqlDataAdapter
        Dim mydatatable As New DataTable

        Connect_to_DB()
        With Me
            Try
                mycommand.Connection = myconn
                mycommand.CommandText = strsql
                myreader = mycommand.ExecuteReader
                mydatatable = New DataTable

                myreader.Close()
                mydataAdapter.SelectCommand = mycommand

                mydataAdapter.Fill(mydatatable)
                DataGridView1.AutoSize = True
                .DataGridView1.Refresh()
                .DataGridView1.EndEdit()
                .DataGridView1.DataSource = mydatatable
                .DataGridView1.ReadOnly = True
                .DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error on SQL query")
            End Try
            myreader = Nothing
            mycommand = Nothing
            Disconnect_to_DB()
        End With
    End Sub

    Private Sub frmDatagrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Data_to_Grid("select " & Me.sqlColumns & " from products")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call importToExcel(Me.DataGridView1, "reports.xlsx")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class