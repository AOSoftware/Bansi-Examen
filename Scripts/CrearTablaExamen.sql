/**** Utilizar DB Examen ****/
USE BdiExamen
GO

/**** Activar Seteos  basicos ****/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/**** Crear Tabla con Llave identificador unico autoncremental ****/
CREATE TABLE [dbo].[tblExamen](
	[idExamen] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_tblExamen] PRIMARY KEY CLUSTERED 
(
	[idExamen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


