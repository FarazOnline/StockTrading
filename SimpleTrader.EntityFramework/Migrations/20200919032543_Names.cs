using Microsoft.EntityFrameworkCore.Migrations;

namespace StockTrader.EntityFramework.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_WhichUserUserId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetTransactions",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WhichUserUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "AssetTransactions");

            migrationBuilder.DropColumn(
                name: "WhichUserUserId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AssetTransactions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WhichUserId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetTransactions",
                table: "AssetTransactions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WhichUserId",
                table: "Accounts",
                column: "WhichUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_WhichUserId",
                table: "Accounts",
                column: "WhichUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_WhichUserId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetTransactions",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WhichUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AssetTransactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "WhichUserId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "AssetTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "WhichUserUserId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetTransactions",
                table: "AssetTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WhichUserUserId",
                table: "Accounts",
                column: "WhichUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_WhichUserUserId",
                table: "Accounts",
                column: "WhichUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
