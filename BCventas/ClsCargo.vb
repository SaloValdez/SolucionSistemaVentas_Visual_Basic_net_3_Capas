Imports System.Data.SqlClient

Public Class ClsCargo
    '----------------------------------------------LISTAR----------------------------------------------
    Function Fun_Listar_Cargo() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_lista_cargo"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '-------------------------------------------------INSERTAR-----------------------------------------
    Public Function fun_insertar_Cargo(ByVal NombreCArgo As String, ByVal IdArea As Integer) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_cargo"
                    oCmd.Parameters.Add("@NombreCargo", SqlDbType.VarChar).Value = NombreCArgo
                    oCmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = IdArea
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function

    '------------------------------------------------ACTUALIZAR-----------------------------------------
    Public Function fun_actualizar_Cargo(ByVal NombreCargo As String, _
                                            ByVal IdArea As Integer, _
                                            ByVal IdCargo As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Cargo"
                        oCmd.Parameters.Add("@NombreCargo", SqlDbType.VarChar).Value = NombreCargo
                        oCmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = IdArea
                        oCmd.Parameters.Add("@IdCargo", SqlDbType.Int).Value = IdCargo
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Cargo = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Cargo = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '---------------------------------------------------ELIMINAR---------------------------------------------------
    Public Function fun_eliminar_cargo(ByVal IdCargo As String) As String
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
                    oCmd.CommandText = "sp_eliminar_cargo"
                    oCmd.Parameters.Add("@IdCargo", SqlDbType.Int).Value = IdCargo
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO CARGO ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Cargo() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_cargo"
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
