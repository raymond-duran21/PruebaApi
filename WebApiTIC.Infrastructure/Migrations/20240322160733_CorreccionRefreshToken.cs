using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTIC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_auditorias",
                table: "auditorias");

            migrationBuilder.RenameTable(
                name: "refreshTokens",
                newName: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "auditorias",
                newName: "Auditorias");

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenV",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditorias",
                table: "Auditorias",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditorias",
                table: "Auditorias");

            migrationBuilder.DropColumn(
                name: "RefreshTokenV",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "refreshTokens");

            migrationBuilder.RenameTable(
                name: "Auditorias",
                newName: "auditorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auditorias",
                table: "auditorias",
                column: "Id");
        }
    }
}
