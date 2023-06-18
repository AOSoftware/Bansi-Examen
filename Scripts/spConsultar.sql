USE [BdiExamen]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Alberto Ovalle
-- Create date: 15-06-2023
-- Description:	Procedimiento spConsultar para consultar 
--              registros en base a parametros dados
--              en la tabla tblExamen.
-- =======================================================
CREATE PROCEDURE spConsultar
    @Nombre VARCHAR(255) = NULL,
    @Descripcion VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idExamen, Nombre, Descripcion
    FROM tblExamen
    WHERE (@Nombre IS NULL OR Nombre = @Nombre)
      AND (@Descripcion IS NULL OR Descripcion = @Descripcion);
END

