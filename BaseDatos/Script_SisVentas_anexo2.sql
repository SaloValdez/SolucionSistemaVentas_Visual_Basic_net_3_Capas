Alter authorization on database::DBSISVENTAS to sa;

CREATE DATABASE DBSISVENTAS
GO
USE [DBSISVENTAS]
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_empleado]    Script Date: 30/12/2016 19:30:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_actualizar_empleado]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_fecha_comprobante]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_buscar_fecha_comprobante]
@fi char(10),
@ff char(10)
as
select idcomprobante,(rtrim(seriecomprobante)+ '-' + rtrim(Numerocomprobante)) as 'NUMERO', fechacomprobante, igvcomprobante,totalcomprobante
from comprobante
where Fechacomprobante >= @fi
and Fechacomprobante < dateadd(day,1,@ff)
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_numero_comprobante]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_buscar_numero_comprobante]
	@NumeroFactura char(10)
	as
	select idcomprobante,(rtrim(seriecomprobante)+ '-' + rtrim(numerocomprobante)) as 'NUMERO', Fechacomprobante,Igvcomprobante,Totalcomprobante 
from comprobante
where Numerocomprobante = @NumeroFactura 
GO
/****** Object:  StoredProcedure [dbo].[sp_cargarcombo_area_empleado]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_cargarcombo_area_empleado]
 as
 select idarea as 'ID', nombrearea from AREA

GO
/****** Object:  StoredProcedure [dbo].[sp_cargarcombo_cargo_empleado]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_cargarcombo_cargo_empleado]
 as
 select idcargo as 'ID', nombrecargo from CARGO
GO
/****** Object:  StoredProcedure [dbo].[sp_cargarcombo_cliente]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_cargarcombo_cliente]
	as 
	select IdCliente,NombreCliente
	from cliente
GO
/****** Object:  StoredProcedure [dbo].[sp_cargarcombo_producto]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_cargarcombo_producto]
	as
	select idproducto,DescripcionProducto
	from PRODUCTO
GO
/****** Object:  StoredProcedure [dbo].[sp_cargarcombo_tipocomprobante]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_cargarcombo_tipocomprobante]
	as
	select IdTipoComprobante,DetalleTipoComprobante
	from TIPO_COMPROBANTE
GO
/****** Object:  StoredProcedure [dbo].[sp_cargartexbox_precioproducto]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_cargartexbox_precioproducto]
	@IdProducto int
	as
	select PrecioVentaProducto
	from PRODUCTO
	where IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_cargartexbox_stockminproducto]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_cargartexbox_stockminproducto]
	@IdProducto int
	as
	select StockMinimoProducto
	from PRODUCTO
	where IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_cargartexbox_stockproducto]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_cargartexbox_stockproducto]
	@IdProducto int
	as
	select CantidadProducto
	from PRODUCTO
	where IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_empleado]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_eliminar_empleado]
	@IdEmpleado int
	as
	delete from EMPLEADO
	where IdEmpleado= @IdEmpleado
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_comprobante]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_insertar_comprobante]
	@NumeroComprobante char(10),
	@SerieComprobante char(10),
	@IdCliente int,
	@IdEmpleado int,
	@IdTipoComprobante int,
	@FechaComprobante date,
	@IgvComprobante decimal(18,2),
	@TotalComprobante decimal(18,2),
	@MensajeComprobante varchar(50),
	@EstadoComprobante varchar(50)
	as
	insert into COMPROBANTE(NumeroComprobante,SerieComprobante,IdCliente,IdEmpleado,IdTipoComprobante,FechaComprobante,IgvComprobante,TotalComprobante,MensajeComprobante,EstadoComprobante)
	values(@NumeroComprobante,@SerieComprobante,@IdCliente,@IdEmpleado,@IdTipoComprobante,@FechaComprobante,@IgvComprobante,@TotalComprobante,@MensajeComprobante,@EstadoComprobante)
	select max(IdComprobante)
	from COMPROBANTE
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_detalle_comprobante]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE proc [dbo].[sp_insertar_detalle_comprobante]
	@IdComprobante int,
	@IdProducto int,
	--@CodigoProducto int,
	@CantidadDetalleComrpobante int,
	@PrecioDetalleComprobante decimal(18,2),
	@SubtotalDetalleComprobante decimal(18,2)
	
	as
	insert DETALLE_COMPROBANTE (IdComprobante,IdProducto,/*CodigoProducto,*/CantidadDetalleComprobante,PrecioDetalleComprobante,SubtotalDetalleComprobante)
	values(@IdComprobante,@IdProducto,/*@CodigoProducto,*/@PrecioDetalleComprobante,@CantidadDetalleComrpobante,@SubtotalDetalleComprobante)
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_empleado]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_insertar_empleado]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_empleado]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc  [dbo].[sp_listar_empleado]
	as
	select idEmpleado 'Codigo',NombreEmpleado as 'Nombres',ApellidoEmpleado as 'Apellidos',DniEmpleado as 'Dni',FechaNacimientoEmpleado as'Fecha Nacimiento',TelefonoEmpleado as 'telefono',DireccionEmpleado as 'Direccion',IdArea as 'Area',IdCargo AS 'Cargo'
	from EMPLEADO

GO
/****** Object:  StoredProcedure [dbo].[sp_login_usuario]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_login_usuario] 
@usuario varchar(20),
@contrasena varchar(20)
as 
select IdUsuario from USUARIO
where CuentaUsuario=RTRIM(@usuario) AND ClaveUsuario = RTRIM(@contrasena)
GO
/****** Object:  StoredProcedure [dbo].[usp_loginb]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_loginb]
@usuario varchar(20),
@contrasena varchar(20)
as 
select ID from USUARIOS
where USUARIO=RTRIM(@usuario) AND CONTRASENA = RTRIM(@contrasena)
GO
/****** Object:  Table [dbo].[AREA]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AREA](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[NombreArea] [varchar](30) NULL,
 CONSTRAINT [PK_AREA] PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CARGO]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CARGO](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
	[NombreCargo] [varchar](30) NULL,
 CONSTRAINT [PK_CARGO] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionCategoria] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](50) NULL,
	[ApellidoCliente] [varchar](50) NULL,
	[DniCliente] [varchar](8) NULL,
	[RucCliente] [char](11) NULL,
	[DireccionCliente] [varchar](150) NULL,
	[TelefonoCliente] [char](11) NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMPROBANTE]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPROBANTE](
	[IdComprobante] [int] IDENTITY(1,1) NOT NULL,
	[NumeroComprobante] [char](10) NULL,
	[SerieComprobante] [char](10) NULL,
	[IdCliente] [int] NULL,
	[IdEmpleado] [int] NULL,
	[IdTipoComprobante] [int] NULL,
	[FechaComprobante] [date] NULL,
	[IgvComprobante] [decimal](18, 2) NULL,
	[TotalComprobante] [decimal](18, 2) NULL,
	[MensajeComprobante] [varchar](50) NULL,
	[EstadoComprobante] [varchar](50) NULL,
 CONSTRAINT [PK_FACTURA] PRIMARY KEY CLUSTERED 
(
	[IdComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETALLE_COMPROBANTE]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_COMPROBANTE](
	[IdDetalleComprobante] [int] IDENTITY(1,1) NOT NULL,
	[IdComprobante] [int] NULL,
	[IdProducto] [int] NULL,
	[CantidadDetalleComprobante] [int] NULL,
	[PrecioDetalleComprobante] [decimal](18, 2) NULL,
	[SubtotalDetalleComprobante] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DETALLE_FACTURA] PRIMARY KEY CLUSTERED 
(
	[IdDetalleComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DETALLE_INVENTARIO]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DETALLE_INVENTARIO](
	[IdDetalleInventario] [int] NULL,
	[IdProducto] [int] NULL,
	[CodigoProducto] [varchar](13) NULL,
	[IdInventario] [int] NULL,
	[CantidadDetalleInventario] [int] NULL,
	[FechaElaboracionDetalleInventario] [date] NULL,
	[FechaExpiracionDetalleInventario] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLEADO](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [varchar](20) NULL,
	[ApellidoEmpleado] [varchar](30) NULL,
	[DniEmpleado] [char](10) NULL,
	[FechaNacimientoEmpleado] [date] NULL,
	[TelefonoEmpleado] [char](11) NULL,
	[DireccionEmpleado] [varchar](80) NULL,
	[IdArea] [int] NULL,
	[IdCargo] [int] NULL,
 CONSTRAINT [PK_EMPLEADO] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INVENTARIO]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INVENTARIO](
	[IdInvenatrio] [int] NULL,
	[Inventario] [varchar](50) NULL,
	[UbicacacionInventario] [varchar](50) NULL,
	[DescripcionInventario] [varchar](150) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MARCA](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[DetalleMarca] [varchar](50) NULL,
 CONSTRAINT [PK_MARCA] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [varchar](13) NULL,
	[IdProveedor] [int] NULL,
	[DescripcionProducto] [varchar](40) NULL,
	[CantidadProducto] [int] NULL,
	[PrecioCostoProducto] [decimal](18, 2) NULL,
	[PrecioVentaProducto] [decimal](18, 2) NULL,
	[StockMinimoProducto] [int] NULL,
	[IdCategoria] [int] NULL,
	[IdSubCategoria] [int] NULL,
	[IdMarca] [int] NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocialProveedor] [varchar](40) NULL,
	[RucProveedor] [char](11) NULL,
	[DireccionProveedor] [varchar](80) NULL,
	[TelefonoProveedor] [char](11) NULL,
	[EmailProveedor] [varchar](40) NULL,
	[RepresentanteProveedor] [varchar](40) NULL,
 CONSTRAINT [PK_PROVEEDOR] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SUBCATEGORIA]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SUBCATEGORIA](
	[IdSubCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DestalleSubCategoria] [varchar](50) NOT NULL,
	[IdCategoria] [int] NULL,
 CONSTRAINT [PK_SUBCATEGORIA_1] PRIMARY KEY CLUSTERED 
(
	[IdSubCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tabla1]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tabla1](
	[idTipoDocumento] [int] NULL,
	[Nombre] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPO_COMPROBANTE]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPO_COMPROBANTE](
	[IdTipoComprobante] [int] IDENTITY(1,1) NOT NULL,
	[DetalleTipoComprobante] [varchar](20) NULL,
 CONSTRAINT [PK_TIPO_COMPROBANTE] PRIMARY KEY CLUSTERED 
(
	[IdTipoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[CuentaUsuario] [varchar](20) NULL,
	[ClaveUsuario] [varchar](20) NULL,
	[IdEmpleado] [int] NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 30/12/2016 19:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USUARIO] [varchar](20) NULL,
	[CONTRASENA] [varchar](20) NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AREA] ON 

INSERT [dbo].[AREA] ([IdArea], [NombreArea]) VALUES (1, N'ADMINISTRACION')
INSERT [dbo].[AREA] ([IdArea], [NombreArea]) VALUES (2, N'VENTAS')
INSERT [dbo].[AREA] ([IdArea], [NombreArea]) VALUES (3, N'LOGISTICA')
INSERT [dbo].[AREA] ([IdArea], [NombreArea]) VALUES (4, N'MARKETING')
INSERT [dbo].[AREA] ([IdArea], [NombreArea]) VALUES (5, N'INFORMATICA Y SISTEMAS')
SET IDENTITY_INSERT [dbo].[AREA] OFF
SET IDENTITY_INSERT [dbo].[CARGO] ON 

INSERT [dbo].[CARGO] ([IdCargo], [NombreCargo]) VALUES (1, N'JEFE DE INFORMATICA')
INSERT [dbo].[CARGO] ([IdCargo], [NombreCargo]) VALUES (2, N'PROMOTOR PUNTOS DE VENTAS')
INSERT [dbo].[CARGO] ([IdCargo], [NombreCargo]) VALUES (3, N'ADMINISTRADOR')
INSERT [dbo].[CARGO] ([IdCargo], [NombreCargo]) VALUES (4, N'JEFE DE LOGISTICA')
INSERT [dbo].[CARGO] ([IdCargo], [NombreCargo]) VALUES (5, N'JEFE DE VENTAS')
SET IDENTITY_INSERT [dbo].[CARGO] OFF
SET IDENTITY_INSERT [dbo].[CATEGORIA] ON 

INSERT [dbo].[CATEGORIA] ([IdCategoria], [DescripcionCategoria]) VALUES (1, N'PAPELERIA')
INSERT [dbo].[CATEGORIA] ([IdCategoria], [DescripcionCategoria]) VALUES (2, N'LIBROS')
INSERT [dbo].[CATEGORIA] ([IdCategoria], [DescripcionCategoria]) VALUES (3, N'UTILES DE CARTUCHERA')
INSERT [dbo].[CATEGORIA] ([IdCategoria], [DescripcionCategoria]) VALUES (4, N'CUADERNOS')
INSERT [dbo].[CATEGORIA] ([IdCategoria], [DescripcionCategoria]) VALUES (5, N'ALBUN')
SET IDENTITY_INSERT [dbo].[CATEGORIA] OFF
SET IDENTITY_INSERT [dbo].[CLIENTE] ON 

INSERT [dbo].[CLIENTE] ([IdCliente], [NombreCliente], [ApellidoCliente], [DniCliente], [RucCliente], [DireccionCliente], [TelefonoCliente]) VALUES (1, N'MARIELL', N'TORRES TORRES', N'37246738', NULL, N'LAS BEGONIAS', N'34234523   ')
INSERT [dbo].[CLIENTE] ([IdCliente], [NombreCliente], [ApellidoCliente], [DniCliente], [RucCliente], [DireccionCliente], [TelefonoCliente]) VALUES (2, N'SAMUEL', N'SANCHES SALAS', N'37463457', NULL, N'JDSFSDKF', N'458345     ')
INSERT [dbo].[CLIENTE] ([IdCliente], [NombreCliente], [ApellidoCliente], [DniCliente], [RucCliente], [DireccionCliente], [TelefonoCliente]) VALUES (3, N'JUAN', N'TORRES', N'2342342', NULL, N'DGSDGS', N'34534      ')
INSERT [dbo].[CLIENTE] ([IdCliente], [NombreCliente], [ApellidoCliente], [DniCliente], [RucCliente], [DireccionCliente], [TelefonoCliente]) VALUES (4, N'SALAS', N'ROBLES', N'73462378', NULL, N'FGNDFJGND', N'459345     ')
SET IDENTITY_INSERT [dbo].[CLIENTE] OFF
SET IDENTITY_INSERT [dbo].[COMPROBANTE] ON 

INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (4, N'8999002344', N'34235235  ', 1, 2, NULL, CAST(0x5A390B00 AS Date), CAST(232.00 AS Decimal(18, 2)), CAST(3423.00 AS Decimal(18, 2)), N'gracias por su compra', N'buena')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (5, N'2323232323', N'34234234  ', 2, 1, NULL, CAST(0x343C0B00 AS Date), CAST(232.00 AS Decimal(18, 2)), CAST(23.00 AS Decimal(18, 2)), N'GRACIAS POR SU COMPRA', N'BUENA')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (6, N'3434343434', N'34343434  ', 3, 2, NULL, CAST(0x153C0B00 AS Date), CAST(342.00 AS Decimal(18, 2)), CAST(342.00 AS Decimal(18, 2)), N'SFDJSDFSDK', N'BUENA')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (7, N'3434343434', N'34343434  ', 2, 1, NULL, CAST(0x003C0B00 AS Date), CAST(234.00 AS Decimal(18, 2)), CAST(3434.00 AS Decimal(18, 2)), N'4DFSDFFSDD', N'EFDSFS')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (8, N'2323232323', N'32232323  ', 3, 2, NULL, CAST(0xD83B0B00 AS Date), CAST(3242.00 AS Decimal(18, 2)), CAST(34234.00 AS Decimal(18, 2)), N'DFGDFGDFG', N'DGDFGDFG')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (9, N'1212121212', N'12121212  ', 3, 2, NULL, CAST(0x9B3B0B00 AS Date), CAST(342.00 AS Decimal(18, 2)), CAST(34234.00 AS Decimal(18, 2)), N'SGDGSDGSD', N'DFGDFGD')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (10, N'234       ', N'324       ', 3, 1, 2, CAST(0x3F3C0B00 AS Date), NULL, CAST(48.00 AS Decimal(18, 2)), N'hola gracias por su compra', N'w')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (11, N'32423     ', N'32423     ', 2, 1, 1, CAST(0x3F3C0B00 AS Date), CAST(23.00 AS Decimal(18, 2)), CAST(27876.00 AS Decimal(18, 2)), N'hola mundo', N'1')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (12, N'234234    ', N'23423     ', 2, 1, 1, CAST(0x403C0B00 AS Date), CAST(2444.00 AS Decimal(18, 2)), CAST(3906.00 AS Decimal(18, 2)), N'34234', N'23')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (13, N'5757      ', N'575       ', 1, 2, 1, CAST(0x403C0B00 AS Date), CAST(23.00 AS Decimal(18, 2)), CAST(1080.00 AS Decimal(18, 2)), N'hola mundito', N'1')
INSERT [dbo].[COMPROBANTE] ([IdComprobante], [NumeroComprobante], [SerieComprobante], [IdCliente], [IdEmpleado], [IdTipoComprobante], [FechaComprobante], [IgvComprobante], [TotalComprobante], [MensajeComprobante], [EstadoComprobante]) VALUES (14, N'123       ', N'1213      ', 2, 1, 2, CAST(0x383C0B00 AS Date), CAST(3.00 AS Decimal(18, 2)), CAST(58374.00 AS Decimal(18, 2)), N'gfnfgn', N'fgfh')
SET IDENTITY_INSERT [dbo].[COMPROBANTE] OFF
SET IDENTITY_INSERT [dbo].[DETALLE_COMPROBANTE] ON 

INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (1, 11, 2, 6, CAST(2323.00 AS Decimal(18, 2)), CAST(13938.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (2, 11, 2, 6, CAST(2323.00 AS Decimal(18, 2)), CAST(13938.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (4, 12, 2, 6, CAST(23.00 AS Decimal(18, 2)), CAST(138.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (5, 12, 3, 7, CAST(234.00 AS Decimal(18, 2)), CAST(1638.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (6, 12, 2, 6, CAST(355.00 AS Decimal(18, 2)), CAST(2130.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (8, 13, 2, 6, CAST(45.00 AS Decimal(18, 2)), CAST(270.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (9, 13, 2, 6, CAST(45.00 AS Decimal(18, 2)), CAST(270.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (10, 13, 2, 6, CAST(45.00 AS Decimal(18, 2)), CAST(270.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (11, 13, 2, 6, CAST(45.00 AS Decimal(18, 2)), CAST(270.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (12, 14, 2, 6, CAST(3243.00 AS Decimal(18, 2)), CAST(19458.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (13, 14, 2, 6, CAST(3243.00 AS Decimal(18, 2)), CAST(19458.00 AS Decimal(18, 2)))
INSERT [dbo].[DETALLE_COMPROBANTE] ([IdDetalleComprobante], [IdComprobante], [IdProducto], [CantidadDetalleComprobante], [PrecioDetalleComprobante], [SubtotalDetalleComprobante]) VALUES (14, 14, 2, 6, CAST(3243.00 AS Decimal(18, 2)), CAST(19458.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[DETALLE_COMPROBANTE] OFF
SET IDENTITY_INSERT [dbo].[EMPLEADO] ON 

INSERT [dbo].[EMPLEADO] ([IdEmpleado], [NombreEmpleado], [ApellidoEmpleado], [DniEmpleado], [FechaNacimientoEmpleado], [TelefonoEmpleado], [DireccionEmpleado], [IdArea], [IdCargo]) VALUES (1, N'SALOMON', N'VALDEZ PACOHUANACO', N'452422542 ', CAST(0x89180B00 AS Date), N'952683524  ', N'AV. SIMON BOLIVAR Nº 234', 5, 1)
INSERT [dbo].[EMPLEADO] ([IdEmpleado], [NombreEmpleado], [ApellidoEmpleado], [DniEmpleado], [FechaNacimientoEmpleado], [TelefonoEmpleado], [DireccionEmpleado], [IdArea], [IdCargo]) VALUES (2, N'MILAGROS', N'VELEZ SANCHEZ', N'452452542 ', CAST(0x72160B00 AS Date), N'956325698  ', N'AV. LOS ANGAMOS Nº 234', 2, 2)
INSERT [dbo].[EMPLEADO] ([IdEmpleado], [NombreEmpleado], [ApellidoEmpleado], [DniEmpleado], [FechaNacimientoEmpleado], [TelefonoEmpleado], [DireccionEmpleado], [IdArea], [IdCargo]) VALUES (4, N'MILAGROS', N'VELEZ SANCHEZ', N'2342345   ', CAST(0xD9190B00 AS Date), N'54645666   ', N'JR. LOS CLAVELES', 3, 3)
SET IDENTITY_INSERT [dbo].[EMPLEADO] OFF
SET IDENTITY_INSERT [dbo].[MARCA] ON 

INSERT [dbo].[MARCA] ([IdMarca], [DetalleMarca]) VALUES (1, N'FABER CASTELL')
INSERT [dbo].[MARCA] ([IdMarca], [DetalleMarca]) VALUES (2, N'PUPPIES')
INSERT [dbo].[MARCA] ([IdMarca], [DetalleMarca]) VALUES (3, N'STANFORD')
INSERT [dbo].[MARCA] ([IdMarca], [DetalleMarca]) VALUES (4, N'MO FAN GE')
INSERT [dbo].[MARCA] ([IdMarca], [DetalleMarca]) VALUES (5, N'ARTESCO')
SET IDENTITY_INSERT [dbo].[MARCA] OFF
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 

INSERT [dbo].[PRODUCTO] ([IdProducto], [CodigoProducto], [IdProveedor], [DescripcionProducto], [CantidadProducto], [PrecioCostoProducto], [PrecioVentaProducto], [StockMinimoProducto], [IdCategoria], [IdSubCategoria], [IdMarca]) VALUES (1, N'P0990523', 1, N'HOJAS DE COLORES A4', 4344, CAST(34.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), 50, 1, NULL, 4)
INSERT [dbo].[PRODUCTO] ([IdProducto], [CodigoProducto], [IdProveedor], [DescripcionProducto], [CantidadProducto], [PrecioCostoProducto], [PrecioVentaProducto], [StockMinimoProducto], [IdCategoria], [IdSubCategoria], [IdMarca]) VALUES (2, N'P0984333', 2, N'CUADERNO UNIVERSITARIO SATNDAR', 60, CAST(3.50 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), 50, 4, NULL, 3)
INSERT [dbo].[PRODUCTO] ([IdProducto], [CodigoProducto], [IdProveedor], [DescripcionProducto], [CantidadProducto], [PrecioCostoProducto], [PrecioVentaProducto], [StockMinimoProducto], [IdCategoria], [IdSubCategoria], [IdMarca]) VALUES (3, N'P7867544', 3, N'CUADERNO UNIVERSITARIO ANILLADO', 40, CAST(5.00 AS Decimal(18, 2)), CAST(7.00 AS Decimal(18, 2)), 50, 4, NULL, 3)
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
SET IDENTITY_INSERT [dbo].[PROVEEDOR] ON 

INSERT [dbo].[PROVEEDOR] ([IdProveedor], [RazonSocialProveedor], [RucProveedor], [DireccionProveedor], [TelefonoProveedor], [EmailProveedor], [RepresentanteProveedor]) VALUES (1, N'FABERCASTEL S.A.', N'673547634  ', N'LAS CABAÑAS NORTE Nº 2343', N'343434344  ', N'@FABERCASTELL', N'LUIS SALAS ROBLES')
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [RazonSocialProveedor], [RucProveedor], [DireccionProveedor], [TelefonoProveedor], [EmailProveedor], [RepresentanteProveedor]) VALUES (2, N'SATNAFORDCOMPANY', N'233423423  ', N'MIRAFLORES Nº 343', N'998775676  ', N'@STANFORD', N'MARIELLA VIDAGUIRRE SALAS')
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [RazonSocialProveedor], [RucProveedor], [DireccionProveedor], [TelefonoProveedor], [EmailProveedor], [RepresentanteProveedor]) VALUES (3, N'LOSPUPIES EIRL', N'32434234   ', N'SIMON BOLIVAR Nº  2324', N'323453453  ', N'@PUPIES', N'RAQUEL LLAQUE SANCHEZ')
SET IDENTITY_INSERT [dbo].[PROVEEDOR] OFF
SET IDENTITY_INSERT [dbo].[SUBCATEGORIA] ON 

INSERT [dbo].[SUBCATEGORIA] ([IdSubCategoria], [DestalleSubCategoria], [IdCategoria]) VALUES (1, N'HOJAS COLORES', 1)
INSERT [dbo].[SUBCATEGORIA] ([IdSubCategoria], [DestalleSubCategoria], [IdCategoria]) VALUES (2, N'PLUMONES', 2)
INSERT [dbo].[SUBCATEGORIA] ([IdSubCategoria], [DestalleSubCategoria], [IdCategoria]) VALUES (3, N'LIBROS', 3)
INSERT [dbo].[SUBCATEGORIA] ([IdSubCategoria], [DestalleSubCategoria], [IdCategoria]) VALUES (4, N'CUADERNOS SIN ANILLAR', 4)
SET IDENTITY_INSERT [dbo].[SUBCATEGORIA] OFF
SET IDENTITY_INSERT [dbo].[TIPO_COMPROBANTE] ON 

INSERT [dbo].[TIPO_COMPROBANTE] ([IdTipoComprobante], [DetalleTipoComprobante]) VALUES (1, N'FACTURA')
INSERT [dbo].[TIPO_COMPROBANTE] ([IdTipoComprobante], [DetalleTipoComprobante]) VALUES (2, N'BOLETA DE VENTA')
INSERT [dbo].[TIPO_COMPROBANTE] ([IdTipoComprobante], [DetalleTipoComprobante]) VALUES (3, N'TICKETS')
INSERT [dbo].[TIPO_COMPROBANTE] ([IdTipoComprobante], [DetalleTipoComprobante]) VALUES (4, N'GUIA DE REMISION')
SET IDENTITY_INSERT [dbo].[TIPO_COMPROBANTE] OFF
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([IdUsuario], [CuentaUsuario], [ClaveUsuario], [IdEmpleado]) VALUES (1, N'ADMIN', N'ADMIN12345', 1)
INSERT [dbo].[USUARIO] ([IdUsuario], [CuentaUsuario], [ClaveUsuario], [IdEmpleado]) VALUES (2, N'USER', N'USER12345', 2)
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 

INSERT [dbo].[USUARIOS] ([ID], [USUARIO], [CONTRASENA]) VALUES (1, N'chicorita', N'12345')
INSERT [dbo].[USUARIOS] ([ID], [USUARIO], [CONTRASENA]) VALUES (2, N'salomon', N'12345')
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
ALTER TABLE [dbo].[COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_COMPROBANTE_TIPO_COMPROBANTE] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TIPO_COMPROBANTE] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[COMPROBANTE] CHECK CONSTRAINT [FK_COMPROBANTE_TIPO_COMPROBANTE]
GO
ALTER TABLE [dbo].[COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_FACTURA_CLIENTE] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[COMPROBANTE] CHECK CONSTRAINT [FK_FACTURA_CLIENTE]
GO
ALTER TABLE [dbo].[COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_FACTURA_EMPLEADO] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[EMPLEADO] ([IdEmpleado])
GO
ALTER TABLE [dbo].[COMPROBANTE] CHECK CONSTRAINT [FK_FACTURA_EMPLEADO]
GO
ALTER TABLE [dbo].[DETALLE_COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_FACTURA_FACTURA] FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[COMPROBANTE] ([IdComprobante])
GO
ALTER TABLE [dbo].[DETALLE_COMPROBANTE] CHECK CONSTRAINT [FK_DETALLE_FACTURA_FACTURA]
GO
ALTER TABLE [dbo].[DETALLE_COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_FACTURA_PRODUCTO] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_COMPROBANTE] CHECK CONSTRAINT [FK_DETALLE_FACTURA_PRODUCTO]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_AREA] FOREIGN KEY([IdArea])
REFERENCES [dbo].[AREA] ([IdArea])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_AREA]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_CARGO] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[CARGO] ([IdCargo])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_CARGO]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_CATEGORIA] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIA] ([IdCategoria])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_CATEGORIA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_MARCA] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[MARCA] ([IdMarca])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_MARCA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_PROVEEDOR] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_PROVEEDOR]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_SUBCATEGORIA] FOREIGN KEY([IdSubCategoria])
REFERENCES [dbo].[SUBCATEGORIA] ([IdSubCategoria])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_SUBCATEGORIA]
GO
ALTER TABLE [dbo].[SUBCATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_SUBCATEGORIA_CATEGORIA] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIA] ([IdCategoria])
GO
ALTER TABLE [dbo].[SUBCATEGORIA] CHECK CONSTRAINT [FK_SUBCATEGORIA_CATEGORIA]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_EMPLEADO] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[EMPLEADO] ([IdEmpleado])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_EMPLEADO]
GO
