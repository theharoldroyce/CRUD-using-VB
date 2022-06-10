Imports MySql.Data.MySqlClient
Public Class signupform
    Dim condd As New MySqlCommand
    Dim myconti As New dbconn
    Dim datatable As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If TextID.Text = "" Or TextNAME.Text = "" Or TextDEPT.Text = "" Or TextUSNAME.Text = "" Or TextPASS.Text = "" Then
                MessageBox.Show("ALL FIELD ARE REQUIRED", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                condd.Connection = myconti.open
                condd.CommandText = "insert into tbl_sign_in(ID_NUMBER,NAME,DEPARTMENT,USERNAME,PASSWORD) values ('" & TextID.Text & "','" & TextNAME.Text & "','" & TextDEPT.Text & "','" & TextUSNAME.Text & "','" & TextPASS.Text & "')"
                condd.ExecuteNonQuery()
                myconti.close()
                MsgBox("SUCCESFULY ADDED",)
                Form1.Show()
                Me.Hide()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class