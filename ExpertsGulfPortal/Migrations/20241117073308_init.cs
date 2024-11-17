using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpertsGulfPortal.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbitrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MastersThesisTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctoralThesisTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificSpecialization1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificSpecialization2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidencePlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaborMarketSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificAssociation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalCertificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestArbitrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificSpecialization1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificSpecialization2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MastersThesisTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctoralThesisTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidencePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborMarketSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScientificAssociation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestArbitrators", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbitrators");

            migrationBuilder.DropTable(
                name: "RequestArbitrators");
        }
    }
}
