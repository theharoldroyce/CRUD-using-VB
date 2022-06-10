Imports MySql.Data.MySqlClient
Public Class dataform
    Dim myconect As New dbconn
    Dim command As New MySqlCommand
    Dim ddta As New DataSet
    Dim table As New DataTable
    Dim adapter As New MySqlDataAdapter


    Private Sub dataform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        command.Connection = myconect.open
        myconect.close()
        loadtable()
    End Sub

    Private Sub BTNADD_Click(sender As Object, e As EventArgs) Handles BTNADD.Click

        Try

            If TextCLD.Text = "" Or TextBDAY.Text = "" Or TextAGEM.Text = "" Or TextGEN.Text = "" Then
                MessageBox.Show("ALL FIELD ARE REQUIRED", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                command.Connection = myconect.open
                command.CommandText = "INSERT INTO vitamin2 (`NO`, `CHILDNAME`,`BDAY`,`AGE_MONTH`,`GENDER`) VALUES ('" & TextNO.Text & "','" & TextCLD.Text & "','" & TextBDAY.Text & "','" & TextAGEM.Text & "','" & TextGEN.Text & "')"
                command.ExecuteNonQuery()
                MsgBox("SUCCESSFULY ADDED RECORD")
                myconect.close()
                TextNO.Clear()
                TextCLD.Clear()
                TextBDAY.Clear()
                TextAGEM.Clear()
                TextGEN.Clear()
                loadtable()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextNO_TextChanged(sender As Object, e As EventArgs) Handles TextNO.TextChanged
        Try
            command.Connection = myconect.open
            command.CommandText = "Select * from vitamin2 Where NO='" & TextNO.Text & "'"
            adapter.SelectCommand = command
            ddta.Clear()
            adapter.Fill(ddta, "List")


            TextCLD.DataBindings.Add("text", ddta, "List.CHILDNAME")
            TextCLD.DataBindings.Clear()

            TextBDAY.DataBindings.Add("text", ddta, "List.BDAY")
            TextBDAY.DataBindings.Clear()

            TextAGEM.DataBindings.Add("text", ddta, "List.AGE_MONTH")
            TextAGEM.DataBindings.Clear()

            TextGEN.DataBindings.Add("text", ddta, "List.GENDER")
            TextGEN.DataBindings.Clear()

            If TextNO.Text = "" Then
                TextCLD.Clear()
                TextBDAY.Clear()
                TextAGEM.Clear()
                TextGEN.Clear()
            End If

            myconect.close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub loadtable()

        Try
            command.Connection = myconect.open
            command.CommandText = "Select * from vitamin2"
            adapter.SelectCommand = command
            table.Clear()
            adapter.Fill(table)
            DataGridView1.DataSource = table
            myconect.close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        myconect.close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextNO.Text = DataGridView1.Item("NO", DataGridView1.CurrentRow.Index).Value
        TextCLD.Text = DataGridView1.Item("CHILDNAME", DataGridView1.CurrentRow.Index).Value
        TextBDAY.Text = DataGridView1.Item("BDAY", DataGridView1.CurrentRow.Index).Value
        TextAGEM.Text = DataGridView1.Item("AGE_MONTH", DataGridView1.CurrentRow.Index).Value
        TextGEN.Text = DataGridView1.Item("GENDER", DataGridView1.CurrentRow.Index).Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNUPDATE.Click
        Try
            command.Connection = myconect.open
            command.CommandText = "UPDATE vitamin2 Set NO = '" & TextNO.Text & "', CHILDNAME = '" & TextCLD.Text & "', BDAY = '" & TextBDAY.Text & "', AGE_MONTH= '" & TextAGEM.Text & "', GENDER = '" & TextGEN.Text & "' WHERE NO = '" & TextNO.Text & "' "
            command.ExecuteNonQuery()
            myconect.close()
            MsgBox("SUCCESSFULY UPDATED RECORDS!")
            Call loadtable()
            TextNO.Clear()
            TextCLD.Clear()
            TextBDAY.Clear()
            TextAGEM.Clear()
            TextGEN.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myconect.close()
        End Try
    End Sub

    Private Sub BTNDELETE_Click(sender As Object, e As EventArgs) Handles BTNDELETE.Click
        Try
            Dim myconnd As New dbconn
            Dim obadapterd As New MySqlDataAdapter
            Dim dtabled As New DataTable
            obadapterd = New MySqlDataAdapter("Select PASSWORD from tbl_sign_in Where PASSWORD='ADMIN123'", myconnd.open)
            dtabled.Clear()
            obadapterd.Fill(dtabled)

            Dim adminpassword As String = dtabled.Rows(0).Item(0).ToString
            Dim userinput As String = InputBox("ENTER PASSWORD")

            If adminpassword = userinput Then
                command.Connection = myconect.open
                command.CommandText = "DELETE FROM vitamin2 WHERE NO = '" & TextNO.Text & "'"
                command.ExecuteNonQuery()
            Else
                MsgBox("INVALID PASSWORD", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
            myconect.close()
            TextNO.Clear()
            TextCLD.Clear()
            TextBDAY.Clear()
            TextAGEM.Clear()
            TextGEN.Clear()
            loadtable()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        myconect.close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim myconnd As New dbconn
        Dim obadapterd As New MySqlDataAdapter
        Dim dtabled As New DataTable
        obadapterd = New MySqlDataAdapter("Select PASSWORD from tbl_sign_in Where PASSWORD='ADMIN123'", myconnd.open)
        dtabled.Clear()
        obadapterd.Fill(dtabled)

        Dim adminpassword As String = dtabled.Rows(0).Item(0).ToString
        Dim useriput As String = InputBox("ENTER PASSWORD")

        If adminpassword = useriput Then
            FolderBrowserDialog1.ShowDialog()
            Dim path As String
            path = FolderBrowserDialog1.SelectedPath + "\mybackupfile.sql"
            Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "-u root barangaydata -r""" & path & """")
        Else
            MsgBox("INVALID PASSWORD", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End If
        myconnd.close()
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        PRINTFORM.Show()
        Me.Hide()
        myconect.open()
    End Sub
End Class