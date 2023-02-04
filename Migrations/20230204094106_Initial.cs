using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SociologySimulator.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Nodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    MindId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Nodes_MindId",
                        column: x => x.MindId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Closures",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChildId = table.Column<int>(type: "INTEGER", nullable: false),
                    Depth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closures", x => new { x.ParentId, x.ChildId });
                    table.ForeignKey(
                        name: "FK_Closures_Nodes_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Closures_Nodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => new { x.NodeId, x.Name });
                    table.ForeignKey(
                        name: "FK_Tags_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Needs", null },
                    { 101, "Values", null }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "string" },
                    { 2, "float" },
                    { 3, "int" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "FirstName", "LastName", "MindId" },
                values: new object[,]
                {
                    { 1, "Josh", "Moody", 1 },
                    { 2, "Matthew", "Moody", 101 }
                });

            migrationBuilder.InsertData(
                table: "Closures",
                columns: new[] { "ChildId", "ParentId", "Depth" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 101, 101, 0 }
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, "Physical Needs", 1 },
                    { 3, "Social Needs", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Name", "NodeId", "TypeId", "Value" },
                values: new object[] { "Value", 101, 2, "0.51" });

            migrationBuilder.InsertData(
                table: "Closures",
                columns: new[] { "ChildId", "ParentId", "Depth" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 3, 1, 1 },
                    { 2, 2, 0 },
                    { 3, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 4, "Water", 2 },
                    { 5, "Food", 2 },
                    { 6, "Love", 3 }
                });

            migrationBuilder.InsertData(
                table: "Closures",
                columns: new[] { "ChildId", "ParentId", "Depth" },
                values: new object[,]
                {
                    { 4, 1, 2 },
                    { 5, 1, 2 },
                    { 6, 1, 2 },
                    { 4, 2, 1 },
                    { 5, 2, 1 },
                    { 6, 3, 1 },
                    { 4, 4, 0 },
                    { 5, 5, 0 },
                    { 6, 6, 0 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Name", "NodeId", "TypeId", "Value" },
                values: new object[,]
                {
                    { "Importance", 4, 2, "0.999" },
                    { "Status", 4, 2, "0.88" },
                    { "Importance", 5, 2, "0.97" },
                    { "Status", 5, 2, "0.77" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MindId",
                table: "Characters",
                column: "MindId");

            migrationBuilder.CreateIndex(
                name: "IX_Closures_ChildId",
                table: "Closures",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TypeId",
                table: "Tags",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Closures");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
