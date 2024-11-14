<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnGestionarPerfiles = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnGestionarAccesos = New System.Windows.Forms.Button()
        Me.btnGestionarUsuarios = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(57, 87)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(767, 362)
        Me.DataGridView1.TabIndex = 0
        '
        'btnGestionarPerfiles
        '
        Me.btnGestionarPerfiles.Location = New System.Drawing.Point(853, 82)
        Me.btnGestionarPerfiles.Name = "btnGestionarPerfiles"
        Me.btnGestionarPerfiles.Size = New System.Drawing.Size(200, 50)
        Me.btnGestionarPerfiles.TabIndex = 1
        Me.btnGestionarPerfiles.Text = "GESTINAR DE PERFILES"
        Me.btnGestionarPerfiles.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(853, 301)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 56)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "CERRAR SESSION "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnGestionarAccesos
        '
        Me.btnGestionarAccesos.Location = New System.Drawing.Point(853, 138)
        Me.btnGestionarAccesos.Name = "btnGestionarAccesos"
        Me.btnGestionarAccesos.Size = New System.Drawing.Size(200, 53)
        Me.btnGestionarAccesos.TabIndex = 3
        Me.btnGestionarAccesos.Text = "GESTIONAR DE ACCESOS"
        Me.btnGestionarAccesos.UseVisualStyleBackColor = True
        '
        'btnGestionarUsuarios
        '
        Me.btnGestionarUsuarios.Location = New System.Drawing.Point(853, 197)
        Me.btnGestionarUsuarios.Name = "btnGestionarUsuarios"
        Me.btnGestionarUsuarios.Size = New System.Drawing.Size(200, 48)
        Me.btnGestionarUsuarios.TabIndex = 4
        Me.btnGestionarUsuarios.Text = "GESTIONAR DE USUARIOS"
        Me.btnGestionarUsuarios.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 563)
        Me.Controls.Add(Me.btnGestionarUsuarios)
        Me.Controls.Add(Me.btnGestionarAccesos)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnGestionarPerfiles)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnGestionarPerfiles As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnGestionarAccesos As Button
    Friend WithEvents btnGestionarUsuarios As Button
End Class
