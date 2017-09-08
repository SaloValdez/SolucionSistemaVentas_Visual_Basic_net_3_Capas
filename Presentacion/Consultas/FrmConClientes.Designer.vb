<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConClientes
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxTexto = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RbRuc = New System.Windows.Forms.RadioButton()
        Me.RbNombre = New System.Windows.Forms.RadioButton()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TxTexto)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(727, 101)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles de Busqueda"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(441, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Reporte"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(441, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxTexto
        '
        Me.TxTexto.Location = New System.Drawing.Point(182, 45)
        Me.TxTexto.Name = "TxTexto"
        Me.TxTexto.Size = New System.Drawing.Size(253, 20)
        Me.TxTexto.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbRuc)
        Me.GroupBox2.Controls.Add(Me.RbNombre)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 74)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'RbRuc
        '
        Me.RbRuc.AutoSize = True
        Me.RbRuc.Location = New System.Drawing.Point(15, 43)
        Me.RbRuc.Name = "RbRuc"
        Me.RbRuc.Size = New System.Drawing.Size(45, 17)
        Me.RbRuc.TabIndex = 1
        Me.RbRuc.TabStop = True
        Me.RbRuc.Text = "Ruc"
        Me.RbRuc.UseVisualStyleBackColor = True
        '
        'RbNombre
        '
        Me.RbNombre.AutoSize = True
        Me.RbNombre.Location = New System.Drawing.Point(15, 20)
        Me.RbNombre.Name = "RbNombre"
        Me.RbNombre.Size = New System.Drawing.Size(62, 17)
        Me.RbNombre.TabIndex = 0
        Me.RbNombre.TabStop = True
        Me.RbNombre.Text = "Nombre"
        Me.RbNombre.UseVisualStyleBackColor = True
        '
        'Dg
        '
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg.Location = New System.Drawing.Point(22, 139)
        Me.Dg.Name = "Dg"
        Me.Dg.Size = New System.Drawing.Size(727, 182)
        Me.Dg.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(441, 69)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Listar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmConClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 355)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Dg)
        Me.Name = "FrmConClientes"
        Me.Text = "FrmConClientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxTexto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RbRuc As System.Windows.Forms.RadioButton
    Friend WithEvents RbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents Dg As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
