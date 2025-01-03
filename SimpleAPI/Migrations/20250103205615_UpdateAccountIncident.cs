using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Accounts_AccountName",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_AccountName",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Incidents");

            migrationBuilder.AddColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

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
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts",
                column: "AccountName",
                principalTable: "Accounts",
                principalColumn: "Name",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountName",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts");

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

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AccountName",
                table: "Incidents",
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
    }
}
