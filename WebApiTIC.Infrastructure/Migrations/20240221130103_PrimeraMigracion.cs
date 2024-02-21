using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTIC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula_Pasaporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadosId);
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    AsignacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadosId = table.Column<int>(type: "int", nullable: false),
                    EquiposId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.AsignacionId);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Empleados_EmpleadosId",
                        column: x => x.EmpleadosId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    EquiposId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Almacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memoria_Ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procesador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre_Equipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadosId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsignacionesAsignacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquiposId);
                    table.ForeignKey(
                        name: "FK_Equipos_Asignaciones_AsignacionesAsignacionId",
                        column: x => x.AsignacionesAsignacionId,
                        principalTable: "Asignaciones",
                        principalColumn: "AsignacionId");
                    table.ForeignKey(
                        name: "FK_Equipos_Empleados_EmpleadosId",
                        column: x => x.EmpleadosId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_EmpleadosId",
                table: "Asignaciones",
                column: "EmpleadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_AsignacionesAsignacionId",
                table: "Equipos",
                column: "AsignacionesAsignacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EmpleadosId",
                table: "Equipos",
                column: "EmpleadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
