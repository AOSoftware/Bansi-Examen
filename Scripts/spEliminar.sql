USE [BdiExamen]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Alberto Ovalle
-- Create date: 15-06-2023
-- Description:	Procedimiento spEliminar para eliminar un
--                registro en la tabla tblExamen.
-- =======================================================
CREATE PROCEDURE spEliminar
    @Id INT,
    @CodigoRetorno INT OUTPUT,
    @DescripcionRetorno VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM tblExamen
        WHERE idExamen = @Id;

        IF @@ROWCOUNT > 0
        BEGIN
            SET @CodigoRetorno = 0;
            SET @DescripcionRetorno = 'Registro eliminado satisfactoriamente';
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
