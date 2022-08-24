using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.Server.Data.Migrations
{
    public partial class FavouriteTickersTablerepaired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteTickers",
                table: "FavouriteTickers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteTickers",
                table: "FavouriteTickers",
                columns: new[] { "UserId", "Ticker" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteTickers",
                table: "FavouriteTickers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteTickers",
                table: "FavouriteTickers",
                column: "UserId");
        }
    }
}
