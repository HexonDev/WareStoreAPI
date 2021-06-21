using Microsoft.EntityFrameworkCore.Migrations;

namespace WareStoreAPI.Migrations
{
    public partial class updateAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressString",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Door",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Addresses",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Door",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "AddressString",
                table: "Addresses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
