Imports System.Data.SqlClient

Public Class login
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombreUsuario As String = TextBox1.Text
        Dim contraseña As String = TextBox2.Text


        ' Crea una instancia de DatabaseHelper sin Using
        Dim db As New DatabaseHelper()
        Dim query As String = "SELECT id_usuario, id_perfil FROM Usuarios WHERE nombre_usuario = @NombreUsuario AND contraseña = @Contraseña"
        Dim parameters As SqlParameter() = {
        New SqlParameter("@NombreUsuario", nombreUsuario),
        New SqlParameter("@Contraseña", contraseña)
    }

        ' Ejecuta la consulta
        Dim dt As DataTable = db.ExecuteQuery(query, parameters)

        ' Verifica si hay resultados
        If dt.Rows.Count > 0 Then
            Dim idPerfil As Integer = Convert.ToInt32(dt.Rows(0)("id_perfil"))

            ' Crear y abrir la ventana principal, pasando el idPerfil
            Dim mainForm As New MainForm(idPerfil)
            mainForm.Show()
            Me.Hide() ' Oculta el formulario de login
        Else
            MessageBox.Show("Nombre de usuario o contraseña incorrectos.")
        End If
    End Sub
End Class
