using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationERP.Migrations
{
    public partial class oi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    Representative = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Include_Transportation = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transaction_Detail",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    TicketNumber = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    DetailID = table.Column<int>(type: "int", nullable: true),
                    Gross = table.Column<int>(type: "int", nullable: true),
                    Tare = table.Column<int>(type: "int", nullable: true),
                    Net = table.Column<int>(type: "int", nullable: true),
                    UnitCost = table.Column<decimal>(type: "money", nullable: true),
                    TotalCost = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transaction_Header",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    TicketNumber = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    OrderNumber = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: true),
                    TicketDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentTerms = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SupplierTicket = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CarrierTicket = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TruckDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PaymentReceiptURL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transaction_OtherPictures",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    TicketNumber = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    PictureID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Thumbnail_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FullRes_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transaction_ReceivedPaperword",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    TicketNumber = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    PictureID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Thumbnail_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FullRes_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transaction_ScalePictures",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    TicketNumber = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    PictureID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Thumbnail_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FullRes_URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TransectionSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    CommodityID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransectionSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportation_Commodities",
                columns: table => new
                {
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Commodity_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transportation_Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "User_History",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: true),
                    EventDate = table.Column<DateTime>(type: "date", nullable: true),
                    IP = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    EventType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(320)", unicode: false, maxLength: 320, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "binary(64)", fixedLength: true, maxLength: 64, nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Password_Version = table.Column<int>(type: "int", nullable: true),
                    Account_Disabled = table.Column<bool>(type: "bit", nullable: true),
                    AccountID = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Transaction_Detail");

            migrationBuilder.DropTable(
                name: "Transaction_Header");

            migrationBuilder.DropTable(
                name: "Transaction_OtherPictures");

            migrationBuilder.DropTable(
                name: "Transaction_ReceivedPaperword");

            migrationBuilder.DropTable(
                name: "Transaction_ScalePictures");

            migrationBuilder.DropTable(
                name: "TransectionSetting");

            migrationBuilder.DropTable(
                name: "Transportation_Commodities");

            migrationBuilder.DropTable(
                name: "Transportation_Locations");

            migrationBuilder.DropTable(
                name: "User_History");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
