using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Contacts_ContactEmail",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents");

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

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Contacts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountName",
                table: "Contacts",
                column: "AccountName");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts",
                column: "AccountName",
                principalTable: "Accounts",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents",
                column: "AccountName",
                principalTable: "Accounts",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AccountName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Contacts");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents",
                column: "AccountName",
                principalTable: "Accounts",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
