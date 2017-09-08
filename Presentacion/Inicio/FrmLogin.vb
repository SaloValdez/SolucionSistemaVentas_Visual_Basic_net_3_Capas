Imports System.Data.SqlClient
Public Class FrmLogin
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False 'para deshabilitar las opciones de minimizar i maximizar
        clear()
    End Sub
    Sub clear()
        txtusuario.Text = Nothing
        TxtContrasena.Text = ""
        txtusuario.Focus()
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        'Dim conn As SqlConnection = New SqlConnection(conexion)

        Dim cmd As New SqlCommand("SELECT * FROM USUARIO", conexion)
        conexion.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim j As Integer = 0
        Try
            While dr.Read()
                If TxtUsuario.Text = dr(1) And TxtContrasena.Text = dr(2) Then

                    ClaveUsuario = dr(2)
                    Estado = dr(3)
                    CuentaUsuario = TxtUsuario.Text
                    Me.Hide()
                    FrmInicio.Show()
                    TxtUsuario.Clear()
                    TxtContrasena.Clear()
                    j = 1
                End If
            End While
            If j <> 1 Then
                MsgBox("El usuario o contraseña son incorrectos.", MsgBoxStyle.Critical, "Informe de ingreso")
                clear()
            End If
        Catch exp As Exception
            MsgBox("ERROR:" & exp.Message, , "Mensaje")
        Finally
            conexion.Close()
        End Try
    End Sub






    'Dim obj As New BCventas.ClsLogin
    'Dim dt As New DataTable
    'dt = obj.login(TxtUsuario.Text, TxtContrasena.Text).Tables(0)
    'If dt.Rows.Count > 0 Then

    '    Dim frm As New FrmInicio
    '    Me.Hide() 'desaparecer
    '    frm.Show()
    'Else
    '    MessageBox.Show("No se establecio la conexion , Contraseña Incorrecta")
    'End If


    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dim condición As Integer
        condición = MsgBox("Se va a cerrar el programa ¿Desea continuar?", vbYesNo)
        If condición = vbNo Then Exit Sub
        MsgBox("Ha elegido Cerrar")
        Me.Close()
    End Sub


End Class
