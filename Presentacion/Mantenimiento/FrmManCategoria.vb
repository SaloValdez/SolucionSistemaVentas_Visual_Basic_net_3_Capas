﻿Public Class FrmManCategoria
    Dim obj As New BCventas.ClsCategoria
    ' Dim estado As String
    Public strFalg As String = "0"
    Private Sub FrmManCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call deshabilitar()
        Call listar()
        DgManCategoria.Enabled = True
        DgManCategoria.Columns(0).Visible = False
    End Sub

    Sub limpiar()
        Me.TxtDescripcionCategoria.Text = ""
    End Sub
    Sub listar()
        DgManCategoria.DataSource = obj.Fun_Listar_Categoria.Tables(0)
        DgManCategoria.Columns(0).Visible = False
    End Sub
    Sub habilitar()
        Me.TxtDescripcionCategoria.Enabled = True
        DgManCategoria.Enabled = True
    End Sub
    Sub deshabilitar()
        Me.TxtDescripcionCategoria.Enabled = False
        BtnActualizar.Enabled = False
        BtnEliminar.Enabled = False
        BtnCancelar.Enabled = False
        BtnGuardar.Enabled = False
        BtnEliminar.BackColor = SystemColors.ControlLight
        BtnEliminar.Text = "Eliminar"
        DgManCategoria.Columns.Item("Eliminar").Visible = True
        DgManCategoria.Columns.Item("Eliminar").Visible = False
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        strFalg = "1"
        BtnNuevo.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        Call limpiar()
        Call habilitar()
        Me.TxtDescripcionCategoria.Focus()
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        strFalg = "2"
        habilitar()
        BtnActualizar.Enabled = False
        BtnGuardar.Enabled = True
        Me.TxtDescripcionCategoria.Focus()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim iret As String
        If strFalg = "1" Then
            Dim resp As DialogResult = New DialogResult
            resp = MessageBox.Show("Desea agregar un servicio?", "MANTENIMIENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = DialogResult.Yes) Then
                iret = obj.fun_insertar_Categoria(Me.TxtDescripcionCategoria.Text)
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
            iret = obj.fun_actualizar_Categoria(Me.TxtDescripcionCategoria.Text, _
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
                obj.fun_eliminar_categoria(DgManCategoria.Rows(DgManCategoria.CurrentRow.Index).Cells(1).Value)
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
            DgManCategoria.Columns.Item("Eliminar").Visible = True
            'DgManEmpleado.Columns.Item("Eliminar").Visible = False
        Else
            Dim result As DialogResult

            result = MessageBox.Show("Realmente desea eliminar los clientes seleccionados?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try
                    For Each row As DataGridViewRow In DgManCategoria.Rows
                        Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)
                        If marcado Then

                        End If

                        Dim objeliminar As New BCventas.ClsEmpleado
                        obj.fun_eliminar_categoria(DgManCategoria.Rows(DgManCategoria.CurrentRow.Index).Cells(1).Value)
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

    Private Sub DgManCategoria_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgManCategoria.CellContentClick
        Try
            Me.Label9.Text = DgManCategoria.CurrentRow.Cells(1).Value
            Me.TxtDescripcionCategoria.Text = DgManCategoria.CurrentRow.Cells(2).Value
            BtnActualizar.Enabled = True
            BtnNuevo.Enabled = True
            BtnCancelar.Enabled = True
            BtnEliminar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class