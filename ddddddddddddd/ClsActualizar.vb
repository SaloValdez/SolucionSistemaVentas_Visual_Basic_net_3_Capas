Imports System.Data.SqlClient

Public Class ClsActualizar
    Public Function fun_actualizar_Cargo(ByVal NombreCargo As String, _
                                            ByVal IdArea As Integer) As String
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

    Public Function fun_actualizar_Categoria(ByRef descripcion As String) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Categoria"
                        oCmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Categoria = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Categoria = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function


    Public Function fun_actualizar_cliente(ByVal NombreCliente As String, _
                                            ByVal ApellidoCliente As String, _
                                            ByVal DniCliente As String, _
                                            ByRef RucCliente As String, _
                                            ByVal DireccionCliente As String, _
                                            ByVal TelefonoCliente As String, _
                                            ByVal EmailCliente As String) As String
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



    Public Function fun_actualizar_Marca(ByVal DetalleMarca As String) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Marca"
                        oCmd.Parameters.Add("@DetalleMarca", SqlDbType.VarChar).Value = DetalleMarca
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Marca = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Marca = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function


    Public Function fun_actualizar_Producto(ByVal CodigoProducto As String, _
                                          ByVal IdProveedor As Integer, _
                                          ByVal DescripcionProducto As String, _
                                          ByVal CantidadProducto As Integer, _
                                          ByVal PrecioCostoProducto As Decimal, _
                                          ByVal PrecioVentaProducto As Decimal, _
                                          ByVal StockMinimoProducto As Integer, _
                                          ByVal IdCategoria As Integer, _
                                          ByVal IdSubCategortia As Integer, _
                                          ByVal IdMarca As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Proucto"
                        oCmd.Parameters.Add("@CodigoProducto", SqlDbType.VarChar).Value = CodigoProducto
                        oCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor
                        oCmd.Parameters.Add("@DescripcionProducto", SqlDbType.VarChar).Value = DescripcionProducto
                        oCmd.Parameters.Add("@CantidadProducto", SqlDbType.Int).Value = CantidadProducto
                        oCmd.Parameters.Add("@PrecioCostoProducto", SqlDbType.Decimal).Value = PrecioCostoProducto
                        oCmd.Parameters.Add("@PrecioVentaProducto", SqlDbType.Decimal).Value = PrecioVentaProducto
                        oCmd.Parameters.Add("@StockMinimoProducto", SqlDbType.Int).Value = StockMinimoProducto
                        oCmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = IdCategoria
                        oCmd.Parameters.Add("@IdSubCategortia", SqlDbType.Int).Value = IdSubCategortia
                        oCmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = IdMarca
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Producto = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Producto = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function


    Public Function fun_actualizar_Proveedor(ByVal RazonSocialProveedor As String, _
                                          ByVal RucProveedor As Char, _
                                          ByVal DireccionProveedor As String, _
                                          ByVal TelefonoProveedor As Char, _
                                          ByVal EmailProveedor As String, _
                                          ByVal RepresentanteProveedor As String) As String
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


    Public Function fun_actualizar_TipoComprobante(ByVal DetalleTipoComprobante As String) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_TipoComprobante"
                        oCmd.Parameters.Add("@DetalleTipoComprobante", SqlDbType.VarChar).Value = DetalleTipoComprobante
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_TipoComprobante = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_TipoComprobante = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function

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

End Class
