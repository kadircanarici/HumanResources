using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCompanyPosition_CompanyPositions_PositionId",
                table: "EmployeeCompanyPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCompanyPosition_Employees_EmployeeId",
                table: "EmployeeCompanyPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeCompanyPosition",
                table: "EmployeeCompanyPosition");

            migrationBuilder.RenameTable(
                name: "EmployeeCompanyPosition",
                newName: "employeeCompanyPositions");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCompanyPosition_PositionId",
                table: "employeeCompanyPositions",
                newName: "IX_employeeCompanyPositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCompanyPosition_EmployeeId",
                table: "employeeCompanyPositions",
                newName: "IX_employeeCompanyPositions_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeCompanyPositions",
                table: "employeeCompanyPositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeCompanyPositions_CompanyPositions_PositionId",
                table: "employeeCompanyPositions",
                column: "PositionId",
                principalTable: "CompanyPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeCompanyPositions_Employees_EmployeeId",
                table: "employeeCompanyPositions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeCompanyPositions_CompanyPositions_PositionId",
                table: "employeeCompanyPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_employeeCompanyPositions_Employees_EmployeeId",
                table: "employeeCompanyPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeCompanyPositions",
                table: "employeeCompanyPositions");

            migrationBuilder.RenameTable(
                name: "employeeCompanyPositions",
                newName: "EmployeeCompanyPosition");

            migrationBuilder.RenameIndex(
                name: "IX_employeeCompanyPositions_PositionId",
                table: "EmployeeCompanyPosition",
                newName: "IX_EmployeeCompanyPosition_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeCompanyPositions_EmployeeId",
                table: "EmployeeCompanyPosition",
                newName: "IX_EmployeeCompanyPosition_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeCompanyPosition",
                table: "EmployeeCompanyPosition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCompanyPosition_CompanyPositions_PositionId",
                table: "EmployeeCompanyPosition",
                column: "PositionId",
                principalTable: "CompanyPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCompanyPosition_Employees_EmployeeId",
                table: "EmployeeCompanyPosition",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
