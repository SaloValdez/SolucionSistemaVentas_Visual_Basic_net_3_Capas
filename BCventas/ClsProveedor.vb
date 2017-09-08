Imports System.Data.SqlClient
Public Class ClsProveedor
    '-------------------------------------------------------------LISTAR--------------------------------------------------
    Function Fun_Listar_Proveedor() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_lista_proveedor"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '----------------------------------------------------------------INSERTAR------------------------------------------------
    Public Function fun_insertar_Proveedor(ByVal RazonSocialProveedor As String, _
                                           ByVal RucProveedor As String, _
                                           ByVal DireccionProveedor As String, _
                                           ByVal TelefonoProveedor As String, _
                                           ByVal EmailProveedor As String, _
                                           ByVal RepresentanteProveedor As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_proveedor"
                    oCmd.Parameters.Add("@RazonSocialProveedor", SqlDbType.VarChar).Value = RazonSocialProveedor
                    oCmd.Parameters.Add("@RucProveedor", SqlDbType.VarChar).Value = RucProveedor
                    oCmd.Parameters.Add("@DireccionProveedor", SqlDbType.VarChar).Value = DireccionProveedor
                    oCmd.Parameters.Add("@TelefonoProveedor", SqlDbType.Char).Value = TelefonoProveedor
                    oCmd.Parameters.Add("@EmailProveedor", SqlDbType.VarChar).Value = EmailProveedor
                    oCmd.Parameters.Add("@RepresentanteProveedor", SqlDbType.VarChar).Value = RepresentanteProveedor
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-------------------------------------------------------ACTUALIZAR--------------------------------------------------------
    Public Function fun_actualizar_Proveedor(ByVal RazonSocialProveedor As String, _
                                      ByVal RucProveedor As Char, _
                                      ByVal DireccionProveedor As String, _
                                      ByVal TelefonoProveedor As Char, _
                                      ByVal EmailProveedor As String, _
                                      ByVal RepresentanteProveedor As String, _
                                       ByVal IdProveedor As String) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Proveedor"
                        oCmd.Parameters.Add("@RazonSocialProveedor", SqlDbType.VarChar).Value = RazonSocialProveedor
                        oCmd.Parameters.Add("@RucProveedor", SqlDbType.Char).Value = RucProveedor
                        oCmd.Parameters.Add("@DireccionProveedor", SqlDbType.VarChar).Value = DireccionProveedor
                        oCmd.Parameters.Add("@TelefonoProveedor", SqlDbType.Char).Value = TelefonoProveedor
                        oCmd.Parameters.Add("@EmailProveedor", SqlDbType.VarChar).Value = EmailProveedor
                        oCmd.Parameters.Add("@RepresentanteProveedor", SqlDbType.VarChar).Value = RepresentanteProveedor
                        oCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Proveedor = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Proveedor = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '-----------------------------------------------------------ELIMINAR------------------------------------------------------
    Public Function fun_eliminar_proveedor(ByVal IdProveedor As String) As String
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
                    oCmd.CommandText = "sp_eliminar_proveedor"
                    oCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '**************************************************   BUSCAR LIKE          *************************
    Public Function Buscar_RazonSocialProveedor_Like(ByVal Buscar As String) As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "Buscar_RazonSocialProveedor_Like"
                    cmd.Parameters.Add("@RazonSocialProveedor", SqlDbType.VarChar).Value = Buscar
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    Public Function Buscar_RucProveedor_Like(ByVal Buscar As String) As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "Buscar_RucProveedor_Like"
                    cmd.Parameters.Add("@RucProveedor", SqlDbType.VarChar).Value = Buscar
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    Public Function Buscar_RepresentanteProveedor_Like(ByVal Buscar As String) As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "Buscar_RepresentanteProveedor_Like"
                    cmd.Parameters.Add("@RepresentanteProveedor", SqlDbType.VarChar).Value = Buscar
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO PROVEEDOR ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Proveedor() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_proveedor"
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
