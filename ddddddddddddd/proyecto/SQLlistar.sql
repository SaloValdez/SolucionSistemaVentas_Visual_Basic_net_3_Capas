ALTER AUTHORIZATION ON DATABASE::DBSISVENTAS TO SA
------------------------------------------------------------
create procedure sp_lista_area
as
select * from AREA
go
------------------------------------------------------------
create procedure sp_lista_cargo
as
select * from CARGO
go
------------------------------------------------------------
create procedure sp_lista_categoria
as
select * from CATEGORIA
go
------------------------------------------------------------
create procedure sp_lista_cliente
as
select * from CLIENTE
go
------------------------------------------------------------
create procedure sp_lista_comprobante
as
select * from COMPROBANTE
go
------------------------------------------------------------
create procedure sp_lista_detalle_comprobante
as
select * from DETALLE_COMPROBANTE
go
------------------------------------------------------------
create procedure sp_lista_empleado
as
select * from EMPLEADO
go
------------------------------------------------------------
create procedure sp_lista_marca
as
select * from MARCA
go
------------------------------------------------------------
create procedure sp_lista_producto
as
select * from PRODUCTO
go
------------------------------------------------------------
create procedure sp_lista_proveedor
as
select * from PROVEEDOR
go
------------------------------------------------------------
create procedure sp_lista_subcategoria
as
select * from SUBCATEGORIA
go
------------------------------------------------------------
create procedure sp_lista_tipo_comprobante
as
select * from TIPO_COMPROBANTE
go
------------------------------------------------------------
create procedure sp_lista_usuario
as
select * from USUARIO