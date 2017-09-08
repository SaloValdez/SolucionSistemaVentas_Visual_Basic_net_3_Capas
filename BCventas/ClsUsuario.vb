Imports System.Data.SqlClient

Public Class ClsUsuario
    '--------------------------------------------LISTAR------------------------------------------------------------------
    Function Fun_Listar_Usiario() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_listar_usuario"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '---------------------------------------------INSERTAR-------------------------------------------------------------
    Public Function fun_insertar_Usuario(ByVal CuentaUsuario As String, _
                                             ByVal ClaveUsuario As String, _
                                             ByVal IdEmpleado As Integer) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_usuario"
                    oCmd.Parameters.Add("@CuentaUsuario", SqlDbType.VarChar).Value = CuentaUsuario
                    oCmd.Parameters.Add("@ClaveUsuario", SqlDbType.VarChar).Value = ClaveUsuario
                    oCmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '---------------------------------------------ACTUALIZAR------------------------------------------------------------------
    Public Function fun_actualizar_Usuario(ByVal CuentaUsuario As String, _
                                       ByVal ClaveUsuario As String, _
                                       ByVal IdEmpleado As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Usuario"
                        oCmd.Parameters.Add("@CuentaUsuario", SqlDbType.VarChar).Value = CuentaUsuario
                        oCmd.Parameters.Add("@ClaveUsuario", SqlDbType.VarChar).Value = ClaveUsuario
                        oCmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Usuario = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Usuario = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '-----------------------------------------------------------------ELIMINAR-----------------------------------------
    Public Function fun_eliminar_usuario(ByVal IdUsuario As String) As String
        Dim iRet As Integer
        Dim lobjExecute As New BCventas.ClsConexion
        Dim Ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using oCn As New SqlClient.SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = lobjExecute.conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_eliminar_tipo_usuario"
                    oCmd.Parameters.Add("@idtipo_usuario", SqlDbType.Int).Value = IdUsuario
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO USUARIO ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Usuario() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_usuario"
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
End Class
