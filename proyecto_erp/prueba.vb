Public Class prueba
    Private Sub prueba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Ds_usuarios.Usuarios' Puede moverla o quitarla según sea necesario.
        Me.UsuariosTableAdapter.Fill(Me.Ds_usuarios.Usuarios)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class