using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sumera_Travel_Corporation.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MasterData");

            migrationBuilder.CreateTable(
                name: "Amenity",
                schema: "MasterData",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenitiesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmenitiesDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.AmenitiesId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "MasterData",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "MasterData",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "MasterData",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryRefId",
                        column: x => x.CountryRefId,
                        principalSchema: "MasterData",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "MasterData",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryRefId",
                        column: x => x.CountryRefId,
                        principalSchema: "MasterData",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                schema: "MasterData",
                columns: table => new
                {
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<long>(type: "bigint", nullable: false),
                    Telephone2 = table.Column<long>(type: "bigint", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.AirlineId);
                    table.ForeignKey(
                        name: "FK_Airline_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                schema: "MasterData",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AirportCode = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<long>(type: "bigint", nullable: false),
                    Telephone2 = table.Column<long>(type: "bigint", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_Airport_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "MasterData",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<long>(type: "bigint", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "MasterData",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HotelAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelRent = table.Column<int>(type: "int", nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "MasterData",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<long>(type: "bigint", nullable: false),
                    Telephone2 = table.Column<long>(type: "bigint", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirlineRefId = table.Column<int>(type: "int", nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: false),
                    FromAirportRefId = table.Column<int>(type: "int", nullable: false),
                    ToAirportRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineRefId",
                        column: x => x.AirlineRefId,
                        principalSchema: "MasterData",
                        principalTable: "Airline",
                        principalColumn: "AirlineId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_FromAirportRefId",
                        column: x => x.FromAirportRefId,
                        principalSchema: "MasterData",
                        principalTable: "Airport",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_ToAirportRefId",
                        column: x => x.ToAirportRefId,
                        principalSchema: "MasterData",
                        principalTable: "Airport",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Flight_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HolidayPackage",
                schema: "MasterData",
                columns: table => new
                {
                    HolidayPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_locationRefId = table.Column<int>(type: "int", nullable: true),
                    to_locationRefId = table.Column<int>(type: "int", nullable: false),
                    HolidayPackagePrice = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofGuest = table.Column<int>(type: "int", nullable: false),
                    HotelrefId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PackageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPackage", x => x.HolidayPackageId);
                    table.ForeignKey(
                        name: "FK_HolidayPackage_Hotel_HotelrefId",
                        column: x => x.HotelrefId,
                        principalSchema: "MasterData",
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HolidayPackage_Locations_from_locationRefId",
                        column: x => x.from_locationRefId,
                        principalSchema: "MasterData",
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_HolidayPackage_Locations_to_locationRefId",
                        column: x => x.to_locationRefId,
                        principalSchema: "MasterData",
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelAmenitiesLink",
                schema: "MasterData",
                columns: table => new
                {
                    HotelAmenitiesLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: false),
                    AmenitiesRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenitiesLink", x => x.HotelAmenitiesLinkId);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Amenity_AmenitiesRefId",
                        column: x => x.AmenitiesRefId,
                        principalSchema: "MasterData",
                        principalTable: "Amenity",
                        principalColumn: "AmenitiesId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "MasterData",
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HolidayBooking",
                schema: "MasterData",
                columns: table => new
                {
                    HolidayBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayPackageId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayBooking", x => x.HolidayBookingId);
                    table.ForeignKey(
                        name: "FK_HolidayBooking_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "MasterData",
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HolidayBooking_HolidayPackage_HolidayPackageId",
                        column: x => x.HolidayPackageId,
                        principalSchema: "MasterData",
                        principalTable: "HolidayPackage",
                        principalColumn: "HolidayPackageId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airline_CityRefId",
                schema: "MasterData",
                table: "Airline",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CityRefId",
                schema: "MasterData",
                table: "Airport",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryRefId",
                schema: "MasterData",
                table: "City",
                column: "CountryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityRefId",
                schema: "MasterData",
                table: "Customer",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineRefId",
                schema: "MasterData",
                table: "Flight",
                column: "AirlineRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CityRefId",
                schema: "MasterData",
                table: "Flight",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FromAirportRefId",
                schema: "MasterData",
                table: "Flight",
                column: "FromAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ToAirportRefId",
                schema: "MasterData",
                table: "Flight",
                column: "ToAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayBooking_CustomerId",
                schema: "MasterData",
                table: "HolidayBooking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayBooking_HolidayPackageId",
                schema: "MasterData",
                table: "HolidayBooking",
                column: "HolidayPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackage_from_locationRefId",
                schema: "MasterData",
                table: "HolidayPackage",
                column: "from_locationRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackage_HotelrefId",
                schema: "MasterData",
                table: "HolidayPackage",
                column: "HotelrefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackage_to_locationRefId",
                schema: "MasterData",
                table: "HolidayPackage",
                column: "to_locationRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityRefId",
                schema: "MasterData",
                table: "Hotel",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_AmenitiesRefId",
                schema: "MasterData",
                table: "HotelAmenitiesLink",
                column: "AmenitiesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_HotelRefId",
                schema: "MasterData",
                table: "HotelAmenitiesLink",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryRefId",
                schema: "MasterData",
                table: "State",
                column: "CountryRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "HolidayBooking",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "HotelAmenitiesLink",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "State",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Airline",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Airport",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "HolidayPackage",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Amenity",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "City",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "MasterData");
        }
    }
}
