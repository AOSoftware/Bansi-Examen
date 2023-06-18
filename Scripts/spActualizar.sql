USE [BdiExamen]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Alberto Ovalle
-- Create date: 15-06-2023
-- Description:	Procedimiento spActualizar para actualizar un
--                registro en la tabla tblExamen.
-- =======================================================
CREATE PROCEDURE spActualizar
    @Id INT,
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255),
	@CodigoRetorno INT OUTPUT,
    @DescripcionRetorno VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
       UPDATE tblExamen 
	   SET Nombre = @Nombre, Descripcion =  @Descripcion
       WHERE idExamen = @Id;

       IF @@ROWCOUNT > 0
        BEGIN
            SET @CodigoRetorno = 0;
            SET @DescripcionRetorno = 'Registro actualizado satisfactoriamente';
        END
        ELSE
        BEGIN
            SET @CodigoRetorno = 1;
            SET @DescripcionRetorno = 'No se encontró el registro con el Id proporcionado';
        END     
    END TRY

    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = 'Error: ' + ERROR_MESSAGE();
    END CATCH;

	SELECT @CodigoRetorno AS CodigoRetorno, @DescripcionRetorno AS DescripcionRetorno;
END
