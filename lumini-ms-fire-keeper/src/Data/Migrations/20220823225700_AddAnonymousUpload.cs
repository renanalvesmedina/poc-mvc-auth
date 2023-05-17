﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumini.FireKeeper.Data.Migrations
{
    public partial class AddAnonymousUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnonymousUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileOriginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymousUploads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnonymousUploads");
        }
    }
}