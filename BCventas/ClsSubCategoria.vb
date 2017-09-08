Imports System.Data.SqlClient

Public Class ClsSubCategoria
    '--------------------------------------------------------LISTAR------------------------------------------------------------
    Function Fun_Listar_SubCategoria() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_listar_subcategoria"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '-----------------------------------------------------------INSERTAR----------------------------------------------------------
    Public Function fun_insertar_SubCategoria(ByVal DetalleSubCategoria As String, _
                                             ByVal IdCategoria As Integer) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_subcategoria"
                    oCmd.Parameters.Add("@DetalleSubCategoria", SqlDbType.VarChar).Value = DetalleSubCategoria
                    oCmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = IdCategoria
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-------------------------------------------------------------ACTUALIZAR--------------------------------------------------
    Public Function fun_actualizar_SubCategoria(ByVal DetalleSubCategoria As String, _
                                         ByVal IdCategoria As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Subcategoria"
                        oCmd.Parameters.Add("@DetalleSubCategoria", SqlDbType.VarChar).Value = DetalleSubCategoria
                        oCmd.Parameters.Add("@IdCategoria", SqlDbType.Char).Value = IdCategoria
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_SubCategoria = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_SubCategoria = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '----------------------------------------------------------------ELIMINAR----------------------------------------------
    Public Function fun_eliminar_SubCategoria(ByVal IdSubCategoria As String) As String
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
                    oCmd.CommandText = "sp_eliminar_sub_categoria"
                    oCmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = IdSubCategoria
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    ''~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO SUBCATEGORIA ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    'Function Fun_Combo_SubCategoria() As DataSet
    '    Dim ds As New DataSet
    '    Dim objconexion As New ClsConexion
    '    Using cn As New SqlConnection
    '        Using da As New SqlDataAdapter
    '            Using cmd As New SqlCommand
    '                cn.ConnectionString = objconexion.conexion
    '                cmd.Connection = cn
    '                cmd.CommandType = CommandType.StoredProcedure
    '                cmd.CommandText = "sp_combo_subcategoria"
    '                da.SelectCommand = cmd
    '                cn.Open()
    '                da.Fill(ds)
    '                cn.Close()
    '            End Using
    '        End Using
    '    End Using
    '    Return ds
    'End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO SUBCATEGORIA ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_subCategoria() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_subcategoria"
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    Function Fun_enlace_SubCategoria(ByVal IdSubCategoria As Integer) As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_enlace_subcategoria"
                    ocmd.Parameters.Add("@IdSubCategoria", SqlDbType.Int).Value = IdSubCategoria

                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
End Class
