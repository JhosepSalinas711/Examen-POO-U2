using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenU2Mario.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", maxLength: 13, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    apellido = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    documento = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha_contratacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    departamento = table.Column<string>(type: "TEXT", nullable: true),
                    puesto_trabajo = table.Column<string>(type: "TEXT", nullable: true),
                    Salario_Base = table.Column<decimal>(type: "TEXT", nullable: false),
                    activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Planillas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", maxLength: 13, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    periodo = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planillas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DetallesPlanilla",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    planilla_id = table.Column<int>(type: "INTEGER", nullable: false),
                    empleado_id = table.Column<int>(type: "INTEGER", nullable: false),
                    salario_base = table.Column<decimal>(type: "TEXT", nullable: false),
                    horas_extra = table.Column<decimal>(type: "TEXT", nullable: false),
                    monto_horas_extra = table.Column<decimal>(type: "TEXT", nullable: false),
                    bonificaciones = table.Column<decimal>(type: "TEXT", nullable: false),
                    deducciones = table.Column<decimal>(type: "TEXT", nullable: false),
                    salario_neto = table.Column<decimal>(type: "TEXT", nullable: false),
                    comentarios = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPlanilla", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallesPlanilla_Empleados_empleado_id",
                        column: x => x.empleado_id,
                        principalTable: "Empleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesPlanilla_Planillas_planilla_id",
                        column: x => x.planilla_id,
                        principalTable: "Planillas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlanilla_empleado_id",
                table: "DetallesPlanilla",
                column: "empleado_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlanilla_planilla_id",
                table: "DetallesPlanilla",
                column: "planilla_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesPlanilla");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Planillas");
        }
    }
}
