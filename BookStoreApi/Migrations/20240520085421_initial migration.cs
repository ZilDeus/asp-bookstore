using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations
{
  /// <inheritdoc />
  public partial class initialmigration : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "app_user",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Username = table.Column<string>(type: "text", nullable: false),
            Email = table.Column<string>(type: "text", nullable: false),
            Password = table.Column<string>(type: "text", nullable: false),
            Role = table.Column<string>(type: "text", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_app_user", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "author",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Name = table.Column<string>(type: "text", nullable: false),
            Country = table.Column<string>(type: "text", nullable: false),
            City = table.Column<string>(type: "text", nullable: false),
            Age = table.Column<int>(type: "integer", nullable: false),
            Rating = table.Column<int>(type: "integer", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_author", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Book",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Title = table.Column<string>(type: "text", nullable: false),
            published_at = table.Column<DateOnly>(type: "date", nullable: false),
            Genre = table.Column<string>(type: "text", nullable: false),
            AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
            Rating = table.Column<int>(type: "integer", nullable: false),
            AppUserId = table.Column<Guid>(type: "uuid", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_book", x => x.Id);
            table.ForeignKey(
                      name: "FK_book_app_user_AppUserId",
                      column: x => x.AppUserId,
                      principalTable: "app_user",
                      principalColumn: "Id");
            table.ForeignKey(
                      name: "FK_book_author_AuthorId",
                      column: x => x.AuthorId,
                      principalTable: "author",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "report",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Content = table.Column<string>(type: "text", nullable: false),
            BookId = table.Column<Guid>(type: "uuid", nullable: false),
            UserId = table.Column<Guid>(type: "uuid", nullable: false),
            AuthorId = table.Column<Guid>(type: "uuid", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_report", x => x.Id);
            table.ForeignKey(
                      name: "FK_report_app_user_UserId",
                      column: x => x.UserId,
                      principalTable: "app_user",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_report_author_AuthorId",
                      column: x => x.AuthorId,
                      principalTable: "author",
                      principalColumn: "Id");
            table.ForeignKey(
                      name: "FK_report_book_BookId",
                      column: x => x.BookId,
                      principalTable: "Book",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "review",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Score = table.Column<int>(type: "integer", nullable: false),
            Content = table.Column<string>(type: "text", nullable: true),
            bookId = table.Column<Guid>(type: "uuid", nullable: false),
            UserId = table.Column<Guid>(type: "uuid", nullable: false),
            AuthorId = table.Column<Guid>(type: "uuid", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_review", x => x.Id);
            table.ForeignKey(
                      name: "FK_review_app_user_UserId",
                      column: x => x.UserId,
                      principalTable: "app_user",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_review_author_AuthorId",
                      column: x => x.AuthorId,
                      principalTable: "author",
                      principalColumn: "Id");
            table.ForeignKey(
                      name: "FK_review_book_bookId",
                      column: x => x.bookId,
                      principalTable: "Book",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_book_AppUserId",
          table: "Book",
          column: "AppUserId");

      migrationBuilder.CreateIndex(
          name: "IX_book_AuthorId",
          table: "Book",
          column: "AuthorId");

      migrationBuilder.CreateIndex(
          name: "IX_report_AuthorId",
          table: "report",
          column: "AuthorId");

      migrationBuilder.CreateIndex(
          name: "IX_report_BookId",
          table: "report",
          column: "BookId");

      migrationBuilder.CreateIndex(
          name: "IX_report_UserId",
          table: "report",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_review_AuthorId",
          table: "review",
          column: "AuthorId");

      migrationBuilder.CreateIndex(
          name: "IX_review_bookId",
          table: "review",
          column: "bookId");

      migrationBuilder.CreateIndex(
          name: "IX_review_UserId",
          table: "review",
          column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "report");

      migrationBuilder.DropTable(
          name: "review");

      migrationBuilder.DropTable(
          name: "Book");

      migrationBuilder.DropTable(
          name: "app_user");

      migrationBuilder.DropTable(
          name: "author");
    }
  }
}
