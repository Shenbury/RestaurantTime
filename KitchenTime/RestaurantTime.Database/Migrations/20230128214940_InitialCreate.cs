using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTime.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWorkingToday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuccessRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanCarryPlates = table.Column<bool>(type: "bit", nullable: false),
                    CanTakeOrders = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChefRecipe",
                columns: table => new
                {
                    ChefId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DateChefLearnedRecipe = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefRecipe", x => new { x.ChefId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_ChefRecipe_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChefRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UncookedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCooked = table.Column<bool>(type: "bit", nullable: false),
                    IsBurnt = table.Column<bool>(type: "bit", nullable: false),
                    IsEdible = table.Column<bool>(type: "bit", nullable: false),
                    IsServed = table.Column<bool>(type: "bit", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaiterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_Waiters_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "Waiters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InKitchen = table.Column<bool>(type: "bit", nullable: false),
                    BeenServed = table.Column<bool>(type: "bit", nullable: false),
                    PlatesTakenAway = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasOrderedFood = table.Column<bool>(type: "bit", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    WaiterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Waiters_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "Waiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkOrder",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkOrder", x => new { x.DrinkId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_DrinkOrder_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrder",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrder", x => new { x.FoodId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_FoodOrder_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chefs",
                columns: new[] { "Id", "IsWorkingToday", "Name" },
                values: new object[] { 1, true, "Bob Marley" });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Stuff with Tomato Juice", "Bloody Mary" });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "WaiterId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name", "SuccessRate" },
                values: new object[] { 1, "Some Jerkin Chicken", "Jerk Chicken", 0.9m });

            migrationBuilder.InsertData(
                table: "Waiters",
                columns: new[] { "Id", "CanCarryPlates", "CanTakeOrders", "Name" },
                values: new object[] { 1, false, true, "Michael Jackson" });

            migrationBuilder.InsertData(
                table: "ChefRecipe",
                columns: new[] { "ChefId", "RecipeId", "DateChefLearnedRecipe" },
                values: new object[] { 1, 1, new DateTime(2023, 1, 28, 21, 49, 39, 722, DateTimeKind.Local).AddTicks(7796) });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CookedName", "Description", "IsBurnt", "IsCooked", "IsEdible", "IsServed", "RecipeId", "UncookedName" },
                values: new object[] { 1, "Jerk Chicken", "Top Notch Jerk Chicken", false, false, false, false, 1, "Raw Chicken and Sauce" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BeenServed", "EndTime", "GuestId", "HasOrderedFood", "InKitchen", "PlatesTakenAway", "StartTime", "WaiterId" },
                values: new object[] { 1, false, null, 1, true, false, false, new DateTime(2023, 1, 28, 21, 49, 39, 723, DateTimeKind.Local).AddTicks(2071), 1 });

            migrationBuilder.InsertData(
                table: "DrinkOrder",
                columns: new[] { "DrinkId", "OrderId", "TimeOfOrder" },
                values: new object[] { 1, 1, new DateTime(2023, 1, 28, 21, 49, 39, 723, DateTimeKind.Local).AddTicks(2032) });

            migrationBuilder.InsertData(
                table: "FoodOrder",
                columns: new[] { "FoodId", "OrderId", "TimeOfOrder" },
                values: new object[] { 1, 1, new DateTime(2023, 1, 28, 21, 49, 39, 722, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.CreateIndex(
                name: "IX_ChefRecipe_RecipeId",
                table: "ChefRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkOrder_OrderId",
                table: "DrinkOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_OrderId",
                table: "FoodOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RecipeId",
                table: "Foods",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_WaiterId",
                table: "Guests",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GuestId",
                table: "Orders",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders",
                column: "WaiterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefRecipe");

            migrationBuilder.DropTable(
                name: "DrinkOrder");

            migrationBuilder.DropTable(
                name: "FoodOrder");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Waiters");
        }
    }
}
