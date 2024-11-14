Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatabaseHelper
    Private connectionString As String

    Public Sub New()
        ' Obtiene la cadena de conexión desde App.config
        connectionString = ConfigurationManager.ConnectionStrings("ERPConnectionString").ConnectionString
    End Sub

    ' Método para ejecutar comandos INSERT, UPDATE o DELETE
    Public Function ExecuteNonQuery(query As String, Optional parameters As SqlParameter() = Nothing) As Integer
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                connection.Open()
                Return command.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' Método para ejecutar consultas SELECT y devolver resultados en un DataTable
    Public Function ExecuteQuery(query As String, Optional parameters As SqlParameter() = Nothing) As DataTable
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                Using adapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    Return dataTable
                End Using
            End Using
        End Using
    End Function
End Class
