Public Class FrmManEmpleado
    Dim obj As New BCventas.ClsEmpleado
    ' Dim estado As String
    Public strFalg As String = "0"
    Dim px, py As Integer ' para mover  ventana
    Dim mover As Boolean ' para mover ventana
    Dim state As Integer 'ESTADO VENTANA
    Private Sub FrmManEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call deshabilitar()
        Call listar()
        DgManEmpleado.Columns(0).Visible = False
        cargar_combo_area()
        cargar_combo_cargo()
    End Sub
    Sub limpiar()
        Me.TxtNombre.Text = ""
        Me.TxtApellido.Text = ""
        Me.TxtDni.Text = ""
        Me.TxtFechaNacimiento.Text = ""
        Me.TxtTelefono.Text = ""
        Me.TxtDireccion.Text = ""
    End Sub
    Sub listar()
        DgManEmpleado.DataSource = obj.fun_listar_empleado.Tables(0)
        DgManEmpleado.Columns(0).Visible = False

    End Sub
    Sub habilitar()
        Me.TxtNombre.Enabled = True
        Me.TxtApellido.Enabled = True
        Me.TxtDni.Enabled = True
        Me.TxtFechaNacimiento.Enabled = True
        Me.TxtTelefono.Enabled = True
        Me.TxtDireccion.Enabled = True
        CbxArea.Enabled = True
        CbxCargo.Enabled = True
    End Sub
    Sub deshabilitar()
        Me.TxtNombre.Enabled = False
        Me.TxtApellido.Enabled = False
        Me.TxtDni.Enabled = False
        Me.TxtFechaNacimiento.Enabled = False
        Me.TxtTelefono.Enabled = False
        Me.TxtDireccion.Enabled = False
        CbxArea.Enabled = False
        CbxCargo.Enabled = False

        BtnGuardar.Enabled = False
        BtnEliminar.Enabled = False
        BtnActualizar.Enabled = False
        BtnCancelar.Enabled = False
        BtnEliminar.BackColor = SystemColors.ControlLight
        BtnEliminar.Text = "Eliminar"
        DgManEmpleado.Columns.Item("Eliminar").Visible = True
        DgManEmpleado.Columns.Item("Eliminar").Visible = False
    End Sub
    Sub cargar_combo_area()
        Dim objcargar As New BCventas.ClsEmpleado
        Dim dt As New DataTable
        dt = objcargar.Cargar_Comboarea_empleado.Tables(0)
        CbxArea.DataSource = dt
        CbxArea.ValueMember = dt.Columns(0).ToString
        CbxArea.DisplayMember = dt.Columns(1).ToString
    End Sub
    Sub cargar_combo_cargo()
        Dim objcargarcargo As New BCventas.ClsEmpleado
        Dim td As New DataTable
        td = objcargarcargo.Cargar_Combocargo_empleado.Tables(0)
        CbxCargo.DataSource = td
        CbxCargo.ValueMember = td.Columns(0).ToString
        CbxCargo.DisplayMember = td.Columns(1).ToString
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click 'BOTONES---------------------------------------------
        strFalg = "1"
        BtnNuevo.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        BtnEliminar.Enabled = False
        BtnActualizar.Enabled = False
        Call limpiar()
        Call habilitar()
        Me.TxtNombre.Focus()
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        strFalg = "2"
        habilitar()
        BtnActualizar.Enabled = False
        BtnNuevo.Enabled = False
        BtnEliminar.Enabled = False
        BtnGuardar.Enabled = True
        Me.TxtNombre.Focus()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim iret As String
        If strFalg = "1" Then
            Dim resp As DialogResult = New DialogResult
            resp = MessageBox.Show("Desea agregar un servicio?", "MANTENIMIENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = DialogResult.Yes) Then
                iret = obj.fun_insertar_empleado(Me.TxtNombre.Text, _
                                                 Me.TxtApellido.Text, _
                                                 Me.TxtDni.Text, _
                                                 Me.TxtFechaNacimiento.Text, _
                                                 Me.TxtTelefono.Text, _
                                                 Me.TxtDireccion.Text, _
                                                 Me.CbxArea.Text, _
                                                 Me.CbxCargo.Text)
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
            iret = obj.fun_actualizar_empleado(Me.TxtNombre.Text, _
                                             Me.TxtApellido.Text, _
                                             Me.TxtDni.Text, _
                                             Me.TxtFechaNacimiento.Text, _
                                             Me.TxtTelefono.Text, _
                                             Me.TxtDireccion.Text, _
                                             Me.CbxArea.Text, _
                                             Me.CbxCargo.Text, _
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

    Private Sub DgManEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgManEmpleado.CellContentClick
        Try
            Me.Label9.Text = DgManEmpleado.CurrentRow.Cells(1).Value
            Me.TxtNombre.Text = DgManEmpleado.CurrentRow.Cells(2).Value
            Me.TxtApellido.Text = DgManEmpleado.CurrentRow.Cells(3).Value
            Me.TxtDni.Text = DgManEmpleado.CurrentRow.Cells(4).Value
            Me.TxtFechaNacimiento.Text = DgManEmpleado.CurrentRow.Cells(5).Value
            Me.TxtTelefono.Text = DgManEmpleado.CurrentRow.Cells(6).Value
            Me.TxtDireccion.Text = DgManEmpleado.CurrentRow.Cells(7).Value
            CbxArea.Text = DgManEmpleado.CurrentRow.Cells(8).Value
            CbxCargo.Text = DgManEmpleado.CurrentRow.Cells(9).Value
            BtnActualizar.Enabled = True
            BtnNuevo.Enabled = True
            BtnCancelar.Enabled = True
            BtnEliminar.Enabled = True
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
                obj.fun_eliminar_empleado(DgManEmpleado.Rows(DgManEmpleado.CurrentRow.Index).Cells(1).Value)
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
            DgManEmpleado.Columns.Item("Eliminar").Visible = True
            'DgManEmpleado.Columns.Item("Eliminar").Visible = False
        Else
            Dim result As DialogResult

            result = MessageBox.Show("Realmente desea eliminar los clientes seleccionados?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try
                    For Each row As DataGridViewRow In DgManEmpleado.Rows
                        Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)
                        If marcado Then

                        End If

                        Dim objeliminar As New BCventas.ClsEmpleado
                        obj.fun_eliminar_empleado(DgManEmpleado.Rows(DgManEmpleado.CurrentRow.Index).Cells(0).Value)
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
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
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

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Call winstate()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        px = e.X
        py = e.Y
        mover = True
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If mover Then
            Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - px, Me.MousePosition.Y - Me.Location.Y - py))
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        mover = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call winstate()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class