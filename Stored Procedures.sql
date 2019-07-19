--------------------------------------------------------------------------------------------------
---------------------------------------CONSECUTIVOS-----------------------------------
--------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_AGREGAR_CONSECUTIVO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_AGREGAR_CONSECUTIVO] 
END 
GO

CREATE PROCEDURE [dbo].[sp_AGREGAR_CONSECUTIVO]
( @prefijo char(5),
  @consecutivo NVARCHAR(10),
  @descripcion varchar(MAX),
  @ri NVARCHAR(10),
  @rf NVARCHAR(10))

 AS

Insert into CONSECUTIVOS(PREFIJO,CODIGO_CONSECUTIVO,DESCRIPCION_CONSECUTIVO,RANGO_INICIAL,RANGO_FINAL) 
values(@prefijo,@consecutivo,@descripcion,@ri,@rf)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_CONSECUTIVOS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_CONSECUTIVOS]
END 
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_CONSECUTIVOS]

AS

SELECT PREFIJO
, DESCRIPCION_CONSECUTIVO as Descripcion
, CODIGO_CONSECUTIVO
, RANGO_INICIAL
, RANGO_FINAL
FROM CONSECUTIVOS
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_MODIFICAR_CONSECUTIVO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_MODIFICAR_CONSECUTIVO] 
END 
GO

CREATE PROCEDURE [dbo].[sp_MODIFICAR_CONSECUTIVO] 
( @prefijo char(5),
  @consecutivo NVARCHAR(10),
  @descripcion varchar(MAX),
  @ri NVARCHAR(10),
  @rf NVARCHAR(10))

AS

UPDATE CONSECUTIVOS
SET PREFIJO = @prefijo,
	CODIGO_CONSECUTIVO = @consecutivo,
	DESCRIPCION_CONSECUTIVO = @descripcion,
	RANGO_INICIAL = @ri,
	RANGO_FINAL = @rf
WHERE PREFIJO = @prefijo
GO

--------------------------------------------------------------------------------------------------
---------------------------------------HABITACION-----------------------------------------
--------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_INSERTAR_HABITACION]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_INSERTAR_HABITACION]
END 
GO
CREATE PROCEDURE [dbo].[sp_INSERTAR_HABITACION]
( @codigo VARCHAR(10),
  @prefijo CHAR(5),
  @numero NVARCHAR(10),
  @descripcion VARCHAR(MAX),
  @img VARCHAR(MAX),
  @consecutivo NVARCHAR(10))

AS

BEGIN

Insert into HABITACIONES(CODIGO_CONSECUTIVO,PREFIJO,NUMERO,DESCRIPCION_CONSECUTIVO,IMAGEN_HABITACION) 
values(@codigo,@prefijo,@numero,@descripcion,@img)

UPDATE CONSECUTIVOS
SET CODIGO_CONSECUTIVO = @consecutivo
WHERE PREFIJO = @prefijo

END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_MODIFICAR_HABITACION]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_MODIFICAR_HABITACION] 
END 
GO

CREATE PROCEDURE [dbo].[sp_MODIFICAR_HABITACION] 
( @codigo VARCHAR(10),
  @numero NVARCHAR(10),
  @descripcion VARCHAR(MAX),
  @img VARCHAR(MAX))


AS

UPDATE HABITACIONES
SET NUMERO = @numero,
	DESCRIPCION_CONSECUTIVO = @descripcion,
	IMAGEN_HABITACION = @img
WHERE CODIGO_CONSECUTIVO = @codigo
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_HABITACIONES]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_HABITACIONES]
END 
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_HABITACIONES]

AS

SELECT *
FROM HABITACIONES

GO

--------------------------------------------------------------------------------------------------
---------------------------------------ACTIVIDAD-----------------------------------------
--------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_INSERTAR_ACTIVIDAD]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_INSERTAR_ACTIVIDAD]
END 
GO
CREATE PROCEDURE [dbo].[sp_INSERTAR_ACTIVIDAD]
( @codigo VARCHAR(10),
  @prefijo CHAR(5),
  @nombre VARCHAR(20),
  @descripcion VARCHAR(MAX),
  @img VARCHAR(MAX),
  @consecutivo NVARCHAR(10))

AS

BEGIN

Insert into ACTIVIDADES(CODIGO_CONSECUTIVO,PREFIJO,NOMBRE,DESCRIPCION_CONSECUTIVO,IMAGEN_ACTIVIDAD) 
values(@codigo,@prefijo,@nombre,@descripcion,@img)

UPDATE CONSECUTIVOS
SET CODIGO_CONSECUTIVO = @consecutivo
WHERE PREFIJO = @prefijo

END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_MODIFICAR_ACTIVIDAD]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_MODIFICAR_ACTIVIDAD] 
END 
GO

CREATE PROCEDURE [dbo].[sp_MODIFICAR_ACTIVIDAD] 
( @codigo VARCHAR(10),
  @nombre VARCHAR(20),
  @descripcion VARCHAR(MAX),
  @img VARCHAR(MAX))


AS

UPDATE ACTIVIDADES
SET NOMBRE = @nombre,
	DESCRIPCION_CONSECUTIVO = @descripcion,
	IMAGEN_ACTIVIDAD = @img
WHERE CODIGO_CONSECUTIVO = @codigo
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_ACTIVIDADES]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_ACTIVIDADES]
END 
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_ACTIVIDADES]

AS

SELECT *
FROM ACTIVIDADES

GO

--------------------------------------------------------------------------------------------------
---------------------------------------ACTIVO---------------------------------------------
--------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_INSERTAR_ACTIVO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_INSERTAR_ACTIVO]
END 
GO
CREATE PROCEDURE [dbo].[sp_INSERTAR_ACTIVO]
( @codigo VARCHAR(10),
  @prefijo CHAR(5),
  @nombre VARCHAR(20),
  @descripcion VARCHAR(MAX),
  @consecutivo NVARCHAR(10))

AS

BEGIN

Insert into ACTIVOS(CODIGO_CONSECUTIVO,PREFIJO,NOMBRE,DESCRIPCION_CONSECUTIVO) 
values(@codigo,@prefijo,@nombre,@descripcion)

UPDATE CONSECUTIVOS
SET CODIGO_CONSECUTIVO = @consecutivo
WHERE PREFIJO = @prefijo

END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_MODIFICAR_ACTIVO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_MODIFICAR_ACTIVO] 
END 
GO

CREATE PROCEDURE [dbo].[sp_MODIFICAR_ACTIVO] 
( @codigo VARCHAR(10),
  @nombre VARCHAR(20),
  @descripcion VARCHAR(MAX))


AS

UPDATE ACTIVOS
SET NOMBRE = @nombre,
	DESCRIPCION_CONSECUTIVO = @descripcion
WHERE CODIGO_CONSECUTIVO = @codigo
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_ACTIVOS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_ACTIVOS]
END 
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_ACTIVOS]

AS

SELECT *
FROM ACTIVOS

GO

--------------------------------------------------------------------------------------------------
---------------------------------------PRECIO---------------------------------------------
--------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_INSERTAR_PRECIO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_INSERTAR_PRECIO]
END 
GO
CREATE PROCEDURE [dbo].[sp_INSERTAR_PRECIO]
( @codigo VARCHAR(10),
  @prefijo CHAR(5),
  @tipo VARCHAR(30),
  @precio NVARCHAR(30),
  @consecutivo NVARCHAR(10))

AS

BEGIN

Insert into PRECIOS(CODIGO_CONSECUTIVO,PREFIJO,TIPO,PRECIO) 
values(@codigo,@prefijo,@tipo,@precio)

UPDATE CONSECUTIVOS
SET CODIGO_CONSECUTIVO = @consecutivo
WHERE PREFIJO = @prefijo

END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_MODIFICAR_PRECIO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_MODIFICAR_PRECIO] 
END 
GO

CREATE PROCEDURE [dbo].[sp_MODIFICAR_PRECIO] 
( @codigo VARCHAR(10),
  @tipo VARCHAR(30),
  @precio NVARCHAR(30))


AS

UPDATE PRECIOS
SET TIPO = @tipo,
	PRECIO = @precio
WHERE CODIGO_CONSECUTIVO = @codigo
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_PRECIOS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_PRECIOS]
END 
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_PRECIOS]

AS

SELECT *
FROM PRECIOS

GO



--------------------------------------------------------------------------------------------------
---------------------------------------USUARIOS-------------------------------------------
--------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_AGREGAR_USUARIO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_AGREGAR_USUARIO] 
END 
GO

CREATE PROCEDURE [dbo].[sp_AGREGAR_USUARIO]
( @username VARCHAR(20),
  @password VARCHAR(12),
  @email VARCHAR(60),
  @pregunta VARCHAR(MAX),
  @respuesta VARCHAR(MAX))

 AS

Insert into USUARIOS(NOMBRE_USUARIO,PASSWORD,EMAIL,PREGUNTA,RESPUESTA) 
values(@username,@password,@email,@pregunta,@respuesta)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_AGREGAR_USUARIO_BACKDOOR]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].sp_AGREGAR_USUARIO_BACKDOOR 
END 
GO

CREATE PROCEDURE [dbo].sp_AGREGAR_USUARIO_BACKDOOR
( @username VARCHAR(20),
  @password VARCHAR(12),
  @email VARCHAR(60),
  @pregunta VARCHAR(MAX),
  @respuesta VARCHAR(MAX),
  @isAdmin CHAR(1))

 AS

Insert into USUARIOS(NOMBRE_USUARIO,PASSWORD,EMAIL,PREGUNTA,RESPUESTA,isAdmin) 
values(@username,@password,@email,@pregunta,@respuesta,@isAdmin)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_USUARIOS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].sp_TRAE_LISTA_USUARIOS
END 
GO
CREATE PROCEDURE [dbo].sp_TRAE_LISTA_USUARIOS

AS

SELECT NOMBRE_USUARIO
, PASSWORD
, EMAIL
, PREGUNTA
, RESPUESTA
, isAdmin
, isSeguridad
, isConsecutivo
, isMantenimiento
, isConsulta
FROM USUARIOS
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_CAMBIAR_CONTRASEÑA]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].sp_CAMBIAR_CONTRASEÑA 
END 
GO

CREATE PROCEDURE [dbo].sp_CAMBIAR_CONTRASEÑA 
( @username VARCHAR(20),
  @password VARCHAR(12))

AS

UPDATE USUARIOS
SET PASSWORD = @password
WHERE NOMBRE_USUARIO = @username
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_ACTUALIZAR_ROLES]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].sp_ACTUALIZAR_ROLES 
END 
GO

CREATE PROCEDURE [dbo].sp_ACTUALIZAR_ROLES 
( @username VARCHAR(20),
  @isAdmin VARCHAR(1),
  @isSeguridad VARCHAR(1),
  @isConsecutivo VARCHAR(1),
  @isMantenimiento VARCHAR(1),
  @isConsulta VARCHAR(1))

AS

UPDATE USUARIOS
SET isAdmin = @isAdmin,
isSeguridad = @isSeguridad,
isConsecutivo = @isConsecutivo,
isMantenimiento = @isMantenimiento,
isConsulta = @isConsulta
WHERE NOMBRE_USUARIO = @username
GO

--------------------------------------------------------------------------------------------------
---------------------------------------BITACORA--------------------------------------------
--------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_INSERTAR_BITACORA]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_INSERTAR_BITACORA]
END 
GO
CREATE PROCEDURE [dbo].[sp_INSERTAR_BITACORA]
(@code varchar(10)
,@user varchar(30)
,@time varchar(20)
,@type varchar(10)
,@desc varchar(max)
,@detail varchar(MAX))
AS

INSERT INTO BITACORA (CODIGO_REGISTRO, USUARIO, FECHA_HORA_BITACORA, TIPO, DESCRIPCION, REGISTRO_DETALLE)
VALUES (@code, @user, @time, @type, @desc, @detail)

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_BITACORA]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_BITACORA]
END
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_BITACORA]
AS

SELECT * 
FROM BITACORA

GO

--------------------------------------------------------------------------------------------------
---------------------------------------ERROR------------------------------------------------
--------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_INSERTAR_ERROR]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_INSERTAR_ERROR]
END 
GO
CREATE PROCEDURE [dbo].[sp_INSERTAR_ERROR]
(@numero varchar(10)
,@fecha_hora varchar(20)
,@mensaje varchar(MAX))
AS

INSERT INTO ERRORES(NUMERO_ERROR, FECHA_HORA_ERROR, MENSAJE_ERROR)
VALUES (@numero, @fecha_hora, @mensaje)

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[sp_TRAE_LISTA_ERROR]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
DROP PROCEDURE [dbo].[sp_TRAE_LISTA_ERROR]
END
GO
CREATE PROCEDURE [dbo].[sp_TRAE_LISTA_ERROR]
AS

SELECT * 
FROM ERRORES

GO






