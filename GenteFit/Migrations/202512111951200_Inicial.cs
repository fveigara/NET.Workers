namespace GenteFit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(),
                        Intensidad = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Sesions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActividadId = c.Int(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                        Sala = c.String(),
                        Monitor = c.String(),
                        AforoMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actividads", t => t.ActividadId, cascadeDelete: true)
                .Index(t => t.ActividadId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        SesionId = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        PosicionEspera = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sesions", t => t.SesionId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.SesionId);

            CreateTable(
                "dbo.Clientes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false),
                    Apellidos = c.String(),
                    Documento = c.String(nullable: false, maxLength: 20),
                    Email = c.String(),
                    Telefono = c.String(),
                    IsActive = c.Boolean(nullable: false),
                    FechaAlta = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ClienteRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteRols", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ClienteRols", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Reservas", "SesionId", "dbo.Sesions");
            DropForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Sesions", "ActividadId", "dbo.Actividads");
            DropIndex("dbo.ClienteRols", new[] { "RolId" });
            DropIndex("dbo.ClienteRols", new[] { "UsuarioId" });
            DropIndex("dbo.Reservas", new[] { "SesionId" });
            DropIndex("dbo.Reservas", new[] { "ClienteId" });
            DropIndex("dbo.Sesions", new[] { "ActividadId" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Rols");
            DropTable("dbo.ClienteRols");
            DropTable("dbo.Clientes");
            DropTable("dbo.Reservas");
            DropTable("dbo.Sesions");
            DropTable("dbo.Actividads");
        }
    }
}
