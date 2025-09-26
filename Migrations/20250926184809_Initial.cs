using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fantasy_life_i_material_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crafted = table.Column<bool>(type: "bit", nullable: false),
                    GatheredFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Category", "Crafted", "GatheredFrom", "LifeRequired", "Name" },
                values: new object[,]
                {
                    { 1, "Carpentry Material", false, "[\"Starry Tree\",\"Great Starry Tree\"]", "Woodcuter", "Starry Log" },
                    { 2, "Smithing Material", false, "[\"Gold Deposit\",\"Great Gold Deposit\",\"Superior Gold Deposit\",\"Amazing Gold Deposit\"]", "Miner", "Swolean Gold" },
                    { 3, "Tailoring Material", false, "[\"Ground\"]", null, "Sunny Puff" },
                    { 4, "Artistry Material", false, "[\"Ground\"]", null, "Red Anthurium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
