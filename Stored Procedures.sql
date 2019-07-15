--------------------------------------------------------------------------------------------------
---------------------------------------CONSECUTIVOS-----------------------------------------------
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
