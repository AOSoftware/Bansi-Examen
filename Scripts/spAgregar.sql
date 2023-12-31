USE [BdiExamen]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Alberto Ovalle
-- Create date: 15-06-2023
-- Description:	Procedimiento spAgregar para insertar un
--                registro en la tabla tblExamen.
-- =======================================================
CREATE PROCEDURE spAgregar
    @Id INT,
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255),
	@CodigoRetorno INT OUTPUT,
    @DescripcionRetorno VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        INSERT INTO tblExamen (Nombre, Descripcion)
        VALUES (@Nombre, @Descripcion);
        
        SET @CodigoRetorno = 0;
        SET @DescripcionRetorno = 'Registro insertado satisfactoriamente';
    END TRY

    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = 'Error: ' + ERROR_MESSAGE();
    END CATCH;

	SELECT @CodigoRetorno AS CodigoRetorno, @DescripcionRetorno AS DescripcionRetorno;
END

