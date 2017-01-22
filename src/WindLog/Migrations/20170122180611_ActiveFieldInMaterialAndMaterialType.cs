using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WindLog.Migrations
{
    public partial class ActiveFieldInMaterialAndMaterialType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Materials");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "MaterialTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Materials",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "MaterialTypes");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Materials");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Materials",
                nullable: false,
                defaultValue: false);
        }
    }
}
