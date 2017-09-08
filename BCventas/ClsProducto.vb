Imports System.Data.SqlClient

Public Class ClsProducto
    '--------------------------------------------LISTAR---------------------------------------------------------------------
    Function Fun_Listar_Producto() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_lista_producto"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '-------------------------------------------INSERTAR------------------------------------------------------------------
    Public Function fun_insertar_Producto(ByVal CodigoProducto As String, _
                                            ByVal IdProveedor As Integer, _
                                            ByVal DescripcionProducto As String, _
                                            ByVal CantidadProducto As Integer, _
                                            ByVal PrecioCostoProducto As Decimal, _
                                            ByVal PrecioVentaProducto As Decimal, _
                                            ByVal StockMinimoProducto As Integer, _
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
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_producto"
                    oCmd.Parameters.Add("@CodigoProducto", SqlDbType.VarChar).Value = CodigoProducto
                    oCmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor
                    oCmd.Parameters.Add("@DescripcionProducto", SqlDbType.VarChar).Value = DescripcionProducto
                    oCmd.Parameters.Add("@CantidadProducto", SqlDbType.Int).Value = CantidadProducto
                    oCmd.Parameters.Add("@PrecioCostoProducto", SqlDbType.Decimal).Value = PrecioCostoProducto
                    oCmd.Parameters.Add("@PrecioVentaProducto", SqlDbType.Decimal).Value = PrecioVentaProducto
                    oCmd.Parameters.Add("@StockMinimoProducto", SqlDbType.Int).Value = StockMinimoProducto
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
    '------------------------------------------ACTUALIZAR
    Public Function fun_actualizar_Producto(ByVal CodigoProducto As String, _
                                          ByVal IdProveedor As Integer, _
                                          ByVal DescripcionProducto As String, _
                                          ByVal CantidadProducto As Integer, _
                                          ByVal PrecioCostoProducto As Decimal, _
                                          ByVal PrecioVentaProducto As Decimal, _
                                          ByVal StockMinimoProducto As Integer, _
                                          ByVal IdCategoria As Integer, _
                                          ByVal IdSubCategortia As Integer, _
                                          ByVal IdMarca As Integer, _
                                          ByVal IdProducto As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_Producto"
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
                        oCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = IdProducto
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
    '----------------------------------------------------ELIMINAR--------------------------------------------------------------
    Public Function fun_eliminar_producto(ByVal IdProducto As String) As String
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
                    oCmd.CommandText = "sp_eliminar_producto"
                    oCmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = IdProducto
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO PRODUCTO ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Producto() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_producto"
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
