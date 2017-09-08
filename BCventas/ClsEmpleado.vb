Imports System.Data.SqlClient


Public Class ClsEmpleado
    '------------------------------------------------------------------ LISTAR-----------------------------------------------
    Public Function fun_listar_empleado() As DataSet
        Dim Ds As New DataSet
        Dim OBJ As New ClsConexion
        Using Cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using Cmd As New SqlCommand
                    Cn.ConnectionString = OBJ.conexion()
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.CommandText = "sp_listar_empleado"
                    Cmd.Connection = Cn
                    da.SelectCommand = Cmd
                    Cn.Open()
                    da.Fill(Ds)
                    Cn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    'funcion LISTAR
    'Public Function fun_Listar_empleado() As Data.DataSet
    '    Dim lobjExacute As New BCventas.ClsConexion
    '    Dim Ds As New DataSet
    '    Using oCn As New SqlConnection(lobjExacute.conexion())
    '        Using oCmd As New SqlCommand
    '            Using oDa As New SqlDataAdapter(oCmd)
    '                oCmd.Connection = oCn
    '                oCmd.CommandType = CommandType.StoredProcedure
    '                oCmd.CommandText = "sp_listar_empleado"
    '                oDa.SelectCommand.Connection = oCn
    '                oDa.Fill(Ds)
    '                fun_Listar_empleado = Ds
    '            End Using
    '        End Using
    '    End Using
    '    Catch ex As Exception
    '        'Return 1
    '    Finally
    '        lobjExacute = Nothing
    '    End Try
    'End Function

    '---------------------------------------------------------------INSERTAR---------------------------------------------------
    Public Function fun_insertar_empleado(ByVal NombreEmpleado As String, _
                                          ByVal ApellidoEmpleado As String, _
                                          ByVal DniEmpleado As String, _
                                          ByVal FechaNacimientoEmpleado As Date, _
                                          ByVal TelefonoEmpleado As String, _
                                          ByVal DireccionEmpleado As String, _
                                          ByVal IdArea As Integer, _
                                          ByVal IdCargo As Integer) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_empleado"
                    oCmd.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = NombreEmpleado
                    oCmd.Parameters.Add("@ApellidoEmpleado", SqlDbType.VarChar).Value = ApellidoEmpleado
                    oCmd.Parameters.Add("@DniEmpleado", SqlDbType.Char).Value = DniEmpleado
                    oCmd.Parameters.Add("@FechaNacimientoEmpleado", SqlDbType.Date).Value = FechaNacimientoEmpleado
                    oCmd.Parameters.Add("@TelefonoEmpleado", SqlDbType.Char).Value = TelefonoEmpleado
                    oCmd.Parameters.Add("@DireccionEmpleado", SqlDbType.VarChar).Value = DireccionEmpleado
                    oCmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = IdArea
                    oCmd.Parameters.Add("@IdCargo", SqlDbType.Int).Value = IdCargo
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '------------------------------------------------------------- ACTUALIZAR-----------------------------------------------------------
    Public Function fun_actualizar_empleado(ByVal NombreEmpleado As String, _
                                            ByVal ApellidoEmpleado As String, _
                                            ByVal DniEmpleado As String, _
                                            ByVal FechaNacimientoEmpleado As Date, _
                                            ByVal TelefonoEmpleado As String, _
                                            ByVal DireccionEmpleado As String, _
                                            ByVal IdArea As Integer, _
                                            ByVal IdCargo As Integer, _
                                            ByVal IdEmpleado As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_empleado"
                        oCmd.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = NombreEmpleado
                        oCmd.Parameters.Add("@ApellidoEmpleado", SqlDbType.VarChar).Value = ApellidoEmpleado
                        oCmd.Parameters.Add("@DniEmpleado", SqlDbType.Char).Value = DniEmpleado
                        oCmd.Parameters.Add("@FechaNacimientoEmpleado", SqlDbType.Date).Value = FechaNacimientoEmpleado
                        oCmd.Parameters.Add("@TelefonoEmpleado", SqlDbType.Char).Value = TelefonoEmpleado
                        oCmd.Parameters.Add("@DireccionEmpleado", SqlDbType.VarChar).Value = DireccionEmpleado
                        oCmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = IdArea
                        oCmd.Parameters.Add("@IdCargo", SqlDbType.Int).Value = IdCargo
                        oCmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_empleado = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_empleado = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '-----------------------------------------------------------------------------ELIMINAR-----------------------------------------------
    Public Function fun_eliminar_empleado(ByVal IdEmpleado As String) As String
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
                    oCmd.CommandText = "sp_eliminar_empleado"
                    oCmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-------------------------------------------------------------------------------cargar combo area----------------------------------------------
    Public Function Cargar_Comboarea_empleado() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_cargarcombo_area_empleado"
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '---------------------------------------------------------------------------------------cargar combo cargo----------------------------------------------
    Public Function Cargar_Combocargo_empleado() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_cargarcombo_cargo_empleado"
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO EMPLEADO ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Empleado() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_empleado"
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
