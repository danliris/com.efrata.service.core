﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Efrata.Service.Core.Lib.Migrations
{
    public partial class garmentbuyerBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GarmentBuyerBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BuyerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    _CreatedAgent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    _CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    _CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _DeletedAgent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    _DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    _DeletedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    _LastModifiedAgent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    _LastModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    _LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentBuyerBrands", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarmentBuyerBrands");
        }
    }
}
