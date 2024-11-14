Imports System.Data.SqlClient

Public Class MainForm
    Private idPerfil As Integer

    Public Sub New(idPerfil As Integer)
        InitializeComponent()
        Me.idPerfil = idPerfil
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarAccesos()
    End Sub

    Private Sub InicializarAccesos()
        Dim db As New DatabaseHelper()
        Dim query As String = "SELECT pn.nombre_pantalla FROM Accesos a " &
                              "JOIN Pantallas pn ON a.id_pantalla = pn.id_pantalla " &
                              "WHERE a.id_perfil = @IdPerfil"
        Dim parameters As SqlParameter() = {
            New SqlParameter("@IdPerfil", idPerfil)
        }

        Dim accesos As DataTable = db.ExecuteQuery(query, parameters)

        ' Cargar accesos en el DataGridView
        DataGridView1.DataSource = accesos

        ' Ocultar todos los botones inicialmente
        btnGestionarPerfiles.Visible = False
        btnGestionarAccesos.Visible = False
        btnGestionarUsuarios.Visible = False

        ' Mostrar botones según los accesos del usuario
        For Each row As DataRow In accesos.Rows
            Dim nombrePantalla As String = row("nombre_pantalla").ToString()

            Select Case nombrePantalla
                Case "Gestión de Perfiles"
                    btnGestionarPerfiles.Visible = True
                Case "Gestión de Accesos"
                    btnGestionarAccesos.Visible = True
                Case "Gestión de Usuarios"
                    btnGestionarUsuarios.Visible = True
            End Select
        Next
    End Sub

    Private Sub AGREGAR_Click(sender As Object, e As EventArgs) Handles btnGestionarPerfiles.Click
        Dim Perfiles As New perfilclas(idPerfil)
        Perfiles.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Login As New login()
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnGestionarAccesos.Click
        Dim Acccesos As New accesos(idPerfil)
        Acccesos.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnGestionarUsuarios.Click
        Dim Users As New usuario(idPerfil)
        Users.Show()
        Me.Hide()
    End Sub
End Class


