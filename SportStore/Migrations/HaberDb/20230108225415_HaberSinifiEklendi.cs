using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportStore.Migrations.HaberDb
{
    public partial class HaberSinifiEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    HaberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaberBasligi = table.Column<string>(nullable: true),
                    HaberIcerigi = table.Column<string>(nullable: true),
                    HaberTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haberler", x => x.HaberId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haberler");
        }
    }
}
