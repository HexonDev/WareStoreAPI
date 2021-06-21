using Microsoft.EntityFrameworkCore.Migrations;

namespace WareStoreAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Addresses_AddressId",
                table: "Storages");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Storages_StorageId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StorageId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Stores");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Storages",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Addresses_AddressId",
                table: "Storages",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Addresses_AddressId",
                table: "Storages");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Stores",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StorageId",
                table: "Stores",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Storages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StorageId",
                table: "Stores",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Addresses_AddressId",
                table: "Storages",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Storages_StorageId",
                table: "Stores",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
