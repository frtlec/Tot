using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Question");

            migrationBuilder.CreateTable(
                name: "QuestionPoolCategories",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPoolCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionPools",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    QuestionFormatType = table.Column<string>(type: "text", nullable: false),
                    SourceType = table.Column<string>(type: "text", nullable: false),
                    LikeCount = table.Column<long>(type: "bigint", nullable: false),
                    FriendlyUrl = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UseLastAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    QuestionPoolCategoryId = table.Column<int>(type: "integer", nullable: true),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionPools_QuestionPoolCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Question",
                        principalTable: "QuestionPoolCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionPools_QuestionPoolCategories_QuestionPoolCategoryId",
                        column: x => x.QuestionPoolCategoryId,
                        principalSchema: "Question",
                        principalTable: "QuestionPoolCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionPoolItems",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionPoolId = table.Column<int>(type: "integer", nullable: false),
                    OptionText = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPoolItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionPoolItems_QuestionPools_QuestionPoolId",
                        column: x => x.QuestionPoolId,
                        principalSchema: "Question",
                        principalTable: "QuestionPools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPoolCategories_UniqueId",
                schema: "Question",
                table: "QuestionPoolCategories",
                column: "UniqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPoolItems_QuestionPoolId",
                schema: "Question",
                table: "QuestionPoolItems",
                column: "QuestionPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPoolItems_UniqueId",
                schema: "Question",
                table: "QuestionPoolItems",
                column: "UniqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPools_CategoryId",
                schema: "Question",
                table: "QuestionPools",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPools_QuestionPoolCategoryId",
                schema: "Question",
                table: "QuestionPools",
                column: "QuestionPoolCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPools_UniqueId",
                schema: "Question",
                table: "QuestionPools",
                column: "UniqueId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionPoolItems",
                schema: "Question");

            migrationBuilder.DropTable(
                name: "QuestionPools",
                schema: "Question");

            migrationBuilder.DropTable(
                name: "QuestionPoolCategories",
                schema: "Question");
        }
    }
}
