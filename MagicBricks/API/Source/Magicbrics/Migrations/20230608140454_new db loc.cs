using Microsoft.EntityFrameworkCore.Migrations;

namespace Magicbrics.Migrations
{
    public partial class newdbloc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_userProp",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Image",
                newName: "Imagename");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Image",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_User_UserID",
                table: "Property",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_User_UserID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "Imagename",
                table: "Image",
                newName: "ImageURL");

            migrationBuilder.AddForeignKey(
                name: "fk_userProp",
                table: "Property",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
