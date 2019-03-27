
Create database SIGECOR;
use SIGECOR;

if exists( select o.name from sys.objects o where o.name='cliente')
       begin
             drop table cliente
       end
				create table cliente(
				cliente_id int NOT NULL IDENTITY,
				num_identificacion varchar(15),
				nombre_completo varchar(70),
				sexo varchar(7),
				telefono varchar(12),
				direccion varchar(30),
				ciudad varchar(30),
				email varchar(30),
				estado varchar(30),
				primary key (cliente_id)
				);
go
IF @@ERROR =0
       begin
             select 'Tabla cliente creada con exito '
       end
else
       begin
             select 'Tabla cliente no se pudo crear verifique '
       end

----------------------------------------------------------------------------------	   
go

if exists( select o.name from sys.objects o where o.name='mecanico')
       begin
             drop table mecanico
       end
				create table mecanico(
				mecanico_id int NOT NULL IDENTITY,
				nombre_completo varchar(30),
				estado varchar(30),
				sexo varchar(7),
				telefono varchar(12),
				direccion varchar(30),
				email varchar(30),
				primary key (mecanico_id )
				);
go

IF @@ERROR =0
       begin
             select 'Tabla mecanico creada con exito '
       end
else
       begin
             select 'Tabla mecanico no se pudo crear verifique '
       end
	   
--------------------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='repuesto' )
       begin
             drop table repuesto
       end
			create table repuesto(
			repuesto_id int NOT NULL IDENTITY,
			nombre varchar(30),
			marca varchar(30),
			precio_unidad int,
			stock int,
			primary key (repuesto_id)
			);
go

IF @@ERROR =0
       begin
             select 'Tabla repuesto creada con exito '
       end
else
       begin
             select 'Tabla repuesto no se pudo crear verifique '
       end

----------------------------------------------------------------------------------	   
go

if exists( select o.name from sys.objects o where o.name='vehiculo' )
       begin
             drop table vehiculo
       end
			create table vehiculo(
			vehiculo_id int NOT NULL IDENTITY,
			marca varchar(30),
			modelo varchar(30),
			color varchar(30),
			anno int,
			propietario_id int,
			primary key (vehiculo_id),
			FOREIGN KEY (propietario_id) references cliente(cliente_id)
			);
go

IF @@ERROR =0
       begin
             select 'Tabla vehiculo creada con exito '
       end
else
       begin
             select 'Tabla vehiculo no se pudo crear verifique '
       end
---------------------------------------------------------------------------------	   
go

if exists( select o.name from sys.objects o where o.name='servicio' )
       begin
             drop table servicio
       end
			create table servicio(
			servicio_id int NOT NULL IDENTITY,
			vehiculo_id int,
			descripcion_danno varchar(200),
			mecanico_id int,
			presupuesto_arreglo int,
			estimacion_tiempo_hrs int,
			estimacion_precio int,
			precio_mano_obra int,
			foto varbinary(max),
			fecha_ingreso DateTime,
			fecha_salida DateTime,
			estado varchar(30),
			primary key (servicio_id),
			FOREIGN KEY (vehiculo_id) references vehiculo(vehiculo_id),
			FOREIGN KEY (mecanico_id) references mecanico(mecanico_id)
			);
go

IF @@ERROR = 0
       begin
             select 'Tabla servicio creada con exito '
       end
else
       begin
             select 'Tabla servicio no se pudo crear verifique '
       end
----------------------------------------------------------------------------------	   
go

if exists( select o.name from sys.objects o where o.name='repuesto_servicio' )
       begin
             drop table repuesto_servicio
       end
			create table repuesto_servicio(
			repuesto_servicio_id int NOT NULL IDENTITY,
			repuesto_id int,
			servicio_id int,
			primary key (repuesto_servicio_id),
			FOREIGN KEY (repuesto_id) references repuesto(repuesto_id),
			FOREIGN KEY (servicio_id) references servicio(servicio_id)
			);
go

IF @@ERROR = 0
       begin
             select 'Tabla repuesto_servicio creada con exito '
       end
else
       begin
             select 'Tabla repuesto_servicio no se pudo crear verifique '
       end

----------------------------------------------------------------------------------	   
go

if exists( select o.name from sys.objects o where o.name='factura' )
       begin
             drop table factura
       end
			create table factura(
			factura_id int NOT NULL IDENTITY,
			mecanico_id int,
			cliente_id int,
			repuesto_servicio_id int,
			valor_total int,
			iva int,
			fecha_emision DateTime,
			primary key (repuesto_servicio_id),
			FOREIGN KEY (mecanico_id) references mecanico(mecanico_id),
			FOREIGN KEY (cliente_id) references cliente(cliente_id),
			FOREIGN KEY (repuesto_servicio_id) references repuesto_servicio(repuesto_servicio_id)
			);
go

IF @@ERROR =0
       begin
             select 'Tabla factura creada con exito '
       end
else
       begin
             select 'Tabla factura no se pudo crear verifique '
       end
----------------------------------------------------------------------------------	   

go

if exists( select o.name from sys.objects o where o.name='SP_INS_CLIENTE' )
       begin
             drop procedure SP_INS_CLIENTE
       end
go
create procedure SP_INS_CLIENTE
@NUM_IDENTIFICACION VARCHAR(15),
@NOMBRE_COMPLETO VARCHAR(150),
@SEXO VARCHAR(10), 
@TELEFONO VARCHAR(15)=NULL, 
@DIRECCION VARCHAR(100), 
@CIUDAD VARCHAR(30), 
@EMAIL VARCHAR(30)=NULL,
@ESTADO VARCHAR(10)
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
 INSERT INTO cliente (num_identificacion, nombre_completo, sexo, telefono, direccion, ciudad, email, estado)
       VALUES (@NUM_IDENTIFICACION, @NOMBRE_COMPLETO, @SEXO, @TELEFONO, @DIRECCION, @CIUDAD, @EMAIL, @ESTADO)
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_INS_CLIENTE creado con exito '
       end
else
       begin
             select 'Procedimiento SP_INS_CLIENTE no se pudo crear verifique '
       end
--------------------------------------------------

go

if exists( select o.name from sys.objects o where o.name='SP_UPDT_CLIENTE' )
       begin
             drop procedure SP_UPDT_CLIENTE
       end
go
create procedure SP_UPDT_CLIENTE
@CLIENTE_ID INT,
@NUM_IDENTIFICACION VARCHAR(15),
@NOMBRE_COMPLETO VARCHAR(150),
@SEXO VARCHAR(10), 
@TELEFONO VARCHAR(15)=NULL, 
@DIRECCION VARCHAR(100), 
@CIUDAD VARCHAR(30), 
@EMAIL VARCHAR(30)=NULL,
@ESTADO VARCHAR(10)
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
 UPDATE cliente SET 
 num_identificacion = @NUM_IDENTIFICACION, 
 nombre_completo = @NOMBRE_COMPLETO,
 sexo =@SEXO,
 telefono = @TELEFONO,
 direccion = @DIRECCION,
 ciudad = @CIUDAD,
 email = @EMAIL,
 estado = @ESTADO WHERE cliente_id = @CLIENTE_ID
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_UPDT_CLIENTE creado con exito '
       end
else
       begin
             select 'Procedimiento SP_UPDT_CLIENTE no se pudo crear verifique '
       end
----------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_INS_MECANICO' )
       begin
             drop procedure SP_INS_MECANICO
       end
go
create procedure SP_INS_MECANICO
@NOMBRE_COMPLETO VARCHAR(30),
@ESTADO VARCHAR(15), 
@SEXO VARCHAR(15)=NULL, 
@TELEFONO VARCHAR(15), 
@DIRECCION VARCHAR(50), 
@EMAIL VARCHAR(30)=NULL
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN

 INSERT INTO mecanico (nombre_completo, estado, sexo, telefono, direccion, email)
       VALUES (@NOMBRE_COMPLETO, @ESTADO, @SEXO, @TELEFONO, @DIRECCION, @EMAIL)
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_INS_MECANICO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_INS_MECANICO no se pudo crear verifique '
       end
--------------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_UPDT_MECANICO' )
       begin
             drop procedure SP_UPDT_MECANICO
       end
go
create procedure SP_UPDT_MECANICO
@MECANICO_ID INT,
@NOMBRE_COMPLETO VARCHAR(30),
@ESTADO VARCHAR(15), 
@SEXO VARCHAR(15)=NULL, 
@TELEFONO VARCHAR(15), 
@DIRECCION VARCHAR(50), 
@EMAIL VARCHAR(30)=NULL
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
 UPDATE mecanico SET 
 			
nombre_completo = @NOMBRE_COMPLETO,
estado = @ESTADO,
 sexo =@SEXO,
 telefono = @TELEFONO,
 direccion = @DIRECCION,
 email = @EMAIL
  WHERE mecanico_id = @MECANICO_ID
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_UPDT_MECANICO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_UPDT_MECANICO no se pudo crear verifique '
       end
----------------------------------------------

go

if exists( select o.name from sys.objects o where o.name='SP_INS_VEHICULO' )
       begin
             drop procedure SP_INS_VEHICULO
       end
go
create procedure SP_INS_VEHICULO

@MARCA VARCHAR(30),
@MODELO VARCHAR(15), 
@COLOR VARCHAR(15)=NULL, 
@ANNO VARCHAR(15), 
@PROPIETARIO INT
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
 INSERT INTO vehiculo (marca, modelo, color, anno, propietario_id)
       VALUES (@MARCA, @MODELO, @COLOR, @ANNO, @PROPIETARIO)
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_INS_VEHICULO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_INS_VEHICULO no se pudo crear verifique '
       end
--------------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_UPDT_VEHICULO' )
       begin
             drop procedure SP_UPDT_VEHICULO
       end
go
create procedure SP_UPDT_VEHICULO
@VEHICULO_ID INT,
@MARCA VARCHAR(30),
@MODELO VARCHAR(15), 
@COLOR VARCHAR(15)=NULL, 
@ANNO VARCHAR(15), 
@PROPIETARIO INT
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
 UPDATE vehiculo SET 
 			
marca = @MARCA,
modelo = @MODELO,
color =@COLOR,
anno = @ANNO,
propietario_id = @PROPIETARIO
WHERE vehiculo_id = @VEHICULO_ID
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_UPDT_VEHICULO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_UPDT_VEHICULO no se pudo crear verifique '
       end
----------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_INS_REPUESTO' )
       begin
             drop procedure SP_INS_REPUESTO
       end
go
create procedure SP_INS_REPUESTO
 
@NOMBRE VARCHAR(30),
@MARCA VARCHAR(15), 
@PRECIO_UNIDAD INT, 
@STOCK INT
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN

 INSERT INTO repuesto (nombre, marca, precio_unidad, stock)
       VALUES (@NOMBRE, @MARCA, @PRECIO_UNIDAD, @STOCK)
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_INS_REPUESTO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_INS_REPUESTO no se pudo crear verifique '
       end
--------------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_UPDT_REPUESTO' )
       begin
             drop procedure SP_UPDT_REPUESTO
       end
go
create procedure SP_UPDT_REPUESTO
@REPUESTO_ID INT,
@NOMBRE VARCHAR(30),
@MARCA VARCHAR(15), 
@PRECIO_UNIDAD INT, 
@STOCK INT
AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
 UPDATE repuesto SET 
nombre = @NOMBRE,
marca = @MARCA,
precio_unidad =@PRECIO_UNIDAD,
stock = @STOCK
WHERE repuesto_id = @REPUESTO_ID
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_UPDT_REPUESTO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_UPDT_REPUESTO no se pudo crear verifique '
       end
----------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_INS_SERVICIO')
       begin
             drop procedure SP_INS_SERVICIO
       end
go
create procedure SP_INS_SERVICIO
@VEHICULO_ID INT,
@DESCRIPCION_DANO VARCHAR(200), 
@MECANICO_ID INT, 
@PRESUPESTO_ARREGLO INT, 
@ESTIMACION_TIEMPO_HRS INT,
@ESTIMACION_PRECIO INT,
@PRECIO_MANO_OBRA INT,
@FOTO varbinary(max),
@FECHA_INGRESO DATETIME,
@FECHA_SALIDA DATETIME,
@ESTADO VARCHAR(30)

AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
  
 INSERT INTO servicio (vehiculo_id, descripcion_danno, mecanico_id, presupuesto_arreglo,estimacion_tiempo_hrs, estimacion_precio, precio_mano_obra, foto, fecha_ingreso, fecha_salida, estado)
       VALUES (@VEHICULO_ID, @DESCRIPCION_DANO, @MECANICO_ID, @PRESUPESTO_ARREGLO, @ESTIMACION_TIEMPO_HRS, @ESTIMACION_PRECIO, @PRECIO_MANO_OBRA, @FOTO, @FECHA_INGRESO, @FECHA_SALIDA, @ESTADO)
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_INS_SERVICIO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_INS_SERVICIO no se pudo crear verifique '
       end

--------------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_UPDT_SERVICIO' )
       begin
             drop procedure SP_UPDT_SERVICIO
       end
go
create procedure SP_UPDT_SERVICIO
@SERVICIO_ID INT,
@VEHICULO_ID INT,
@DESCRIPCION_DANO VARCHAR(200), 
@MECANICO_ID INT, 
@PRESUPESTO_ARREGLO INT, 
@ESTIMACION_TIEMPO_HRS INT,
@ESTIMACION_PRECIO INT,
@PRECIO_MANO_OBRA INT,
@FOTO varbinary(max),
@FECHA_INGRESO DATETIME,
@FECHA_SALIDA DATETIME,
@ESTADO VARCHAR(30)

AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
UPDATE servicio SET 
vehiculo_id = @VEHICULO_ID,
descripcion_danno = @DESCRIPCION_DANO,
mecanico_id = @MECANICO_ID,
presupuesto_arreglo = @PRESUPESTO_ARREGLO,
estimacion_tiempo_hrs = @ESTIMACION_TIEMPO_HRS,
estimacion_precio = @ESTIMACION_PRECIO,
precio_mano_obra = @PRECIO_MANO_OBRA,
foto = @FOTO,
fecha_ingreso = @FECHA_INGRESO,
fecha_salida = @FECHA_SALIDA,
estado = @ESTADO
WHERE servicio_id = @SERVICIO_ID
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_UPDT_SERVICIO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_UPDT_SERVICIO no se pudo crear verifique '
       end
----------------------------------------------
go

if exists( select o.name from sys.objects o where o.name='SP_INS_REPUESTO_SERVICIO' )
       begin
             drop procedure SP_INS_REPUESTO_SERVICIO
       end
go
create procedure SP_INS_REPUESTO_SERVICIO
  
@REPUESTO_ID INT,
@SERVICIO_ID INT

AS
/*
AUTOR: JORGE PERTUZ EGEA
FECHA: 2019/03/23
*/
BEGIN
  
 INSERT INTO repuesto_servicio (repuesto_id, servicio_id)
       VALUES (@REPUESTO_ID, @SERVICIO_ID)
       
       IF @@ERROR = 0
             return 1
       else
             return 0
END
go
IF @@ERROR = 0
       begin
             select 'Procedimiento SP_INS_REPUESTO_SERVICIO creado con exito '
       end
else
       begin
             select 'Procedimiento SP_INS_REPUESTO_SERVICIO no se pudo crear verifique '
       end
--------------------------------------------------
