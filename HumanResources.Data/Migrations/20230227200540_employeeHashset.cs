using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Data.Migrations
{
    /// <inheritdoc />
    public partial class employeeHashset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeCompanyPositions_CompanyPositions_PositionId",
                table: "employeeCompanyPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_Degrees_DegreeId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EducationProviders_EducationProviderId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_FieldOfStudies_FieldOfStudyId",
                table: "EmployeeEducations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationDate",
                table: "EmployeeEducations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "FieldOfStudyId",
                table: "EmployeeEducations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationProviderId",
                table: "EmployeeEducations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DegreeId",
                table: "EmployeeEducations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "employeeCompanyPositions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "employeeCompanyPositions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeCompanyPositions_CompanyPositions_PositionId",
                table: "employeeCompanyPositions",
                column: "PositionId",
                principalTable: "CompanyPositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_Degrees_DegreeId",
                table: "EmployeeEducations",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_EducationProviders_EducationProviderId",
                table: "EmployeeEducations",
                column: "EducationProviderId",
                principalTable: "EducationProviders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_FieldOfStudies_FieldOfStudyId",
                table: "EmployeeEducations",
                column: "FieldOfStudyId",
                principalTable: "FieldOfStudies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeCompanyPositions_CompanyPositions_PositionId",
                table: "employeeCompanyPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_Degrees_DegreeId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EducationProviders_EducationProviderId",
                table: "EmployeeEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_FieldOfStudies_FieldOfStudyId",
                table: "EmployeeEducations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationDate",
                table: "EmployeeEducations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FieldOfStudyId",
                table: "EmployeeEducations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationProviderId",
                table: "EmployeeEducations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DegreeId",
                table: "EmployeeEducations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "employeeCompanyPositions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "employeeCompanyPositions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeCompanyPositions_CompanyPositions_PositionId",
                table: "employeeCompanyPositions",
                column: "PositionId",
                principalTable: "CompanyPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_EmployeeEducations_FieldOfStudies_FieldOfStudyId",
                table: "EmployeeEducations",
                column: "FieldOfStudyId",
                principalTable: "FieldOfStudies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
