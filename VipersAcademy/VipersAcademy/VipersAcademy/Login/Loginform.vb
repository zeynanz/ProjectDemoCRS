Imports System.Data.OleDb
Imports System.Data

Public Class Loginform


    Dim connection As New OleDbConnection(My.Settings.LoginConnectionString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            MsgBox("Enter Credentials ", MsgBoxStyle.Exclamation)
        Else
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd As New OleDbCommand("select count(*) from login where Username =? and Password =?", connection)
            cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.AddWithValue("@2", OleDbType.VarChar).Value = TextBox2.Text
            Dim count = Convert.ToInt32(cmd.ExecuteScalar())

            If (count > 0) Then
                MsgBox("Login Succeed", MsgBoxStyle.Information)
            Else
                MsgBox("Account not found check credentials", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

End Class