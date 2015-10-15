using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Taygeta.DataAccessLayer.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<long>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "ntext", isNullable: true),
                    HomePageTitle = table.Column<string>(isNullable: true),
                    LastModified = table.Column<DateTime>(isNullable: false),
                    Url = table.Column<string>(isNullable: true),
                    Wrapped = table.Column<DateTime>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Name = table.Column<string>(isNullable: false),
                    CultureName = table.Column<string>(isNullable: false),
                    Value = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => new { x.Name, x.CultureName });
                });
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<long>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Closed = table.Column<DateTime>(isNullable: true),
                    CompanyName = table.Column<string>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    EMail = table.Column<string>(isNullable: true),
                    Location = table.Column<string>(isNullable: true),
                    Position = table.Column<string>(isNullable: true),
                    Published = table.Column<DateTime>(isNullable: false),
                    Requirements = table.Column<string>(isNullable: true),
                    Url = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Wrappers",
                columns: table => new
                {
                    PageId = table.Column<long>(isNullable: false),
                    RecordNo = table.Column<int>(isNullable: false),
                    FieldName = table.Column<string>(isNullable: false),
                    ValuePath = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wrapper", x => new { x.PageId, x.RecordNo, x.FieldName });
                    table.ForeignKey(
                        name: "FK_Wrapper_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Resources");
            migrationBuilder.DropTable("Vacancies");
            migrationBuilder.DropTable("Wrappers");
            migrationBuilder.DropTable("Pages");
        }
    }
}
