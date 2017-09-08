Public Class FrmConClientes
    Dim obj As New BCventas.ClsCliente
    Private Sub FrmConClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call listar()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RbNombre.Checked Then
            Dim objbuscar As New BCventas.ClsCliente
            Dg.DataSource = objbuscar.fun_buscar_NombreCliente(Me.TxTexto.Text.Trim).Tables(0)
        Else
            Dim objbuscar As New BCventas.ClsCliente
            Dg.DataSource = objbuscar.fun_buscar_RucCiente(Me.TxTexto.Text.Trim).Tables(0)
        End If
    End Sub

    Sub listar()
        Dg.DataSource = obj.Fun_Listar_Cliente.Tables(0)
        Dg.Columns(0).Visible = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call listar()
    End Sub
End Class