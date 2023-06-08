using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Magicbrics.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationObject",
                columns: table => new
                {
                    AppObjid = table.Column<int>(type: "int", nullable: false),
                    ObjectName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appobjID", x => x.AppObjid);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    shortname = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    phonecode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationObjectType",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    AppObjid = table.Column<int>(type: "int", nullable: true),
                    TypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeID", x => x.TypeID);
                    table.ForeignKey(
                        name: "fk_appobjID",
                        column: x => x.AppObjid,
                        principalTable: "ApplicationObject",
                        principalColumn: "AppObjid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.StateID);
                    table.ForeignKey(
                        name: "fk_country",
                        column: x => x.CountryID,
                        principalTable: "countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(254)", unicode: false, maxLength: 254, nullable: true),
                    Date_Reg = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    PhoneNo = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    UserTypeID = table.Column<int>(type: "int", nullable: true),
                    OTPNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "fk_userTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityID);
                    table.ForeignKey(
                        name: "fk_city",
                        column: x => x.StateID,
                        principalTable: "states",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    PropertyTypeID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PropertyDescription = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    DepositeAmount = table.Column<decimal>(type: "money", nullable: true),
                    BRS_ID = table.Column<int>(type: "int", nullable: true),
                    Facing_ID = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Bedroom = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyID);
                    table.ForeignKey(
                        name: "fk_Facing",
                        column: x => x.Facing_ID,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_PropObjTID",
                        column: x => x.BRS_ID,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_PropType",
                        column: x => x.PropertyTypeID,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_userProp",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactOwner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNo = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    OTPNo = table.Column<int>(type: "int", nullable: true),
                    PrpertyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactOwner", x => x.ID);
                    table.ForeignKey(
                        name: "fk_PropContID",
                        column: x => x.PrpertyID,
                        principalTable: "Property",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "fk_PropImg",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                    table.ForeignKey(
                        name: "fk_PropLoc",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFacility",
                columns: table => new
                {
                    FacilityID = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: true),
                    Food = table.Column<bool>(type: "bit", nullable: true),
                    AC = table.Column<bool>(type: "bit", nullable: true),
                    WIFI = table.Column<bool>(type: "bit", nullable: true),
                    Sunday_Meal = table.Column<bool>(type: "bit", nullable: true),
                    Laundry = table.Column<bool>(type: "bit", nullable: true),
                    ElectricCharge = table.Column<bool>(type: "bit", nullable: true),
                    PowerBackup = table.Column<bool>(type: "bit", nullable: true),
                    Lift = table.Column<bool>(type: "bit", nullable: true),
                    NoticePeriodMonth = table.Column<int>(type: "int", nullable: true),
                    Sharing_ID = table.Column<int>(type: "int", nullable: true),
                    BGC_ID = table.Column<int>(type: "int", nullable: true),
                    Preferred_Tenants = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Propfaci", x => x.FacilityID);
                    table.ForeignKey(
                        name: "fk_bgc",
                        column: x => x.BGC_ID,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_PropID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Shar",
                        column: x => x.Sharing_ID,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tenant",
                        column: x => x.Preferred_Tenants,
                        principalTable: "ApplicationObjectType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationObjectType_AppObjid",
                table: "ApplicationObjectType",
                column: "AppObjid");

            migrationBuilder.CreateIndex(
                name: "IX_cities_StateID",
                table: "cities",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactOwner_PrpertyID",
                table: "ContactOwner",
                column: "PrpertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PropertyID",
                table: "Image",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_PropertyID",
                table: "Location",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_BRS_ID",
                table: "Property",
                column: "BRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Facing_ID",
                table: "Property",
                column: "Facing_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyTypeID",
                table: "Property",
                column: "PropertyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_UserID",
                table: "Property",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacility_BGC_ID",
                table: "PropertyFacility",
                column: "BGC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacility_Preferred_Tenants",
                table: "PropertyFacility",
                column: "Preferred_Tenants");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacility_PropertyID",
                table: "PropertyFacility",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacility_Sharing_ID",
                table: "PropertyFacility",
                column: "Sharing_ID");

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryID",
                table: "states",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "ContactOwner");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "PropertyFacility");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ApplicationObjectType");

            migrationBuilder.DropTable(
                name: "ApplicationObject");
        }
    }
}
