Imports MySql.Data.MySqlClient
Public Class PRINTFORM
    Dim myconectt As New dbconn
    Dim commandd As New MySqlCommand
    Dim ddtaa As New DataSet
    Dim tablee As New DataTable
    Dim adapterr As New MySqlDataAdapter
    Private Sub PRINTFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        commandd.Connection = myconectt.open
        myconectt.close()
        loadtable()

    End Sub
    Sub loadtable()

        Try
            commandd.Connection = myconectt.open
            commandd.CommandText = "Select * from vitamin2"
            adapterr.SelectCommand = commandd
            tablee.Clear()
            adapterr.Fill(tablee)
            DataGridView1.DataSource = tablee
            myconectt.close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        myconectt.close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imgbmp As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(imgbmp, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(imgbmp, 0, 0)
    End Sub
End Class