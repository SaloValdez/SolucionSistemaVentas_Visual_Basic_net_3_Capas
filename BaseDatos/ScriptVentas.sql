
--SP procedure login usuario
	create proc sp_login_usuario
	@usuario varchar(20),
	@contrasena varchar(20)
	as 
	select IdUsuario from USUARIO
	where CuentaUsuario=RTRIM(@usuario) AND ClaveUsuario = RTRIM		    (@contrasena)
--USUARIO--------------------------------------------------------------------------------------------
--SP eleiminar empleado
	create proc sp_eliminar_empleado
	@IdEmpleado int
	as
	delete from EMPLEADO
	where IdEmpleado= @IdEmpleado
--SP insertar empleado
	create proc sp_insertar_empleado
	@NombreEmpleado varchar(20),
	@ApellidoEmpleado varchar(30),
	@DniEmpleado char(8),
	@FechaNacimientoEmpleado date,
	@TelefonoEmpleado char(11),
	@DireccionEmpleado varchar(80),
	@IdArea int,
	@IdCargo int
	as
	insert into empleado (NombreEmpleado,ApellidoEmpleado,DniEmpleado,FechaNacimientoEmpleado,TelefonoEmpleado,DireccionEmpleado,IdArea,IdCargo)
	values (@NombreEmpleado,@ApellidoEmpleado,@DniEmpleado,@FechaNacimientoEmpleado,@TelefonoEmpleado,@DireccionEmpleado,@IdArea,@IdCargo)
	select max(IdEmpleado) from empleado
--SP listar empleado
	create proc  sp_listar_empleado
	as
	select idEmpleado 'Codigo',NombreEmpleado as 'Nombres',ApellidoEmpleado as 'Apellidos',DniEmpleado as 'Dni',FechaNacimientoEmpleado as'Fecha Nacimiento',TelefonoEmpleado as 'telefono',DireccionEmpleado as 'Direccion',IdArea as 'Area',IdCargo AS 'Cargo'
	from EMPLEADO
--cargar combo AREA
 create proc sp_cargarcombo_area_empleado
 as
 select idarea as 'ID', nombrearea from AREA
 --cargar combo 
 create proc sp_cargarcombo_cargo_empleado
 as
 select idcargo as 'ID', nombrecargo from CARGO



--SP actualizar empleado
	create proc sp_actualizar_empleado
	@IdEmpleado int,
	@NombreEmpleado varchar(20),
	@ApellidoEmpleado varchar(30),
	@DniEmpleado char(8),
	@FechaNacimientoEmpleado date,
	@TelefonoEmpleado char(11),
	@DireccionEmpleado varchar(80),
	@IdArea int,
	@IdCargo int
	as
	update EMPLEADO set
	NombreEmpleado=@NombreEmpleado,
	ApellidoEmpleado=@ApellidoEmpleado,
	DniEmpleado=@DniEmpleado,
	FechaNacimientoEmpleado=@FechaNacimientoEmpleado,
	TelefonoEmpleado=@TelefonoEmpleado,
	DireccionEmpleado=@DireccionEmpleado ,
	IdArea=@IdArea,
	IdCargo=@IdCargo
	where IdEmpleado = @IdEmpleado

--CONSULTAS------------------------------------------------------------------
--Buscar por numero factura
	create proc sp_buscar_numero_comprobante
	@NumeroFactura char(10)
	as
	select idfactura,(rtrim(seriefactura)+ '-' + rtrim(numerofactura)) as 'NUMERO', FechaFactura,IgvFactura,TotalFactura 
	from FACTURA
	where NumeroFactura = @NumeroFactura 

--Buscar por fecha
	create proc sp_buscar_fecha_comprobante
	@fi char(10),
	@ff char(10)
	as
	select idfactura,(rtrim(seriefactura)+ '-' + rtrim(NumeroFactura)) as 'NUMERO', fechafactura, igvfactura,totalfactura 
	from FACTURA
	where FechaFactura >= @fi
	and FechaFactura < dateadd(day,1,@ff)

--COMPROBANTE----VENTAS----------------------------------------------------------------------------------------------------------------------------
--cargar combo tipo comprobante
	create proc sp_cargarcombo_tipocomprobante
	as
	select IdTipoComprobante,DetalleTipoComprobante
	from TIPO_COMPROBANTE
---cargar combo producto
	create proc sp_cargarcombo_producto
	as
	select idproducto,DescripcionProducto
	from PRODUCTO
--cargar combo cliente
	create proc sp_cargarcombo_cliente
	as 
	select IdCliente,NombreCliente
	from cliente
--cargar texbox precio producto
	create proc sp_cargartexbox_precioproducto
	@IdProducto int
	as
	select PrecioVentaProducto
	from PRODUCTO
	where IdProducto = @IdProducto
--cargar texbox stock producto
	create proc sp_cargartexbox_stockproducto
	@IdProducto int
	as
	select CantidadProducto
	from PRODUCTO
	where IdProducto = @IdProducto
--cargar texbox stock minimo producto
	create proc sp_cargartexbox_stockminproducto
	@IdProducto int
	as
	select StockMinimoProducto
	from PRODUCTO
	where IdProducto = @IdProducto
--insertar comprobante
	create proc sp_insertar_comprobante
	@NumeroComprobante char(10),
	@SerieComprobante char(10),
	@IdCliente int,
	@IdEmpleado int,
	@IdTipoComprobante int,
	@FechaComprobante date,
	@IgvComprobante decimal(18,2),
	@TotalComprobante decimal,
	@MensajeComprobante varchar(50),
	@EstadoComprobante varchar(50)
	as
	insert into COMPROBANTE(NumeroComprobante,SerieComprobante,IdCliente,IdEmpleado,IdTipoComprobante,FechaComprobante,IgvComprobante,MensajeComprobante,EstadoComprobante)
	values(@NumeroComprobante,@SerieComprobante,@IdCliente,@IdEmpleado,@IdTipoComprobante,@FechaComprobante,@IgvComprobante,@TotalComprobante,@MensajeComprobante,@EstadoComprobante)
	select max(IdComprobante)
	from COMPROBANTE
--insertar detalle comprobante
	create proc sp_insertar_detalle_comprobante
	@IdComprobante int,
	@IdProducto int,
	@CodigoProducto int,
	@CantidadDetalleComrpobante int,
	@SubtotalDetalleComprobante decimal(18,2),
	@PrecioDetalleComprobante decimal(18,2)
	as
	insert DETALLE_COMPROBANTE (IdComprobante,IdProducto,CodigoProducto,CantidadDetalleComprobante,SubtotalDetalleComprobante,PrecioDetalleComprobante)
	values(@IdComprobante,@IdProducto,@CodigoProducto,@CantidadDetalleComrpobante,@SubtotalDetalleComprobante,@PrecioDetalleComprobante)

