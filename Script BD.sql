-- CREATE DATABASE ProyectoMandiola
USE ProyectoMandiola

/*==============================================================*/
/* DROPS DE FK                                                  */
/*                                                              */
/*==============================================================*/
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACTIVIDADES') and o.name = 'FK_ACTIVIDADES_PREFIJO')
alter table ACTIVIDADES
   drop constraint FK_ACTIVIDADES_PREFIJO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACTIVOS') and o.name = 'FK_ACTIVOS_PREFIJO')
alter table ACTIVOS
   drop constraint FK_ACTIVOS_PREFIJO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HABITACIONES') and o.name = 'FK_HABITACIONES_PREFIJO')
alter table HABITACIONES
   drop constraint FK_HABITACIONES_PREFIJO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRECIOS') and o.name = 'FK_PRECIOS_PREFIJO')
alter table PRECIOS
   drop constraint FK_PRECIOS_PREFIJO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVACIONES') and o.name = 'FK_RESERVACIONES_PREFIJO')
alter table RESERVACIONES
   drop constraint FK_RESERVACIONES_PREFIJO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVACIONES') and o.name = 'FK_RESERVACIONES_CLIENTE')
alter table RESERVACIONES
   drop constraint FK_RESERVACIONES_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVACIONES') and o.name = 'FK_RESERVACIONES_HABITACION')
alter table RESERVACIONES
   drop constraint FK_RESERVACIONES_HABITACION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVACIONES') and o.name = 'FK_RESERVACIONES_PRECIO')
alter table RESERVACIONES
   drop constraint FK_RESERVACIONES_PRECIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMPRAS') and o.name = 'FK_COMPRAS_CLIENTE')
alter table COMPRAS
   drop constraint FK_COMPRAS_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMPRAS') and o.name = 'FK_COMPRAS_ACTIVO')
alter table COMPRAS
   drop constraint FK_COMPRAS_ACTIVO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMPRAS') and o.name = 'FK_COMPRAS_PRECIO')
alter table COMPRAS
   drop constraint FK_COMPRAS_PRECIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIOS_EN_ROLES') and o.name = 'FK_USUARIOS_EN_ROLES_USUARIO')
alter table USUARIOS_EN_ROLES
   drop constraint FK_USUARIOS_EN_ROLES_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIOS_EN_ROLES') and o.name = 'FK_USUARIOS_EN_ROLES_ROL')
alter table USUARIOS_EN_ROLES
   drop constraint FK_USUARIOS_EN_ROLES_ROL
go


/*==============================================================*/
/* DROPS DE TABLAS                                              */
/*                                                              */
/*==============================================================*/
if exists (select 1
            from  sysobjects
           where  id = object_id('CONSECUTIVOS')
            and   type = 'U')
   drop table CONSECUTIVOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACTIVIDADES')
            and   type = 'U')
   drop table ACTIVIDADES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACTIVOS')
            and   type = 'U')
   drop table ACTIVOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTES')
            and   type = 'U')
   drop table CLIENTES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HABITACIONES')
            and   type = 'U')
   drop table HABITACIONES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRECIOS')
            and   type = 'U')
   drop table PRECIOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RESERVACIONES_DE_HABITACIONES')
            and   type = 'U')
   drop table RESERVACIONES_DE_HABITACIONES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMPRAS')
            and   type = 'U')
   drop table COMPRAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ERRORES')
            and   type = 'U')
   drop table ERRORES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BITACORA')
            and   type = 'U')
   drop table BITACORA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIOS')
            and   type = 'U')
   drop table USUARIOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROLES')
            and   type = 'U')
   drop table ROLES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIOS_EN_ROLES')
            and   type = 'U')
   drop table USUARIOS_EN_ROLES
go
/*==============================================================*/
/*                         CREATE                               */
/*                         TABLE                                */
/*==============================================================*/
CREATE TABLE CONSECUTIVOS (
   PREFIJO CHAR(5) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )PRIMARY KEY,
   CODIGO_CONSECUTIVO NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   DESCRIPCION_CONSECUTIVO varchar(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   RANGO_INICIAL NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   RANGO_FINAL NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE ACTIVIDADES (
   CODIGO_CONSECUTIVO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )PRIMARY KEY,
   PREFIJO CHAR(5) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   NOMBRE varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   DESCRIPCION_CONSECUTIVO varchar(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   IMAGEN_ACTIVIDAD VARCHAR(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CONSTRAINT FK_ACTIVIDADES_PREFIJO FOREIGN KEY (PREFIJO) REFERENCES CONSECUTIVOS(PREFIJO) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE ACTIVOS (
   CODIGO_CONSECUTIVO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )PRIMARY KEY,
   PREFIJO CHAR(5) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   NOMBRE varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   DESCRIPCION_CONSECUTIVO varchar(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CONSTRAINT FK_ACTIVOS_PREFIJO FOREIGN KEY (PREFIJO) REFERENCES CONSECUTIVOS(PREFIJO) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE CLIENTES (
   NOMBRE_USUARIO varchar(90) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ) NOT NULL PRIMARY KEY,
   PASSWORD varchar(12) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   NOMBRE varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   PRIMER_APELLIDO varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   SEGUNDO_APELLIDO varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   EMAIL varchar(60) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE HABITACIONES (
   CODIGO_CONSECUTIVO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )PRIMARY KEY,
   PREFIJO CHAR(5) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   NUMERO NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   DESCRIPCION_CONSECUTIVO varchar(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   IMAGEN_HABITACION VARCHAR(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CONSTRAINT FK_HABITACIONES_PREFIJO FOREIGN KEY (PREFIJO) REFERENCES CONSECUTIVOS(PREFIJO) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE PRECIOS (
   CODIGO_CONSECUTIVO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )PRIMARY KEY,
   PREFIJO CHAR(5) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   TIPO VARCHAR(30) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   PRECIO NVARCHAR(30) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CONSTRAINT FK_PRECIOS_PREFIJO FOREIGN KEY (PREFIJO) REFERENCES CONSECUTIVOS(PREFIJO) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE RESERVACIONES_DE_HABITACIONES (
   BOOKING_ID VARCHAR(7) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )PRIMARY KEY,
   NUMERO_DE_RESERVACION NVARCHAR(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   Cliente VARCHAR(90) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   ITINERARIO VARCHAR(30) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CODIGO_DE_HABITACION VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CODIGO_DE_PRECIO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CANTIDAD_DE_PERSONAS NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CANTIDAD_DE_DIAS NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CANTIDAD_DE_HABITACIONES NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CONSTRAINT FK_RESERVACIONES_CLIENTE FOREIGN KEY (Cliente) REFERENCES CLIENTES(NOMBRE_USUARIO) ON DELETE CASCADE ON UPDATE CASCADE,
   CONSTRAINT FK_RESERVACIONES_HABITACION FOREIGN KEY (CODIGO_DE_HABITACION) REFERENCES HABITACIONES(CODIGO_CONSECUTIVO),
   CONSTRAINT FK_RESERVACIONES_PRECIO FOREIGN KEY (CODIGO_DE_PRECIO) REFERENCES PRECIOS(CODIGO_CONSECUTIVO)
)
GO

CREATE UNIQUE INDEX indunique_reservaciones 
  ON RESERVACIONES_DE_HABITACIONES(NUMERO_DE_RESERVACION) 
  WHERE NUMERO_DE_RESERVACION IS NOT NULL

go

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE COMPRAS (
   Cliente VARCHAR(90) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   ESTADO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CODIGO_DE_ACTIVO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CODIGO_DE_PRECIO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CANTIDAD NVARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   CONSTRAINT FK_COMPRAS_CLIENTE FOREIGN KEY (Cliente) REFERENCES CLIENTES(NOMBRE_USUARIO) ON DELETE CASCADE ON UPDATE CASCADE,
   CONSTRAINT FK_COMPRAS_ACTIVO FOREIGN KEY (CODIGO_DE_ACTIVO) REFERENCES ACTIVOS(CODIGO_CONSECUTIVO),
   CONSTRAINT FK_COMPRAS_PRECIO FOREIGN KEY (CODIGO_DE_PRECIO) REFERENCES PRECIOS(CODIGO_CONSECUTIVO)
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

create table ERRORES (
   NUMERO_ERROR VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   FECHA_HORA_ERROR VARCHAR(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   MENSAJE_ERROR VARCHAR(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

create table BITACORA (
   CODIGO_REGISTRO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   USUARIO VARCHAR(30) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   FECHA_HORA_BITACORA VARCHAR(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   TIPO VARCHAR(10) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   DESCRIPCION VARCHAR(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   REGISTRO_DETALLE VARCHAR(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

CREATE TABLE USUARIOS (
   NOMBRE_USUARIO VARCHAR(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ) NOT NULL PRIMARY KEY,
   PASSWORD varchar(12) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   EMAIL varchar(60) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   PREGUNTA varchar(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   RESPUESTA varchar(MAX) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )not null,
   isAdmin CHAR(1) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   isSeguridad CHAR(1) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   isConsecutivo CHAR(1) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   isMantenimiento CHAR(1) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
   isConsulta CHAR(1) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   )
)
GO

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

create table ROLES (
   ROL varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ) NOT NULL PRIMARY KEY
)
go

------------------------------------------------------------------------------
------------------------------------------------------------------------------
------------------------------------------------------------------------------

create table USUARIOS_EN_ROLES (
	USUARIO varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
	ROL varchar(20) COLLATE Latin1_General_BIN2 
   ENCRYPTED WITH (
	COLUMN_ENCRYPTION_KEY = CEK1,
	ENCRYPTION_TYPE = Deterministic,
	ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
   ),
	constraint FK_USUARIOS_EN_ROLES_USUARIO foreign key (USUARIO)
	references USUARIOS (NOMBRE_USUARIO),
	constraint FK_USUARIOS_EN_ROLES_ROL foreign key (ROL)
    references ROLES (ROL)
)
go