Imports MySql.Data.MySqlClient
Public Class dbconn

    Dim con As New MySqlConnection("server=localhost;username=root;password=;database=barangaydata")

    Public Function open() As MySqlConnection
        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return con
    End Function

    Public Function close() As MySqlConnection
        Try
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return con
    End Function

End Class
