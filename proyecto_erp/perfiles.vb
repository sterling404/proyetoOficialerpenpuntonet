Imports System.Data.SqlClient

Public Class perfilclas
    Private idPerfil As Integer
    Public Sub New(idPerfil As Integer)
        InitializeComponent()
        Me.idPerfil = idPerfil
    End Sub

    Public Sub AgregarPerfil(nombre As String, descripcion As String)
        Dim db As New DatabaseHelper()
        Dim query As String = "INSERT INTO Perfiles (nombre, descripcion) VALUES (@Nombre, @Descripcion)"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Nombre", nombre),
            New SqlParameter("@Descripcion", descripcion)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Public Function ObtenerPerfiles() As DataTable
        Dim db As New DatabaseHelper()
        Dim query As String = "SELECT id_perfil, nombre, descripcion FROM Perfiles"
        Return db.ExecuteQuery(query)
    End Function

    Private Sub CargarPerfiles()
        Dim perfiles As DataTable = ObtenerPerfiles()
        DataGridView1.DataSource = perfiles
    End Sub

    Public Sub ActualizarPerfil(idPerfil As Integer, nombre As String, descripcion As String)
        Dim db As New DatabaseHelper()
        Dim query As String = "UPDATE Perfiles SET nombre = @Nombre, descripcion = @Descripcion WHERE id_perfil = @IdPerfil"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Nombre", nombre),
            New SqlParameter("@Descripcion", descripcion),
            New SqlParameter("@IdPerfil", idPerfil)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub EliminarPerfil(idPerfil As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "DELETE FROM Perfiles WHERE id_perfil = @IdPerfil"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@IdPerfil", idPerfil)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Private Sub perfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPerfiles()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nombre As String = TextBox1.Text
        Dim descripcion As String = TextBox2.Text

        AgregarPerfil(nombre, descripcion)
        MessageBox.Show("Perfil agregado correctamente.")
        CargarPerfiles()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim idPerfil As Integer = Integer.Parse(TextBox3.Text)
        Dim nombre As String = TextBox1.Text
        Dim descripcion As String = TextBox2.Text

        ActualizarPerfil(idPerfil, nombre, descripcion)
        MessageBox.Show("Perfil actualizado correctamente.")
        CargarPerfiles()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idPerfil As Integer = Integer.Parse(TextBox3.Text)

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este perfil?", "Confirmar Eliminación", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            EliminarPerfil(idPerfil)
            MessageBox.Show("Perfil eliminado correctamente.")
            CargarPerfiles()
        End If
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim mainForm As New MainForm(idPerfil)
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox3.Text = filaSeleccionada.Cells("id_perfil").Value.ToString()
            TextBox1.Text = filaSeleccionada.Cells("nombre").Value.ToString()
            TextBox2.Text = filaSeleccionada.Cells("descripcion").Value.ToString()
        End If
    End Sub
End Class




'Imports System.Data.SqlClient

'Public Class perfilclas
'    Private idPerfil As Integer
'    Public Sub New(idPerfil As Integer)
'        InitializeComponent() ' Inicializa los componentes del formulario
'        Me.idPerfil = idPerfil ' Guarda el idPerfil en la variable privada
'    End Sub
'    Public Sub AgregarPerfil(nombre As String, descripcion As String)
'        Dim db As New DatabaseHelper()
'        Dim query As String = "INSERT INTO Perfiles (nombre, descripcion) VALUES (@Nombre, @Descripcion)"
'        Dim parameters As SqlParameter() = {
'        New SqlParameter("@Nombre", nombre),
'        New SqlParameter("@Descripcion", descripcion)
'    }
'        db.ExecuteNonQuery(query, parameters)
'    End Sub
'    Public Function ObtenerPerfiles() As DataTable
'        Dim db As New DatabaseHelper()
'        Dim query As String = "SELECT id_perfil, nombre, descripcion FROM Perfiles"
'        Return db.ExecuteQuery(query)
'    End Function

'    Private Sub CargarPerfiles()
'        Dim db As New DatabaseHelper()
'        Dim perfiles As DataTable = ObtenerPerfiles()
'        DataGridView1.DataSource = perfiles
'    End Sub
'    Public Sub ActualizarPerfil(idPerfil As Integer, nombre As String, descripcion As String)
'        Dim db As New DatabaseHelper()
'        Dim query As String = "UPDATE Perfiles SET nombre = @Nombre, descripcion = @Descripcion WHERE id_perfil = @IdPerfil"
'        Dim parameters As SqlParameter() = {
'        New SqlParameter("@Nombre", nombre),
'        New SqlParameter("@Descripcion", descripcion),
'        New SqlParameter("@IdPerfil", idPerfil)
'    }
'        db.ExecuteNonQuery(query, parameters)
'    End Sub

'    Public Sub EliminarPerfil(idPerfil As Integer)
'        Dim db As New DatabaseHelper()
'        Dim query As String = "DELETE FROM Perfiles WHERE id_perfil = @IdPerfil"
'        Dim parameters As SqlParameter() = {
'        New SqlParameter("@IdPerfil", idPerfil)
'    }
'        db.ExecuteNonQuery(query, parameters)
'    End Sub

'    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

'    End Sub

'    Private Sub perfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load

'    End Sub

'    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
'        Dim nombre As String = TextBox1.Text
'        Dim descripcion As String = TextBox2.Text

'        AgregarPerfil(nombre, descripcion)
'        MessageBox.Show("Perfil agregado correctamente.")
'        CargarPerfiles()
'    End Sub

'    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
'        Dim idPerfil As Integer = Integer.Parse(TextBox3.Text) ' Asumiendo que el ID del perfil está en un TextBox
'        Dim nombre As String = TextBox1.Text
'        Dim descripcion As String = TextBox2.Text

'        ActualizarPerfil(idPerfil, nombre, descripcion)
'        MessageBox.Show("Perfil actualizado correctamente.")
'        CargarPerfiles()
'    End Sub

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        Dim idPerfil As Integer = Integer.Parse(TextBox3.Text) ' Asumiendo que el ID del perfil está en un TextBox

'        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este perfil?", "Confirmar Eliminación", MessageBoxButtons.YesNo)
'        If result = DialogResult.Yes Then
'            EliminarPerfil(idPerfil)
'            MessageBox.Show("Perfil eliminado correctamente.")
'            CargarPerfiles() ' Actualiza el DataGridView después de eliminar un perfil
'        End If
'    End Sub

'    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

'    End Sub

'    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

'    End Sub

'    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

'    End Sub

'    Private Sub Button4_Click(sender As Object, e As EventArgs)

'    End Sub

'    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
'        Dim mainForm As New MainForm(idPerfil) ' Pasa el idPerfil al constructor
'        mainForm.Show()
'        Me.Hide()
'    End Sub
'End Class