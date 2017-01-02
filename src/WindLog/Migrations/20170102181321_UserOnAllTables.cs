using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WindLog.Migrations
{
    public partial class UserOnAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Spots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SessionMaterials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "MaterialTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Materials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Spots");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SessionMaterials");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "MaterialTypes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Materials");
        }
    }
}
