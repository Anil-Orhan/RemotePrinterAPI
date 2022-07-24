using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "FileSize",
                table: "Files",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Files");
        }
    }
}
