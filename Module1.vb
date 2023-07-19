Imports MySql.Data.MySqlClient
Module Module1
    Public cn As New MySqlConnection
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader

    Sub Connection()
        cn = New MySqlConnection
        With cn
            .ConnectionString = "server=localhost;user id=root;password=;database=poshumo1"
        End With
    End Sub
End Module
