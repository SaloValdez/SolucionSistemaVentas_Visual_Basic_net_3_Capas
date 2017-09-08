Imports System.Data.SqlClient

Public Class ClsComprobante
    '--------------------------------listar 
    Function Fun_Listar_Comprobante() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_lista_comprobante"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    ''''''''''''''''''''''''''''''''''''''''''''' CLASE COMPROBANTE'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function listar_comprobante_fecha(ByVal fi As String, ByVal ff As String) As DataSet
        Dim Ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_buscar_fecha_comprobante"
                    oCmd.Parameters.Add("@fi", SqlDbType.Char).Value = fi
                    oCmd.Parameters.Add("@ff", SqlDbType.Char).Value = ff
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function

    Function listar_comprobante_numero(ByVal numero As String) As DataSet
        Dim Ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_buscar_numero_comprobante"
                    oCmd.Parameters.Add("@NumeroFactura", SqlDbType.Char).Value = numero
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    'cargar combo tipo comprobante
    Function fun_cargarcombo_tipocomprobante() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_cargarcombo_tipocomprobante"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    ' comprobante venta------
    'cargar combo cliente
    Function fun_cargarcombo_cliente() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_cargarcombo_cliente"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    'cargar combo producto
    Function fun_cargarcombo_producto() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_cargarcombo_producto"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    'cargar texbox precio producto
    Function fun_cargartexbox_precioproducto(ByVal Id_Producto As Integer) As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_cargartexbox_precioproducto"
                    ocmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Id_Producto
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    'cargar texbox stock producto
    Function fun_cargartexbox_stockproducto(ByVal Id_Producto As Integer) As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_cargartexbox_stockproducto"
                    ocmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Id_Producto
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    'cargar texbox stock mininimo producto
    Function fun_cargartexbox_stockminproducto(ByVal Id_Producto As Integer) As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_cargartexbox_stockminproducto"
                    ocmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Id_Producto
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    'insertar comprobante
    Function fun_insertar_comprobante(ByVal NumeroComprobante As String, _
                                      ByVal SerieComprobante As String, _
                                      ByVal IdCliente As Integer, _
                                      ByVal IdEmpleado As Integer, _
                                      ByVal IdTipoComprobante As Integer,
                                      ByVal FechaComprobante As Date, _
                                      ByVal IgvComprobante As Double, _
                                      ByVal TotalComprobante As Double, _
                                      ByVal MensajeComprobante As String, _
                                      ByVal EstadoComprobante As String) As Integer
        Dim iret As Integer
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_insertar_comprobante"
                    ocmd.Parameters.Add("@NumeroComprobante", SqlDbType.Int).Value = NumeroComprobante
                    ocmd.Parameters.Add("@SerieComprobante", SqlDbType.Char).Value = SerieComprobante
                    ocmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente
                    ocmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado
                    ocmd.Parameters.Add("@IdTipoComprobante", SqlDbType.Char).Value = IdTipoComprobante
                    ocmd.Parameters.Add("@FechaComprobante", SqlDbType.Date).Value = FechaComprobante
                    ocmd.Parameters.Add("@IgvComprobante", SqlDbType.Decimal).Value = IgvComprobante
                    ocmd.Parameters.Add("@TotalComprobante", SqlDbType.Decimal).Value = TotalComprobante
                    ocmd.Parameters.Add("@MensajeComprobante ", SqlDbType.VarChar).Value = MensajeComprobante
                    ocmd.Parameters.Add("@EstadoComprobante ", SqlDbType.VarChar).Value = EstadoComprobante
                    ocn.Open()
                    iret = ocmd.ExecuteScalar()
                    ocn.Close()

                End Using
            End Using
        End Using
        Return iret
    End Function
    'insertar detalle comprobante
    Function fun_insertar_detallecomprobante(ByVal IdComprobante As Integer, _
                                             ByVal IdProducto As Integer, _
                                             ByVal CantidadDetalleComprobante As Integer, _
                                             ByVal PrecioDetalleComprobante As Double, _
                                             ByVal SubtotalDetalleComprobante As Double) As Integer  'ByVal CodigoProducto As Integer, _
        Dim iret As Integer
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_insertar_detalle_comprobante"
                    ocmd.Parameters.Add("@IdComprobante", SqlDbType.Int).Value = IdComprobante
                    ocmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = IdProducto
                    'ocmd.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = CodigoProducto
                    ocmd.Parameters.Add("@CantidadDetalleComrpobante", SqlDbType.Decimal).Value = CantidadDetalleComprobante
                    ocmd.Parameters.Add("@PrecioDetalleComprobante", SqlDbType.Decimal).Value = PrecioDetalleComprobante
                    ocmd.Parameters.Add("@SubtotalDetalleComprobante", SqlDbType.Decimal).Value = SubtotalDetalleComprobante
                    ocn.Open()
                    iret = ocmd.ExecuteScalar()
                    ocn.Close()

                End Using
            End Using
        End Using
        Return iret
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO COMPROBANTE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Comprobante() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_comprobante"
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
