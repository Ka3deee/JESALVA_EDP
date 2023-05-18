Imports System.Data.SqlClient
Imports System.Windows
Imports mysql.data.MySqlClient

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Me
            Call Connect_to_DB()
            Dim mycmd As New MySqlCommand
            Dim myreader As MySqlDataReader


            strSQL = "Select * from customer where customer_name = '" _
                & .username.Text & "' and password = '" _
                & .password.Text & "'"
            'MsgBox(strSQL)
            mycmd.CommandText = strSQL
            mycmd.Connection = myconn

            Dim userType As String = ""

            myreader = mycmd.ExecuteReader
            If myreader.HasRows Then
                myreader.Read()
                userType = myreader.GetString("user_type")
                .Hide()
            Else
                MessageBox.Show("Invalid username or password")
            End If
            Call Disconnect_to_DB()

            If userType = "admin" Then
                Form4.Show()
            ElseIf userType = "customer" Then
                Form2.Show()
            End If
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form3.Show()
    End Sub

End Class
