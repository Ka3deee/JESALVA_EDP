Imports MySql.Data.MySqlClient

Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles registerbtn.Click
        Call Connect_to_DB()
        Dim mycmd As New MySqlCommand

        Dim customer_name As String = usernametxt.Text
        Dim password As String = passwordtxt.Text
        Dim email As String = emailtxt.Text
        Dim address As String = addresstxt.Text

        Dim sql As String = "INSERT INTO customer (customer_name, password, email, address) VALUES (@customer_name, @password, @email, @address)"
        mycmd = New MySqlCommand(sql, myconn)

        mycmd.Parameters.AddWithValue("@customer_name", customer_name)
        mycmd.Parameters.AddWithValue("@password", password)
        mycmd.Parameters.AddWithValue("@email", email)
        mycmd.Parameters.AddWithValue("@address", address)
        mycmd.ExecuteNonQuery()
        MessageBox.Show("Account Successfully Created!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Call Disconnect_to_DB()
        Form1.Show()
        Hide()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form1.Show()
    End Sub

End Class