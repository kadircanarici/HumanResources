using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonalTableNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeEducations_degrees_DegreeId",
                table: "employeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_employeeEducations_educationProviders_EducationProviderId",
                table: "employeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_employeeEducations_employees_EmployeeId",
                table: "employeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_employeeEducations_fieldOfStudies_FieldOfStudyId",
                table: "employeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_companies_CompanyId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_positions_PositionId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_positions_companies_CompanyId",
                table: "positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_positions",
                table: "positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fieldOfStudies",
                table: "fieldOfStudies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeEducations",
                table: "employeeEducations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_educationProviders",
                table: "educationProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_degrees",
                table: "degrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "positions",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "fieldOfStudies",
                newName: "FieldOfStudies");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "employeeEducations",
                newName: "EmployeeEducations");

            migrationBuilder.RenameTable(
                name: "educationProviders",
                newName: "EducationProviders");

            migrationBuilder.RenameTable(
                name: "degrees",
                newName: "Degrees");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_positions_CompanyId",
                table: "Positions",
                newName: "IX_Positions_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_PositionId",
                table: "Employees",
                newName: "IX_Employees_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_CompanyId",
                table: "Employees",
                newName: "IX_Employees_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeEducations_FieldOfStudyId",
                table: "EmployeeEducations",
                newName: "IX_EmployeeEducations_FieldOfStudyId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeEducations_EmployeeId",
                table: "EmployeeEducations",
                newName: "IX_EmployeeEducations_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeEducations_EducationProviderId",
                table: "EmployeeEducations",
                newName: "IX_EmployeeEducations_EducationProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeEducations_DegreeId",
                table: "EmployeeEducations",
                newName: "IX_EmployeeEducations_DegreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldOfStudies",
                table: "FieldOfStudies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEducations",
                table: "EmployeeEducations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationProviders",
                table: "EducationProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_Degrees_DegreeId",
                table: "EmployeeEducations",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_EducationProviders_EducationProviderId",
                table: "EmployeeEducations",
                column: "EducationProviderId",
                principalTable: "EducationProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_Employees_EmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_FieldOfStudies_FieldOfStudyId",
                table: "EmployeeEducations",
                column: "FieldOfStudyId",
                principalTable: "FieldOfStudies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Companies_CompanyId",
                table: "Positions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_Degrees_DegreeId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EducationProviders_EducationProviderId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_Employees_EmployeeId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_FieldOfStudies_FieldOfStudyId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Companies_CompanyId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldOfStudies",
                table: "FieldOfStudies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEducations",
                table: "EmployeeEducations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationProviders",
                table: "EducationProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "positions");

            migrationBuilder.RenameTable(
                name: "FieldOfStudies",
                newName: "fieldOfStudies");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "EmployeeEducations",
                newName: "employeeEducations");

            migrationBuilder.RenameTable(
                name: "EducationProviders",
                newName: "educationProviders");

            migrationBuilder.RenameTable(
                name: "Degrees",
                newName: "degrees");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "companies");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_CompanyId",
                table: "positions",
                newName: "IX_positions_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionId",
                table: "employees",
                newName: "IX_employees_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyId",
                table: "employees",
                newName: "IX_employees_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEducations_FieldOfStudyId",
                table: "employeeEducations",
                newName: "IX_employeeEducations_FieldOfStudyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEducations_EmployeeId",
                table: "employeeEducations",
                newName: "IX_employeeEducations_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEducations_EducationProviderId",
                table: "employeeEducations",
                newName: "IX_employeeEducations_EducationProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEducations_DegreeId",
                table: "employeeEducations",
                newName: "IX_employeeEducations_DegreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_positions",
                table: "positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fieldOfStudies",
                table: "fieldOfStudies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeEducations",
                table: "employeeEducations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_educationProviders",
                table: "educationProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_degrees",
                table: "degrees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeEducations_degrees_DegreeId",
                table: "employeeEducations",
                column: "DegreeId",
                principalTable: "degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeEducations_educationProviders_EducationProviderId",
                table: "employeeEducations",
                column: "EducationProviderId",
                principalTable: "educationProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeEducations_employees_EmployeeId",
                table: "employeeEducations",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeEducations_fieldOfStudies_FieldOfStudyId",
                table: "employeeEducations",
                column: "FieldOfStudyId",
                principalTable: "fieldOfStudies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_companies_CompanyId",
                table: "employees",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_positions_PositionId",
                table: "employees",
                column: "PositionId",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_positions_companies_CompanyId",
                table: "positions",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id");
        }
    }
}
