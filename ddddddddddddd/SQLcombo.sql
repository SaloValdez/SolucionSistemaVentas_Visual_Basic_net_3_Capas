
create procedure sp_combo_area
as
select idarea as id,nombrearea as nombre
from AREA
------------------------------------------------------------
go
create procedure sp_combo_cargo
as
select idcargo as id,nombrecargo as nombre
from cargo
--------------------------------------------------------------
go
create procedure sp_combo_categoria
as
select idcategoria as id,DescripcionCategoria as descripcion
from categoria
---------------------------------------------------------------
go
create procedure sp_combo_cliente
as
select idcliente as id,nombrecliente as nombre
from CLIENTE
----------------------------------------------------------------
go
create procedure sp_combo_comprobante
as
select idcomprobante as id,NumeroComprobante as numero
from COMPROBANTE
-------------------------------------------------------------------
go
create procedure sp_combo_empleado
as
select idempleado as id,nombreempleado as nombre
from EMPLEADO
-------------------------------------------------------------------
go
create procedure sp_combo_marca
as
select idmarca as id,detallemarca as detalle
from MARCA
---------------------------------------------------------------------
go
create procedure sp_combo_producto
as
select idproducto as id,codigoproducto as codigo
from PRODUCTO
-----------------------------------------------------------------------
go
create procedure sp_combo_proveedor
as
select idproveedor as id,razonsocialproveedor as razonsocial
from PROVEEDOR
------------------------------------------------------------------------
go
create procedure sp_combo_subcategoria
as
select idsubcategoria as id,DestalleSubCategoria as detalle
from SUBCATEGORIA
-------------------------------------------------------------------------
go
create procedure sp_combo_tipocomprobante
as
select idtipocomprobante as id,detalletipocomprobante as detalle
from TIPO_COMPROBANTE
--------------------------------------------------------------------------
go
create procedure sp_combo_usuario
as
select idusuario as id,cuentausuario as cuenta
from USUARIO