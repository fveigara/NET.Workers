using System;
using System.Data.SqlClient;

public static class DbInitializer
{
    public static void EnsureSociosTable(string connectionString)
    {
        const string createIfNotExists = @"
IF NOT EXISTS (
    SELECT 1 FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[Socios]') AND type = N'U'
)
BEGIN
    CREATE TABLE [dbo].[Socios] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Nombre] NVARCHAR(200) NOT NULL,
        [FechaAlta] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END
";
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(createIfNotExists, conn))
        {
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Log y rethrow: importante no silenciar
                // Registrar ex.Number, ex.Message, la cadena de conexión (sin credenciales)
                throw;
            }
        }
    }
}