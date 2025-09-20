using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fantasy_life_i_material_API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Category", "Gatherable", "GatheredFrom", "LifeRequired", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Carpentry Material", true, "[\"Starry Tree\",\"Great Starry Tree\"]", "Woodcuter", "Starry Log", "Log" },
                    { 2, "Smithing Material", true, "[\"Gold Deposit\",\"Great Gold Deposit\",\"Superior Gold Deposit\",\"Amazing Gold Deposit\"]", "Miner", "Swolean Gold", "Ore" },
                    { 3, "Tailoring Material", true, "[\"Ground\"]", null, "Sunny Puff", "Plant" },
                    { 4, "Artistry Material", true, "[\"Ground\"]", null, "Red Anthurium", "Plant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
