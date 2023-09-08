using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HerramientasDeTrabajo",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerramientasDeTrabajo", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NivelDeIncidencias",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelDeIncidencias", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDeContactos",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeContactos", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDeDocumentos",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeDocumentos", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDeIncidencias",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeIncidencias", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDeVias",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abreviatura = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeVias", x => x.Pk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lugares",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_Area = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreasPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugares", x => x.Pk_Id);
                    table.ForeignKey(
                        name: "FK_Lugares_Areas_AreasPk_Id",
                        column: x => x.AreasPk_Id,
                        principalTable: "Areas",
                        principalColumn: "Pk_Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Pk_IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_TipoDocumento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDeDocumentosPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombres = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Pk_IdUser);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoDeDocumentos_TipoDeDocumentosPk_Id",
                        column: x => x.TipoDeDocumentosPk_Id,
                        principalTable: "TipoDeDocumentos",
                        principalColumn: "Pk_Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaUsuarios",
                columns: table => new
                {
                    Pk_AreaUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fk_Usuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosPk_IdUser = table.Column<int>(type: "int", nullable: true),
                    Fk_Area = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreasPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaUsuarios", x => x.Pk_AreaUsuario);
                    table.ForeignKey(
                        name: "FK_AreaUsuarios_Areas_AreasPk_Id",
                        column: x => x.AreasPk_Id,
                        principalTable: "Areas",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_AreaUsuarios_Usuarios_UsuariosPk_IdUser",
                        column: x => x.UsuariosPk_IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "Pk_IdUser");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Pk_Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fk_TipoContacto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDeContactosPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_Usuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosPk_IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Pk_Numero);
                    table.ForeignKey(
                        name: "FK_Contactos_TipoDeContactos_TipoDeContactosPk_Id",
                        column: x => x.TipoDeContactosPk_Id,
                        principalTable: "TipoDeContactos",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_Contactos_Usuarios_UsuariosPk_IdUser",
                        column: x => x.UsuariosPk_IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "Pk_IdUser");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Pk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_TipoVia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDeViasPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroDireccion = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SufijoCardinal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_Usuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosPk_IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Pk_Id);
                    table.ForeignKey(
                        name: "FK_Direcciones_TipoDeVias_TipoDeViasPk_Id",
                        column: x => x.TipoDeViasPk_Id,
                        principalTable: "TipoDeVias",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_Direcciones_Usuarios_UsuariosPk_IdUser",
                        column: x => x.UsuariosPk_IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "Pk_IdUser");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    PK_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_Usuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosPk_IdUser = table.Column<int>(type: "int", nullable: true),
                    Fk_Area = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreasPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_Lugar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LugaresPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.PK_Id);
                    table.ForeignKey(
                        name: "FK_Incidencias_Areas_AreasPk_Id",
                        column: x => x.AreasPk_Id,
                        principalTable: "Areas",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_Incidencias_Lugares_LugaresPk_Id",
                        column: x => x.LugaresPk_Id,
                        principalTable: "Lugares",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_Incidencias_Usuarios_UsuariosPk_IdUser",
                        column: x => x.UsuariosPk_IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "Pk_IdUser");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolesPk_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuariosPk_IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RolesPk_Id, x.UsuariosPk_IdUser });
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rols_RolesPk_Id",
                        column: x => x.RolesPk_Id,
                        principalTable: "Rols",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuarios_UsuariosPk_IdUser",
                        column: x => x.UsuariosPk_IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "Pk_IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioRols",
                columns: table => new
                {
                    IdUsuarioRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fk_UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuariosPk_IdUser = table.Column<int>(type: "int", nullable: true),
                    Fk_Rol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRols", x => x.IdUsuarioRol);
                    table.ForeignKey(
                        name: "FK_UsuarioRols_Rols_RolPk_Id",
                        column: x => x.RolPk_Id,
                        principalTable: "Rols",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_UsuarioRols_Usuarios_UsuariosPk_IdUser",
                        column: x => x.UsuariosPk_IdUser,
                        principalTable: "Usuarios",
                        principalColumn: "Pk_IdUser");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleDeIncidencias",
                columns: table => new
                {
                    Pk_DetalleIncidencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionIncidencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_Incidencia = table.Column<int>(type: "int", nullable: false),
                    IncidenciasPK_Id = table.Column<int>(type: "int", nullable: true),
                    Fk_TipoIncidencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TiposDeIncidenciasPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_NivelIncidencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NivelDeIncidenciasPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_Herramienta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HerramientasDeTrabajoPk_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeIncidencias", x => x.Pk_DetalleIncidencia);
                    table.ForeignKey(
                        name: "FK_DetalleDeIncidencias_HerramientasDeTrabajo_HerramientasDeTra~",
                        column: x => x.HerramientasDeTrabajoPk_Id,
                        principalTable: "HerramientasDeTrabajo",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_DetalleDeIncidencias_Incidencias_IncidenciasPK_Id",
                        column: x => x.IncidenciasPK_Id,
                        principalTable: "Incidencias",
                        principalColumn: "PK_Id");
                    table.ForeignKey(
                        name: "FK_DetalleDeIncidencias_NivelDeIncidencias_NivelDeIncidenciasPk~",
                        column: x => x.NivelDeIncidenciasPk_Id,
                        principalTable: "NivelDeIncidencias",
                        principalColumn: "Pk_Id");
                    table.ForeignKey(
                        name: "FK_DetalleDeIncidencias_TipoDeIncidencias_TiposDeIncidenciasPk_~",
                        column: x => x.TiposDeIncidenciasPk_Id,
                        principalTable: "TipoDeIncidencias",
                        principalColumn: "Pk_Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUsuarios_AreasPk_Id",
                table: "AreaUsuarios",
                column: "AreasPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUsuarios_UsuariosPk_IdUser",
                table: "AreaUsuarios",
                column: "UsuariosPk_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_TipoDeContactosPk_Id",
                table: "Contactos",
                column: "TipoDeContactosPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_UsuariosPk_IdUser",
                table: "Contactos",
                column: "UsuariosPk_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeIncidencias_HerramientasDeTrabajoPk_Id",
                table: "DetalleDeIncidencias",
                column: "HerramientasDeTrabajoPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeIncidencias_IncidenciasPK_Id",
                table: "DetalleDeIncidencias",
                column: "IncidenciasPK_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeIncidencias_NivelDeIncidenciasPk_Id",
                table: "DetalleDeIncidencias",
                column: "NivelDeIncidenciasPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeIncidencias_TiposDeIncidenciasPk_Id",
                table: "DetalleDeIncidencias",
                column: "TiposDeIncidenciasPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_TipoDeViasPk_Id",
                table: "Direcciones",
                column: "TipoDeViasPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_UsuariosPk_IdUser",
                table: "Direcciones",
                column: "UsuariosPk_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_AreasPk_Id",
                table: "Incidencias",
                column: "AreasPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_LugaresPk_Id",
                table: "Incidencias",
                column: "LugaresPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_UsuariosPk_IdUser",
                table: "Incidencias",
                column: "UsuariosPk_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Lugares_AreasPk_Id",
                table: "Lugares",
                column: "AreasPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosPk_IdUser",
                table: "RolUsuario",
                column: "UsuariosPk_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRols_RolPk_Id",
                table: "UsuarioRols",
                column: "RolPk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRols_UsuariosPk_IdUser",
                table: "UsuarioRols",
                column: "UsuariosPk_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoDeDocumentosPk_Id",
                table: "Usuarios",
                column: "TipoDeDocumentosPk_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaUsuarios");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "DetalleDeIncidencias");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "UsuarioRols");

            migrationBuilder.DropTable(
                name: "TipoDeContactos");

            migrationBuilder.DropTable(
                name: "HerramientasDeTrabajo");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "NivelDeIncidencias");

            migrationBuilder.DropTable(
                name: "TipoDeIncidencias");

            migrationBuilder.DropTable(
                name: "TipoDeVias");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Lugares");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "TipoDeDocumentos");
        }
    }
}
