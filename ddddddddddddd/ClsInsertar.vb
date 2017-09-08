Imports System.Data.SqlClient
Public Class ClsInsertar
    Public Function fun_insertar_Area(ByVal NombreArea As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_area"
                    oCmd.Parameters.Add("@NombreArea", SqlDbType.VarChar).Value = NombreArea
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


    Public Function fun_insertar_Cargo(ByVal NombreCArgo As String) As String
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
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


    Public Function fun_insertar_Categoria(ByVal DescripcionCategoria As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_categoria"
                    oCmd.Parameters.Add("@DescripcionCategoria", SqlDbType.VarChar).Value = DescripcionCategoria
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


    Public Function fun_insertar_Cliente(ByVal NombreCliente As String, _
                                          ByVal ApellidoCliente As String, _
                                          ByVal DniCliente As String, _
                                          ByVal RucCliente As String, _
                                          ByVal DireccionCliente As String, _
                                          ByVal TelefonoCliente As String) As String
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
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


    Public Class ClSinsertar
        Public Function fun_insertar_Marca(ByVal DetalleMarca As String) As String
            Dim iRet As Integer
            Dim Ds As New DataSet
            Dim objcadenaconexion As New BCventas.ClsConexion
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = objcadenaconexion.conexion
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_insertar_marca"
                        oCmd.Parameters.Add("@DetalleMarca", SqlDbType.VarChar).Value = DetalleMarca
                        oCn.Open()
                        iRet = oCmd.ExecuteScalar()
                        oCn.Close()
                    End Using
                End Using
            End Using
            Return iRet
        End Function
        Public Function fun_insertar_Producto(ByVal CodigoProducto As String, _
                                            ByVal IdProveedor As Integer, _
                                            ByVal DescripcionProducto As String, _
                                            ByVal CantidadProducto As Integer, _
                                            ByVal PrecioProducto As Decimal, _
                                            ByVal PrecioVentaProducto As Decimal, _
                                            ByVal IdCategoria As Integer, _
                                            ByVal IdSubCategoria As Integer, _
                                            ByVal IdMarca As Integer) As String
            Dim iRet As Integer
            Dim Ds As New DataSet
            Dim objcadenaconexion As New BCventas.ClsConexion
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = objcadenaconexion.conexion
                        oCmdsss.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_insertar_producto"
                        oCmd.Parameters.Add("@CodigoProducto", SqlDbType.VarChar).Value = CodigoProducto
                        oCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor
                        oCmd.Parameters.Add("@DescripcionProducto", SqlDbType.VarChar).Value = DescripcionProducto
                        oCmd.Parameters.Add("@CantidadProducto", SqlDbType.Int).Value = CantidadProducto
                        oCmd.Parameters.Add("@PrecioProducto", SqlDbType.Decimal).Value = PrecioProducto
                        oCmd.Parameters.Add("@PrecioVentaProducto", SqlDbType.Decimal).Value = PrecioVentaProducto
                        oCmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = IdCategoria
                        oCmd.Parameters.Add("@IdSubCategoria", SqlDbType.Int).Value = IdSubCategoria
                        oCmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = IdMarca
                        oCn.Open()
                        iRet = oCmd.ExecuteScalar()
                        oCn.Close()
                    End Using
                End Using
            End Using
            Return iRet
        End Function
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
        Public Function fun_insertar_Tipo_Comprobante(ByVal DetalleTipoComprobante As String) As String
            Dim iRet As Integer
            Dim Ds As New DataSet
            Dim objcadenaconexion As New BCventas.ClsConexion
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = objcadenaconexion.conexion
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_insertar_tipo_comprobante"
                        oCmd.Parameters.Add("@DetalleTipoComprobante", SqlDbType.VarChar).Value = DetalleTipoComprobante
                        oCn.Open()
                        iRet = oCmd.ExecuteScalar()
                        oCn.Close()
                    End Using
                End Using
            End Using
            Return iRet
        End Function
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
    End Class
End Class
