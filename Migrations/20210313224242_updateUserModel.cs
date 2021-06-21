using Microsoft.EntityFrameworkCore.Migrations;

namespace WareStoreAPI.Migrations
{
    public partial class updateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PermissionLevel",
                table: "Users",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.Sql("INSERT INTO `users` (`Id`, `FirstName`, `LastName`, `Username`, `PasswordHash`, `PasswordSalt`, `PermissionLevel`) VALUES (1, 'admin', 'admin', 'admin', 0xaf58e5efdfa5473ca1f5f70a7bc37721905f804eefa44f891b5184f6490fc37f50c56be54fcceb0ac0228d16dd0ae1048af88e3f16f9baf03bbaaf34b99a6129, 0x2804fe9b7edc17906b46cefc8b02cfcee13cab816088d02035f9d30b63a2fc7cd92912880ad00ef0d89fca623974ab4bf60ea529a9681da052110a8ccd2cea21a07fab6b3f1fa073d576ea9910411a4d32941bf9698b818e87ea28f3f93a4c460b069e14d906b573d80cfde4c7f1352eaa624b8abadbab96ce5704fc42e5cf84, 1); ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionLevel",
                table: "Users");
        }
    }
}
