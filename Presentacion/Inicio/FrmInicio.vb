Public Class FrmInicio

    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usuario_activo.Text = "Usuario actual : " & CuentaUsuario
        usuario_actual1.Text = "Usuario actual: " & CuentaUsuario
        hora_actual.Text = "  hora : " & Now
        If Estado <> "Administrador" Then 'en caso de no ser administrador se inahabilita estos botones:
            btnprueba.Enabled = False
            MantenimientoToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub lblusuario_Click(sender As Object, e As EventArgs) Handles lblusuario.Click
        FrmManEmpleado.Show()
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs)
        If MsgBox("¿Quiere volver al login?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Informe de ingreso") = MsgBoxResult.Yes Then
            Me.Close()
            FrmLogin.Show()
            'FrmLogin.Cmbusuario.Text = Nothing
            'FrmLogin.txtcontraseña.Text = ""
        End If
    End Sub



























    Private Sub EmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadoToolStripMenuItem.Click
        Dim frm As New FrmManEmpleado()
        frm.Show()
    End Sub
    Private Sub FacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaToolStripMenuItem.Click
        Dim frm As New FrmVenta()
        frm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        Dim frm As New FrmManCliente()
        frm.Show()
    End Sub

    Private Sub ProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedorToolStripMenuItem.Click
        Dim frm As New FrmManProveedor()
        frm.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim frm As New FrmManProducto()
        frm.Show()
    End Sub

    Private Sub SalirSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirSistemaToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Dim frm As New FrmLogin()
        Me.Close()
    End Sub

    Private Sub ReporteComprobanteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteComprobanteToolStripMenuItem.Click
        Dim frm As New FrmRepComprobantes()
        frm.Show()
    End Sub

    Private Sub ReporteProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteProveedorToolStripMenuItem.Click
        Dim frm As New FrmRepProveedor()
        frm.Show()
    End Sub

    Private Sub BuscarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarClienteToolStripMenuItem.Click
        Dim frm As New FrmConClientes()
        frm.Show()
    End Sub

    Private Sub MarcaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcaToolStripMenuItem.Click
        Dim frm As New FrmManMarca()
        frm.Show()
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnprueba.Click
        'Me.Hide()
        FrmManCargo.Show()
    End Sub
End Class