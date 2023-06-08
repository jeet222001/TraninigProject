using Microsoft.EntityFrameworkCore.Migrations;

namespace Magicbrics.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Facing",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_Facing_ID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Bedroom",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "DepositeAmount",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Facing_ID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Property");

            migrationBuilder.AlterColumn<string>(
                name: "OTPNo",
                table: "User",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(128)",
                unicode: false,
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityID",
                table: "PropertyFacility",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AgeOfConstruction",
                table: "PropertyFacility",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvailableFrom",
                table: "PropertyFacility",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Balconies",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bedrooms",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarpetArea",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorNo",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FurnishedStatus",
                table: "PropertyFacility",
                type: "varchar(25)",
                unicode: false,
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PossessionStatus",
                table: "PropertyFacility",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PropertyFacility",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuperArea",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TokenAmount",
                table: "PropertyFacility",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalFloors",
                table: "PropertyFacility",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyID",
                table: "Property",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ImageID",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ImageTypeId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ContactOwner",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TypeID",
                table: "ApplicationObjectType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AppObjid",
                table: "ApplicationObject",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "ImgType_fk",
                table: "Image",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageTypeId",
                table: "Image",
                column: "ImageTypeId");

            migrationBuilder.AddForeignKey(
                name: "fk_imgType",
                table: "Image",
                column: "ImageTypeId",
                principalTable: "ApplicationObjectType",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_imgType",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "ImgType_fk",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageTypeId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AgeOfConstruction",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "AvailableFrom",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "Balconies",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "Bedrooms",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "CarpetArea",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "FloorNo",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "FurnishedStatus",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "PossessionStatus",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "SuperArea",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "TokenAmount",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "TotalFloors",
                table: "PropertyFacility");

            migrationBuilder.DropColumn(
                name: "ImageTypeId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "OTPNo",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldUnicode: false,
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityID",
                table: "PropertyFacility",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyID",
                table: "Property",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Bedroom",
                table: "Property",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DepositeAmount",
                table: "Property",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Facing_ID",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Property",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Property",
                type: "money",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ImageID",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ContactOwner",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TypeID",
                table: "ApplicationObjectType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AppObjid",
                table: "ApplicationObject",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Facing_ID",
                table: "Property",
                column: "Facing_ID");

            migrationBuilder.AddForeignKey(
                name: "fk_Facing",
                table: "Property",
                column: "Facing_ID",
                principalTable: "ApplicationObjectType",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
