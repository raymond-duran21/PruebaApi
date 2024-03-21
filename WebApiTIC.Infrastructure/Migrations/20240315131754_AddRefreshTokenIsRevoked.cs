using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTIC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenIsRevoked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRevoked",
                table: "refreshTokens",
                type: "bit",
                nullable: false,
                computedColumnSql: "iif(ExpiryDate < getdate(), convert(bit,0), convert(bit,1))",
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRevoked",
                table: "refreshTokens",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComputedColumnSql: "iif(ExpiryDate < getdate(), convert(bit,0), convert(bit,1))");
        }
    }
}
