IF NOT EXISTS (
    SELECT 1 FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[Socios]') AND type = N'U'
)
BEGIN
    CREATE TABLE [dbo].[Socios] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Nombre] NVARCHAR(200) NOT NULL,
        [FechaAlta] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
        -- Añadir columnas necesarias
    );
END