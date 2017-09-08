Public Class FrmManProducto
    Dim obj As New BCventas.ClsProducto
    Public strFalg As String = "0"
    Private Sub FrmManProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call deshabilitar()
        Call listar()
        Call habilitar()
        DgManProducto.Columns(0).Visible = False
        cargar_combo_categoria()
        cargar_combo_subcategoria()
    End Sub

    Sub limpiar()
        Me.TxtCodigo.Text = ""
        Me.TxtProveedor.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.TxtCantidad.Text = ""
        Me.TxtPrecioCosto.Text = ""
        Me.TxtPrecioVenta.Text = ""
        Me.TxtStockMinimo.Text = ""
        Me.CbxCategoria.Text = ""
        Me.CbxSubCategoria.Text = ""

    End Sub
    Sub listar()
        DgManProducto.DataSource = obj.Fun_Listar_Producto.Tables(0)
        DgManProducto.Columns(0).Visible = False
    End Sub
    Sub habilitar()
        Me.TxtCodigo.Enabled = True
        Me.TxtProveedor.Enabled = True
        Me.TxtDescripcion.Enabled = True
        Me.TxtCantidad.Enabled = True
        Me.TxtPrecioCosto.Enabled = True
        Me.TxtPrecioVenta.Enabled = True
        Me.TxtStockMinimo.Enabled = True
        CbxCategoria.Enabled = True
        CbxSubCategoria.Enabled = True
    End Sub
    Sub deshabilitar()
        Me.TxtCodigo.Enabled = False
        Me.TxtProveedor.Enabled = False
        Me.TxtDescripcion.Enabled = False
        Me.TxtCantidad.Enabled = False
        Me.TxtPrecioCosto.Enabled = False
        Me.TxtPrecioVenta.Enabled = False
        Me.TxtStockMinimo.Enabled = False
        CbxCategoria.Enabled = False
        CbxSubCategoria.Enabled = False
        BtnGuardar.Enabled = False
        'BtnEliminar.Enabled = False
        BtnActualizar.Enabled = False
        BtnCancelar.Enabled = False
    End Sub

    Sub cargar_combo_categoria()
        Dim objcargar As New BCventas.ClsCategoria
        Dim dt As New DataTable
        dt = objcargar.Fun_combo_categoria.Tables(0)
        CbxCategoria.DataSource = dt
        CbxCategoria.ValueMember = dt.Columns(0).ToString
        CbxCategoria.DisplayMember = dt.Columns(1).ToString
    End Sub

    Sub cargar_combo_subcategoria()
        Dim objcargar As New BCventas.ClsSubCategoria
        Dim dt As New DataTable
        dt = objcargar.Fun_enlace_SubCategoria(CbxCategoria.SelectedValue).Tables(0)
        CbxSubCategoria.DataSource = dt
        CbxSubCategoria.ValueMember = dt.Columns(0).ToString
        CbxSubCategoria.DisplayMember = dt.Columns(1).ToString
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        strFalg = "1"
        BtnNuevo.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        Call limpiar()
        Call habilitar()
        Me.TxtCodigo.Focus()
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        strFalg = "2"
        habilitar()
        BtnActualizar.Enabled = False
        BtnGuardar.Enabled = True
        BtnNuevo.Enabled = False
        BtnEliminar.Enabled = False
        Me.TxtCodigo.Focus()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim iret As String
        If strFalg = "1" Then
            Dim resp As DialogResult = New DialogResult
            resp = MessageBox.Show("Desea agregar un servicio?", "MANTENIMIENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = DialogResult.Yes) Then
                iret = obj.fun_insertar_Producto(Me.TxtCodigo.Text, _
                                                 Me.TxtProveedor.Text, _
                                                 Me.TxtDescripcion.Text, _
                                                 Me.TxtCantidad.Text, _
                                                 Me.TxtPrecioCosto.Text, _
                                                 Me.TxtPrecioVenta.Text, _
                                                 Me.TxtStockMinimo.Text, _
                                                 Me.CbxCategoria.SelectedValue, _
                                                 Me.CbxSubCategoria.SelectedValue, _
                                                 Me.CbxMarca.Text)
                If iret > 0 Then
                    MessageBox.Show("Se grabo la informacion", "GRABAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call listar()
                    Call limpiar()
                    Call deshabilitar()
                    BtnGuardar.Enabled = False
                    BtnNuevo.Enabled = True
                End If
            End If
        End If

        If strFalg = "2" Then
            iret = obj.fun_actualizar_Producto(Me.TxtCodigo.Text, _
                                                 Me.TxtProveedor.Text, _
                                                 Me.TxtDescripcion.Text, _
                                                 Me.TxtCantidad.Text, _
                                                 Me.TxtPrecioCosto.Text, _
                                                 Me.TxtPrecioVenta.Text, _
                                                 Me.TxtStockMinimo.Text, _
                                                 Me.CbxCategoria.Text, _
                                                 Me.CbxSubCategoria.Text, _
                                                 Me.CbxMarca.Text, _
                                                 Me.Label9.Text)
            If iret = "1" Then
                MessageBox.Show("Semodificó Correctamente", "Modificar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnGuardar.Enabled = False
                Me.BtnNuevo.Enabled = True
                Call deshabilitar()
                Call listar()
            Else
                MessageBox.Show("Comuniquese con el administrador")
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        deshabilitar()
        BtnNuevo.Enabled = True
    End Sub

    Private Sub DgManProducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgManProducto.CellContentClick
        Try
            Me.Label9.Text = DgManProducto.CurrentRow.Cells(1).Value
            Me.TxtCodigo.Text = DgManProducto.CurrentRow.Cells(2).Value
            Me.TxtProveedor.Text = DgManProducto.CurrentRow.Cells(3).Value
            Me.TxtDescripcion.Text = DgManProducto.CurrentRow.Cells(4).Value
            Me.TxtCantidad.Text = DgManProducto.CurrentRow.Cells(5).Value
            Me.TxtPrecioCosto.Text = DgManProducto.CurrentRow.Cells(6).Value
            Me.TxtPrecioVenta.Text = DgManProducto.CurrentRow.Cells(7).Value
            Me.TxtStockMinimo.Text = DgManProducto.CurrentRow.Cells(8).Value
            CbxCategoria.Text = DgManProducto.CurrentRow.Cells(9).Value
            CbxSubCategoria.Text = DgManProducto.CurrentRow.Cells(10).Value
            CbxMarca.Text = DgManProducto.CurrentRow.Cells(11).Value
            BtnActualizar.Enabled = True
            BtnNuevo.Enabled = True
            BtnEliminar.Enabled = True
            BtnCancelar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        'ESC
        If keyData = Keys.Escape Then
            Me.Close()
        End If
        'DELETE
        If keyData = Keys.Delete Then
            Dim message As String = "Eliminar Registro?"
            Dim caption As String = "Eliminar"
            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult
            'Displays the MessageBox
            result = MessageBox.Show(message, caption, buttons)
            'Gets the result of the MessageBox display.
            If result = System.Windows.Forms.DialogResult.Yes Then
                'Closes the parents form
                Dim objeliminar As New BCventas.ClsEmpleado
                obj.fun_eliminar_producto(DgManProducto.Rows(DgManProducto.CurrentRow.Index).Cells(1).Value)
                Call listar()
            End If
        End If
        'devolver la tecla presionada de vuelta al formulario
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If BtnEliminar.Text = "Eliminar" Then
            BtnEliminar.Text = "Eliminar Seleccion"
            BtnEliminar.BackColor = Color.Khaki
            DgManProducto.Columns.Item("Eliminar").Visible = True
            'DgManEmpleado.Columns.Item("Eliminar").Visible = False
        Else
            Dim result As DialogResult

            result = MessageBox.Show("Realmente desea eliminar los clientes seleccionados?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try
                    For Each row As DataGridViewRow In DgManProducto.Rows
                        Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)
                        If marcado Then

                        End If

                        Dim objeliminar As New BCventas.ClsEmpleado
                        obj.fun_eliminar_producto(DgManProducto.Rows(DgManProducto.CurrentRow.Index).Cells(1).Value)
                        Call listar()
                        'If marcado Then
                        '    Dim onekey As Integer = Convert.ToInt32(row.Cells("IdEmpleado").Value)
                        '    Dim vdb As New BCventas.ClsEmpleado
                        '    Dim func As New BCventas.ClsEmpleado
                        '    vdb.gidcliente = onekey

                        '    If func.fun_eliminar_empleado(vdb) Then
                        '    Else
                        '        MessageBox.Show("Cliente no fue eliminado", "Eliminando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '    End If
                        'End If

                    Next
                    ' Call mostrar()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("Cancelando eliminación de registros", "Eliminando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Call mostrar()
            End If

            Call limpiar()
        End If
    End Sub

    

    Private Sub CbxCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CbxCategoria.SelectionChangeCommitted
        Call cargar_combo_subcategoria()
    End Sub

    Private Sub CbxCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxCategoria.SelectedIndexChanged

    End Sub
End Class