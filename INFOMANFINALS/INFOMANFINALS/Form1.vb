Imports MySql.Data.MySqlClient
Public Class Form1
    Dim mycon As New dbconn
    Dim obadapter As New MySqlDataAdapter
    Dim dtable As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        obadapter = New MySqlDataAdapter("Select USERNAME,PASSWORD from tbl_sign_in Where USERNAME = '" & TextBoxus.Text & "' And PASSWORD = '" & TextBoxps.Text & "'", mycon.open)
        dtable.Clear()
        obadapter.Fill(dtable)
        If dtable.Rows.Count = Nothing Then
            MsgBox("PLEASE ENTER VALID USERNAME & PASWORD")
        Else
            MsgBox("CONNECTED")
            dataform.Show()
            Me.Hide()
            mycon.close()
        End If
        mycon.close()
    End Sub

    Private Sub SIGNUP_Click(sender As Object, e As EventArgs) Handles SIGNUP.Click
        signupform.Show()
        Me.Hide()
        mycon.close()
    End Sub
End Class
