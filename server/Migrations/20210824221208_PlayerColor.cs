﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LeekQuest.Migrations
{
    public partial class PlayerColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "AspNetUsers",
                newName: "PlayerColor");

            migrationBuilder.RenameColumn(
                name: "NumLikes",
                table: "AspNetUsers",
                newName: "PositionY");

            migrationBuilder.AddColumn<int>(
                name: "PositionX",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionX",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PositionY",
                table: "AspNetUsers",
                newName: "NumLikes");

            migrationBuilder.RenameColumn(
                name: "PlayerColor",
                table: "AspNetUsers",
                newName: "Position");
        }
    }
}
