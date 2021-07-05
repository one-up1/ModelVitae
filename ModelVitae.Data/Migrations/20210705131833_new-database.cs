using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelVitae.Data.Migrations
{
    public partial class newdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PersonalData_PersonalDataId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_PersonalData_PersonalDataId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "PersonalData");

            migrationBuilder.DropIndex(
                name: "IX_Models_PersonalDataId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PersonalDataId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonalDataId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "PersonalDataId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDataId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDataId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_PersonalDataId",
                table: "Models",
                column: "PersonalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PersonalDataId",
                table: "Customers",
                column: "PersonalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PersonalData_PersonalDataId",
                table: "Customers",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_PersonalData_PersonalDataId",
                table: "Models",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
