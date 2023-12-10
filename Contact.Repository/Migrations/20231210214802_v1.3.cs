using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Contact.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    IdContactInfo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPerson = table.Column<int>(type: "integer", nullable: false),
                    ContactType = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.IdContactInfo);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Corparete = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "ReportContent",
                columns: table => new
                {
                    IdReportContent = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "text", nullable: false),
                    PersonCount = table.Column<int>(type: "integer", nullable: false),
                    PhoneCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportContent", x => x.IdReportContent);
                });

            migrationBuilder.CreateTable(
                name: "ReportLookup",
                columns: table => new
                {
                    IdReportLookup = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportLookup", x => x.IdReportLookup);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "ReportContent");

            migrationBuilder.DropTable(
                name: "ReportLookup");
        }
    }
}
