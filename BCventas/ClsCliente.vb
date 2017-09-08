Imports System.Data.SqlClient

Public Class ClsCliente
    '----------------------------------------------LISTAR----------------------------------------
    Function Fun_Listar_Cliente() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_lista_cliente"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '---------------------------------------------INSERTAR------------------------------------------------
    Public Function fun_insertar_Cliente(ByVal NombreCliente As String, _
                                          ByVal ApellidoCliente As String, _
                                          ByVal DniCliente As String, _
                                          ByVal RucCliente As String, _
                                          ByVal DireccionCliente As String, _
                                          ByVal TelefonoCliente As String, _
                                          ByVal EmailCliente As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_cliente"
                    oCmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = NombreCliente
                    oCmd.Parameters.Add("@ApellidoCliente", SqlDbType.VarChar).Value = ApellidoCliente
                    oCmd.Parameters.Add("@DniCliente", SqlDbType.VarChar).Value = DniCliente
                    oCmd.Parameters.Add("@RucCliente", SqlDbType.Char).Value = RucCliente
                    oCmd.Parameters.Add("@DireccionCliente", SqlDbType.VarChar).Value = DireccionCliente
                    oCmd.Parameters.Add("@TelefonoCliente", SqlDbType.Char).Value = TelefonoCliente
                    oCmd.Parameters.Add("@EmailCliente", SqlDbType.Char).Value = TelefonoCliente
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


    '----------------------------------------------ACTUALIZAR------------------------------------------
    Public Function fun_actualizar_cliente(ByVal NombreCliente As String, _
                                        ByVal ApellidoCliente As String, _
                                        ByVal DniCliente As String, _
                                        ByRef RucCliente As String, _
                                        ByVal DireccionCliente As String, _
                                        ByVal TelefonoCliente As String, _
                                        ByVal EmailCliente As String, _
                                        ByVal IdCliente As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Cliente"
                        oCmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = NombreCliente
                        oCmd.Parameters.Add("@ApellidoCliente", SqlDbType.VarChar).Value = ApellidoCliente
                        oCmd.Parameters.Add("@DniCliente", SqlDbType.VarChar).Value = DniCliente
                        oCmd.Parameters.Add("@RucCliente", SqlDbType.VarChar).Value = RucCliente
                        oCmd.Parameters.Add("@DireccionCliente", SqlDbType.VarChar).Value = DireccionCliente
                        oCmd.Parameters.Add("@TelefonoCliente", SqlDbType.Char).Value = TelefonoCliente
                        oCmd.Parameters.Add("@EmailCliente", SqlDbType.VarChar).Value = EmailCliente
                        oCmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_cliente = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_cliente = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '--------------------------------------------------ELIMINAR--------------------------------------------
    Public Function fun_eliminar_cliente(ByVal idCliente As String) As String
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
                    oCmd.CommandText = "sp_eliminar_cliente"
                    oCmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = idCliente
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO CLIENTE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Cliente() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_cliente"
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '---------------------------------------------------BUSCAR--------------------------------------------
    Public Function fun_buscar_NombreCliente(ByVal NombreCliente As String) As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_buscar_nombrecliente"
                    cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = NombreCliente
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    Public Function fun_buscar_RucCiente(ByVal RucCliente As String) As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_buscar_ruccliente"
                    cmd.Parameters.Add("@RucCliente", SqlDbType.VarChar).Value = RucCliente
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
