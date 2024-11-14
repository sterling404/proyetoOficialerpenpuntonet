Imports System.Data.SqlClient

Public Class usuario
    Private idPerfil As Integer
    Public Sub New(idPerfil As Integer)
        InitializeComponent()
        Me.idPerfil = idPerfil
    End Sub

    Public Sub CrearUsuario(nombreUsuario As String, contraseña As String, perfilId As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "INSERT INTO Usuarios (nombre_usuario, contraseña, id_perfil) VALUES (@NombreUsuario, @Contraseña, @PerfilId)"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@NombreUsuario", nombreUsuario),
            New SqlParameter("@Contraseña", contraseña),
            New SqlParameter("@PerfilId", perfilId)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub EliminarUsuario(idUsuario As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "DELETE FROM Usuarios WHERE id_usuario = @IdUsuario"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@IdUsuario", idUsuario)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub ActualizarUsuario(idUsuario As Integer, nombreUsuario As String, contraseña As String, perfilId As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "UPDATE Usuarios SET nombre_usuario = @NombreUsuario, contraseña = @Contraseña, id_perfil = @PerfilId WHERE id_usuario = @IdUsuario"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@NombreUsuario", nombreUsuario),
            New SqlParameter("@Contraseña", contraseña),
            New SqlParameter("@PerfilId", perfilId),
            New SqlParameter("@IdUsuario", idUsuario)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Public Function ObtenerUsuarios() As DataTable
        Dim db As New DatabaseHelper()
        Dim query As String = "SELECT id_usuario, nombre_usuario, id_perfil FROM Usuarios"
        Return db.ExecuteQuery(query)
    End Function

    Private Sub CargarUsuarios()
        Dim usuarios As DataTable = ObtenerUsuarios()
        DataGridView1.DataSource = usuarios
    End Sub

    Private Sub usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nombreUsuario As String = TextBox1.Text
        Dim contraseña As String = TextBox2.Text
        Dim perfilId As Integer = Integer.Parse(TextBox4.Text)

        CrearUsuario(nombreUsuario, contraseña, perfilId)
        MessageBox.Show("Usuario creado correctamente.")
        CargarUsuarios()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim idUsuario As Integer = Integer.Parse(TextBox3.Text)
        Dim nombreUsuario As String = TextBox1.Text
        Dim contraseña As String = TextBox2.Text
        Dim perfilId As Integer = Integer.Parse(TextBox4.Text)

        ActualizarUsuario(idUsuario, nombreUsuario, contraseña, perfilId)
        MessageBox.Show("Usuario actualizado correctamente.")
        CargarUsuarios()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idUsuario As Integer = Integer.Parse(TextBox3.Text)

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            EliminarUsuario(idUsuario)
            MessageBox.Show("Usuario eliminado correctamente.")
            CargarUsuarios()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim mainForm As New MainForm(idPerfil)
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox3.Text = filaSeleccionada.Cells("id_usuario").Value.ToString()
            TextBox1.Text = filaSeleccionada.Cells("nombre_usuario").Value.ToString()
            TextBox4.Text = filaSeleccionada.Cells("id_perfil").Value.ToString()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class



'Imports System.Data.SqlClient

'Public Class usuario
'    Private idPerfil As Integer
'    Public Sub New(idPerfil As Integer)
'        InitializeComponent() ' Inicializa los componentes del formulario
'        Me.idPerfil = idPerfil ' Guarda el idPerfil en la variable privada
'    End Sub
'    Public Sub CrearUsuario(nombreUsuario As String, contraseña As String, perfilId As Integer)
'        Dim db As New DatabaseHelper()
'        Dim query As String = "INSERT INTO Usuarios (nombre_usuario, contraseña, id_perfil) VALUES (@NombreUsuario, @Contraseña, @PerfilId)"
'        Dim parameters As SqlParameter() = {
'        New SqlParameter("@NombreUsuario", nombreUsuario),
'        New SqlParameter("@Contraseña", contraseña),
'        New SqlParameter("@PerfilId", perfilId)
'    }
'        db.ExecuteNonQuery(query, parameters)
'    End Sub
'    Public Sub EliminarUsuario(idUsuario As Integer)
'        Dim db As New DatabaseHelper()
'        Dim query As String = "DELETE FROM Usuarios WHERE id_usuario = @IdUsuario"
'        Dim parameters As SqlParameter() = {
'        New SqlParameter("@IdUsuario", idUsuario)
'    }
'        db.ExecuteNonQuery(query, parameters)
'    End Sub

'    Public Sub ActualizarUsuario(idUsuario As Integer, nombreUsuario As String, contraseña As String, perfilId As Integer)
'        Dim db As New DatabaseHelper()
'        Dim query As String = "UPDATE Usuarios SET nombre_usuario = @NombreUsuario, contraseña = @Contraseña, id_perfil = @PerfilId WHERE id_usuario = @IdUsuario"
'        Dim parameters As SqlParameter() = {
'        New SqlParameter("@NombreUsuario", nombreUsuario),
'        New SqlParameter("@Contraseña", contraseña),
'        New SqlParameter("@PerfilId", perfilId),
'        New SqlParameter("@IdUsuario", idUsuario)
'    }
'        db.ExecuteNonQuery(query, parameters)
'    End Sub

'    Public Function ObtenerUsuarios() As DataTable
'        Dim db As New DatabaseHelper()
'        Dim query As String = "SELECT id_usuario, nombre_usuario, id_perfil FROM Usuarios"
'        Return db.ExecuteQuery(query)
'    End Function

'    Private Sub CargarUsuarios()
'        Dim db As New DatabaseHelper()
'        Dim usuarios As DataTable = db.ExecuteQuery("SELECT id_usuario, nombre_usuario, id_perfil FROM Usuarios")
'        DataGridView1.DataSource = usuarios
'    End Sub

'    Private Sub usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        CargarUsuarios()
'    End Sub

'    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
'        Dim nombreUsuario As String = TextBox1.Text
'        Dim contraseña As String = TextBox2.Text
'        Dim perfilId As Integer = Integer.Parse(TextBox4.Text) ' Asumiendo que el ID de perfil está en un TextBox

'        CrearUsuario(nombreUsuario, contraseña, perfilId)
'        MessageBox.Show("Usuario creado correctamente.")
'        CargarUsuarios() ' Actualizar el DataGridView después de agregar un usuario
'    End Sub

'    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

'    End Sub

'    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

'    End Sub

'    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

'    End Sub

'    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

'    End Sub

'    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
'        Dim idUsuario As Integer = Integer.Parse(TextBox3.Text) ' Asumiendo que el ID del usuario está en un TextBox
'        Dim nombreUsuario As String = TextBox1.Text
'        Dim contraseña As String = TextBox2.Text
'        Dim perfilId As Integer = Integer.Parse(TextBox4.Text) ' Asumiendo que el ID del perfil está en un TextBox

'        ActualizarUsuario(idUsuario, nombreUsuario, contraseña, perfilId)
'        MessageBox.Show("Usuario actualizado correctamente.")
'        CargarUsuarios()
'    End Sub

'    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

'    End Sub

'    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

'    End Sub

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        Dim idUsuario As Integer = Integer.Parse(TextBox3.Text) ' Asumiendo que el ID del usuario está en un TextBox

'        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo)
'        If result = DialogResult.Yes Then
'            EliminarUsuario(idUsuario)
'            MessageBox.Show("Usuario eliminado correctamente.")
'            CargarUsuarios() ' Actualiza el DataGridView después de eliminar un usuario
'        End If
'    End Sub

'    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
'        Dim mainForm As New MainForm(idPerfil) ' Pasa el idPerfil al constructor
'        mainForm.Show()
'        Me.Hide()
'    End Sub
'End Class