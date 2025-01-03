using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    /// <inheritdoc />
    public partial class RepairStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AccountName",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IncidentName",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Incidents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AccountName",
                table: "Incidents",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ContactId",
                table: "Accounts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Name",
                table: "Accounts",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Contacts_ContactId",
                table: "Accounts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents",
                column: "AccountName",
                principalTable: "Accounts",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Contacts_ContactId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_AccountName",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ContactId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Name",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Contacts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountName",
                table: "Contacts",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts",
                column: "IncidentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "IncidentName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts",
                column: "AccountName",
                principalTable: "Accounts",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
