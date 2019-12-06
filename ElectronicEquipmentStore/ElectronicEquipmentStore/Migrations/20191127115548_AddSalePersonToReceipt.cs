using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicEquipmentStore.Migrations
{
    public partial class AddSalePersonToReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalePersonID",
                table: "Receipt",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_SalePersonID",
                table: "Receipt",
                column: "SalePersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_AspNetUsers_SalePersonID",
                table: "Receipt",
                column: "SalePersonID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_AspNetUsers_SalePersonID",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_SalePersonID",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "SalePersonID",
                table: "Receipt");
        }
    }
}
