Imports System.Data.SqlClient

Public Class accesos
    Private idPerfil As Integer
    Public Sub New(idPerfil As Integer)
        InitializeComponent()
        Me.idPerfil = idPerfil
    End Sub

    Public Sub AgregarAcceso(idPerfil As Integer, idPantalla As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "INSERT INTO Accesos (id_perfil, id_pantalla) VALUES (@IdPerfil, @IdPantalla)"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@IdPerfil", idPerfil),
            New SqlParameter("@IdPantalla", idPantalla)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Private Sub CargarAccesos()
        Dim accesos As DataTable = ObtenerAccesos()
        DataGridView1.DataSource = accesos
    End Sub

    Public Function ObtenerAccesos() As DataTable
        Dim db As New DatabaseHelper()
        Dim query As String = "SELECT a.id_acceso, a.id_perfil, a.id_pantalla " &
                              "FROM Accesos a " &
                              "JOIN Perfiles p ON a.id_perfil = p.id_perfil " &
                              "JOIN Pantallas pn ON a.id_pantalla = pn.id_pantalla"
        Return db.ExecuteQuery(query)
    End Function

    Public Sub ActualizarAcceso(idAcceso As Integer, idPerfil As Integer, idPantalla As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "UPDATE Accesos SET id_perfil = @IdPerfil, id_pantalla = @IdPantalla WHERE id_acceso = @IdAcceso"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@IdAcceso", idAcceso),
            New SqlParameter("@IdPerfil", idPerfil),
            New SqlParameter("@IdPantalla", idPantalla)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub EliminarAcceso(idAcceso As Integer)
        Dim db As New DatabaseHelper()
        Dim query As String = "DELETE FROM Accesos WHERE id_acceso = @IdAcceso"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@IdAcceso", idAcceso)
        }
        db.ExecuteNonQuery(query, parameters)
    End Sub

    Private Sub accesos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarAccesos()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim idPerfil As Integer = Integer.Parse(TextBox1.Text)
        Dim idPantalla As Integer = Integer.Parse(TextBox2.Text)

        AgregarAcceso(idPerfil, idPantalla)
        MessageBox.Show("Acceso agregado correctamente.")
        CargarAccesos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim idAcceso As Integer = Integer.Parse(TextBox3.Text)
        Dim idPerfil As Integer = Integer.Parse(TextBox1.Text)
        Dim idPantalla As Integer = Integer.Parse(TextBox2.Text)

        ActualizarAcceso(idAcceso, idPerfil, idPantalla)
        MessageBox.Show("Acceso actualizado correctamente.")
        CargarAccesos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idAcceso As Integer = Integer.Parse(TextBox3.Text)

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este acceso?", "Confirmar Eliminación", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            EliminarAcceso(idAcceso)
            MessageBox.Show("Acceso eliminado correctamente.")
            CargarAccesos()
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
            TextBox3.Text = filaSeleccionada.Cells("id_acceso").Value.ToString() ' ID del acceso
            TextBox1.Text = filaSeleccionada.Cells("id_perfil").Value.ToString()  ' ID del perfil
            TextBox2.Text = filaSeleccionada.Cells("id_pantalla").Value.ToString() ' ID de la pantalla
        End If
    End Sub
End Class

