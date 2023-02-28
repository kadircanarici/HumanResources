using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Data.Migrations
{
    /// <inheritdoc />
    public partial class employeeICollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "EmployeeCompanyPositions");

            migrationBuilder.RenameIndex(
                name: "IX_employeeCompanyPositions_PositionId",
                table: "EmployeeCompanyPositions",
                newName: "IX_EmployeeCompanyPositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeCompanyPositions_EmployeeId",
                table: "EmployeeCompanyPositions",
                newName: "IX_EmployeeCompanyPositions_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeCompanyPositions",
                table: "EmployeeCompanyPositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCompanyPositions_CompanyPositions_PositionId",
                table: "EmployeeCompanyPositions",
                column: "PositionId",
                principalTable: "CompanyPositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCompanyPositions_Employees_EmployeeId",
                table: "EmployeeCompanyPositions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCompanyPositions_CompanyPositions_PositionId",
                table: "EmployeeCompanyPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCompanyPositions_Employees_EmployeeId",
                table: "EmployeeCompanyPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeCompanyPositions",
                table: "EmployeeCompanyPositions");

            migrationBuilder.RenameTable(
                name: "EmployeeCompanyPositions",
                newName: "employeeCompanyPositions");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCompanyPositions_PositionId",
                table: "employeeCompanyPositions",
                newName: "IX_employeeCompanyPositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCompanyPositions_EmployeeId",
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeCompanyPositions_Employees_EmployeeId",
                table: "employeeCompanyPositions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
