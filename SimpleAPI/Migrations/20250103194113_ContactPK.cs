using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    /// <inheritdoc />
    public partial class ContactPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Contacts_ContactId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ContactId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Accounts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ContactEmail",
                table: "Accounts",
                column: "ContactEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Contacts_ContactEmail",
                table: "Accounts",
                column: "ContactEmail",
                principalTable: "Contacts",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Contacts_ContactEmail",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ContactEmail",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ContactId",
                table: "Accounts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Contacts_ContactId",
                table: "Accounts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
