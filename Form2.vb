Imports MySql.Data.MySqlClient

Public Class Form2
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Call Connect_to_DB()
        Dim mycmd As New MySqlCommand

        Dim commandText As String = "SELECT product_name, price from products"
        Dim command As MySqlCommand = New MySqlCommand(commandText, myconn)

        Dim reader As MySqlDataReader = command.ExecuteReader()
        Dim productName As String = ""
        Dim productPrice As Decimal = 0
        Dim i As Integer = 0
        While reader.Read()
            productName = reader.GetString("product_name")
            productPrice = reader.GetDecimal("price")
            Dim checkbox As New CheckBox()
            checkbox.Text = productName & " - P" & productPrice.ToString()
            checkbox.Size = New Size(500, 36)
            checkbox.Location = New Point(10, i * 30)
            i += 1
            Panel1.Controls.Add(checkbox)
        End While

        Call Disconnect_to_DB()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        Form1.Show()
    End Sub
End Class