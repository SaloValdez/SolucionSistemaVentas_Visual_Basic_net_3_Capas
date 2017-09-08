Public Class FrmVenta
    Dim iCont As Integer
    Dim st As Integer
    Dim state As Integer
    Dim px, py As Integer ' para mover  ventana
    Dim mover As Boolean ' para mover ventana
    Private Sub FrmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'frm
        cargar_combo_cliente()
        cargar_combo_producto()
        cargar_combo_tipocomprobante()
        iCont = -1
    End Sub
    Sub cargar_combo_tipocomprobante() 'cargar combo tipo comprobante
        Dim dt As New DataTable
        Dim obj As New BCventas.ClsComprobante
        dt = obj.fun_cargarcombo_tipocomprobante.Tables(0)
        If dt.Rows.Count > 0 Then
            CbxComprobante.DataSource = dt
            CbxComprobante.ValueMember = dt.Columns(0).ToString
            CbxComprobante.DisplayMember = dt.Columns(1).ToString
        End If
    End Sub
    Sub cargar_combo_cliente() 'cargar combo cliente
        Dim dt As New DataTable
        Dim obj As New BCventas.ClsComprobante
        dt = obj.fun_cargarcombo_cliente.Tables(0)
        If dt.Rows.Count > 0 Then
            CbxCliente.DataSource = dt
            CbxCliente.ValueMember = dt.Columns(0).ToString
            CbxCliente.DisplayMember = dt.Columns(1).ToString
        End If
    End Sub
    Sub cargar_combo_producto() 'cargar combo producto
        Dim dt As New DataTable
        Dim obj As New BCventas.ClsComprobante
        dt = obj.fun_cargarcombo_producto.Tables(0)
        If dt.Rows.Count > 0 Then
            CbxProducto.DataSource = dt
            CbxProducto.ValueMember = dt.Columns(0).ToString
            CbxProducto.DisplayMember = dt.Columns(1).ToString
        End If
    End Sub

    Sub calcular_total() 'suma el total de de txt
        Dim s As Double
        s = 0
        For i As Integer = 0 To Me.DgwDetalle.RowCount - 1
            s += Convert.ToDouble(Me.DgwDetalle.Item(4, i).Value)
        Next
        Me.TxtTotal.Text = s
    End Sub
    Private Sub CbxProducto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CbxProducto.SelectionChangeCommitted
        'cbx con evento cargar texbox precio
        Dim dtp As New DataTable
        Dim objp As New BCventas.ClsComprobante
        dtp = objp.fun_cargartexbox_precioproducto(Me.CbxProducto.SelectedValue).Tables(0)
        If dtp.Rows.Count > 0 Then
            Me.TxtPrecio.Text = dtp.Rows(0)(0).ToString
        End If
        'cargar con evento cargar texbox stock producto
        Dim dts As New DataTable
        Dim objs As New BCventas.ClsComprobante
        dts = objs.fun_cargartexbox_stockproducto(Me.CbxProducto.SelectedValue).Tables(0)
        If dts.Rows.Count > 0 Then
            Me.TxtStock.Text = dts.Rows(0)(0).ToString
        End If
        'cargar con evento cargar texbox stock minimo producto
        Dim dtsm As New DataTable
        Dim objsm As New BCventas.ClsComprobante
        dtsm = objsm.fun_cargartexbox_stockminproducto(Me.CbxProducto.SelectedValue).Tables(0)
        If dtsm.Rows.Count > 0 Then
            Me.TxtStockMin.Text = dtsm.Rows(0)(0).ToString
        End If
    End Sub


    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs)  ' boton agregar a datagridwiev

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click 'boton guardar
        Dim obj As New BCventas.ClsComprobante
        Dim idcomprobante As Integer
        idcomprobante = obj.fun_insertar_comprobante(TxtNumero.Text, _
                                                     TxtSerie.Text, _
                                                     CbxCliente.SelectedValue, _
                                                     TxtEmpleado.Text, _
                                                     CbxComprobante.SelectedValue, _
                                                     DtpFecha.Value, _
                                                     TxtIgv.Text, _
                                                     TxtTotal.Text, _
                                                     TxtMensaje.Text, _
                                                     TxtEstado.Text)
        For i As Integer = 0 To DgwDetalle.RowCount - 1
            obj.fun_insertar_detallecomprobante(idcomprobante, DgwDetalle.Item(0, i).Value, _
                                                               DgwDetalle.Item(1, i).Value, _
                                                               DgwDetalle.Item(3, i).Value, _
                                                               DgwDetalle.Item(4, i).Value)
        Next
        If idcomprobante > 0 Then
            MessageBox.Show("se grabo correctamente")
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call winstate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        iCont += 1
        Me.DgwDetalle.Rows.Add() 'AGREGA UNA NUEVA FILA

        Me.DgwDetalle.Item(0, iCont).Value = Me.CbxProducto.SelectedValue
        Me.DgwDetalle.Item(1, iCont).Value = Me.TxtCantidad.Text
        Me.DgwDetalle.Item(2, iCont).Value = Me.CbxProducto.Text
        Me.DgwDetalle.Item(3, iCont).Value = Me.TxtPrecio.Text
        Me.DgwDetalle.Item(4, iCont).Value = Convert.ToDecimal(Me.TxtPrecio.Text) * Convert.ToInt32(Me.TxtCantidad.Text)
        Call calcular_total()
    End Sub
    Private Sub winstate()
        If state = 0 Then
            Me.WindowState = FormWindowState.Maximized
            state = 1
        ElseIf state = 1 Then
            Me.WindowState = FormWindowState.Normal
            state = 0
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick 'estado ventana max,min
        Call winstate()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown 'asignando los valores a los variable spara mover ventana
        px = e.X
        py = e.Y
        mover = True

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove 'cunado  el mouse se esta moviendo
        If mover Then
            Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - px, Me.MousePosition.Y - Me.Location.Y - py))
        End If

    End Sub

    Private Sub CbxCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxCliente.SelectedIndexChanged

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp 'mouse se aleja del pixture box
        mover = False
    End Sub
End Class
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

