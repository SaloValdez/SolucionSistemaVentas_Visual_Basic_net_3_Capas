Public Class FrmConComprobante
    Dim obj As New BCventas.ClsComprobante

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If RadioButton1.Checked = True Then
                Call buscar_fechas()
            End If
            If RadioButton2.Checked = True Then
                Call buscar_numero()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmConComprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RadioButton1.Checked = True
    End Sub

    
    Sub buscar_numero()
        Dim dt As New DataTable
        Try
            dt = obj.listar_comprobante_numero(Me.TxtNumero.Text).Tables(0)
            If dt.Rows.Count > 0 Then
                Dg.DataSource = dt
            Else
                Dg.DataSource = Nothing
                MessageBox.Show("Nose encontro Registros")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Sub buscar_fechas()
        Dim dt As New DataTable
        Try
            dt = obj.listar_comprobante_fecha(Me.DateTimePicker1.Value, Me.DateTimePicker2.Value).Tables(0)
            If dt.Rows.Count > 0 Then
                Dg.DataSource = dt
            Else
                Dg.DataSource = Nothing
                MessageBox.Show("No se encontro Registros")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class