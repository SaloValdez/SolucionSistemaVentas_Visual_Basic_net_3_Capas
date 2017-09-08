Public Class FrmRepComprobantes

    Private Sub FrmRepComprobantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objdocente As New BCventas.ClsComprobante
        Dim rds As New Microsoft.Reporting.WinForms.ReportDataSource
        Dim dtsdatos As New DataTable

        Try
            rds.Name = "DataSet1"
            dtsdatos = objdocente.Fun_Listar_Comprobante.Tables(0)
            If dtsdatos.Rows.Count > 0 Then
                rds.Value = dtsdatos
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(rds)
                ReportViewer1.LocalReport.ReportPath = "D:\UNIT\PROGRAMACION DISTRIBUIDA\SolucionSistemaVentas\Presentacion\RptComprobante.rdlc "
                '"D:\UNIT\PROGRAMACION DISTRIBUIDA\SisReportes\PjReportes\rptReporteDocente.rdlc  "
            Else
                MessageBox.Show("no se encontraron datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class