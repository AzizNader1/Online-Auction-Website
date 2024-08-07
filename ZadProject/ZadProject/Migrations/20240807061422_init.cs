using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "CarAuctions",
                columns: table => new
                {
                    CarAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModel = table.Column<int>(type: "int", nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    NOK = table.Column<int>(type: "int", nullable: false),
                    NumberOfOwner = table.Column<int>(type: "int", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    TechnicalInspection = table.Column<int>(type: "int", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    TransmisssionType = table.Column<int>(type: "int", nullable: false),
                    Colors = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    AccidentBefore = table.Column<int>(type: "int", nullable: false),
                    TireCondition = table.Column<int>(type: "int", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    MinimunSalePrice = table.Column<int>(type: "int", nullable: false),
                    AuctionImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionStatus = table.Column<int>(type: "int", nullable: false),
                    AuctionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAuctions", x => x.CarAuctionId);
                });

            migrationBuilder.CreateTable(
                name: "OtherAuctions",
                columns: table => new
                {
                    OtherAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionProdutName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionStartPrice = table.Column<double>(type: "float", nullable: false),
                    MinimunSalePrice = table.Column<double>(type: "float", nullable: false),
                    AuctionCoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionDesctibtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionCategory = table.Column<int>(type: "int", nullable: false),
                    AuctionStatus = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherAuctions", x => x.OtherAuctionId);
                });

            migrationBuilder.CreateTable(
                name: "RealStateAuctions",
                columns: table => new
                {
                    RealStateAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseSize = table.Column<int>(type: "int", nullable: false),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    YearOfBuild = table.Column<int>(type: "int", nullable: false),
                    TypeOfProperty = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Parking = table.Column<int>(type: "int", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    MinimunSalePrice = table.Column<int>(type: "int", nullable: false),
                    AuctionImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionStatus = table.Column<int>(type: "int", nullable: false),
                    AuctionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfFloors = table.Column<int>(type: "int", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealStateAuctions", x => x.RealStateAuctionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BidingCarAuctions",
                columns: table => new
                {
                    BidingCarAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidingPrice = table.Column<double>(type: "float", nullable: false),
                    BidingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarAuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidingCarAuctions", x => x.BidingCarAuctionId);
                    table.ForeignKey(
                        name: "FK_BidingCarAuctions_CarAuctions_CarAuctionId",
                        column: x => x.CarAuctionId,
                        principalTable: "CarAuctions",
                        principalColumn: "CarAuctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidingCarAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidingOtherAuctions",
                columns: table => new
                {
                    BidingOtherAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidingPrice = table.Column<double>(type: "float", nullable: false),
                    BidingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OtherAuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidingOtherAuctions", x => x.BidingOtherAuctionId);
                    table.ForeignKey(
                        name: "FK_BidingOtherAuctions_OtherAuctions_OtherAuctionId",
                        column: x => x.OtherAuctionId,
                        principalTable: "OtherAuctions",
                        principalColumn: "OtherAuctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidingOtherAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "BidingRealStateAuctions",
                columns: table => new
                {
                    BidingRealStateAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidingPrice = table.Column<double>(type: "float", nullable: false),
                    BidingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RealStateAuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidingRealStateAuctions", x => x.BidingRealStateAuctionId);
                    table.ForeignKey(
                        name: "FK_BidingRealStateAuctions_RealStateAuctions_RealStateAuctionId",
                        column: x => x.RealStateAuctionId,
                        principalTable: "RealStateAuctions",
                        principalColumn: "RealStateAuctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidingRealStateAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyingCarAuctions",
                columns: table => new
                {
                    BuyingCarAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarAuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingCarAuctions", x => x.BuyingCarAuctionId);
                    table.ForeignKey(
                        name: "FK_BuyingCarAuctions_CarAuctions_CarAuctionId",
                        column: x => x.CarAuctionId,
                        principalTable: "CarAuctions",
                        principalColumn: "CarAuctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyingCarAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyingOtherAuctions",
                columns: table => new
                {
                    BuyingOtherAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherAuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingOtherAuctions", x => x.BuyingOtherAuctionId);
                    table.ForeignKey(
                        name: "FK_BuyingOtherAuctions_OtherAuctions_OtherAuctionId",
                        column: x => x.OtherAuctionId,
                        principalTable: "OtherAuctions",
                        principalColumn: "OtherAuctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyingOtherAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyingRealStateAuctions",
                columns: table => new
                {
                    BuyingRealStateAuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealStateAuctinoId = table.Column<int>(type: "int", nullable: false),
                    RealStateAuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingRealStateAuctions", x => x.BuyingRealStateAuctionId);
                    table.ForeignKey(
                        name: "FK_BuyingRealStateAuctions_RealStateAuctions_RealStateAuctionId",
                        column: x => x.RealStateAuctionId,
                        principalTable: "RealStateAuctions",
                        principalColumn: "RealStateAuctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyingRealStateAuctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvvNumber = table.Column<int>(type: "int", nullable: false),
                    AccountBalance = table.Column<double>(type: "float", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserAccountId);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidingCarAuctions_CarAuctionId",
                table: "BidingCarAuctions",
                column: "CarAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BidingCarAuctions_UserId",
                table: "BidingCarAuctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BidingOtherAuctions_OtherAuctionId",
                table: "BidingOtherAuctions",
                column: "OtherAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BidingOtherAuctions_UserId",
                table: "BidingOtherAuctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BidingOtherAuctions_UserId1",
                table: "BidingOtherAuctions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BidingRealStateAuctions_RealStateAuctionId",
                table: "BidingRealStateAuctions",
                column: "RealStateAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BidingRealStateAuctions_UserId",
                table: "BidingRealStateAuctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingCarAuctions_CarAuctionId",
                table: "BuyingCarAuctions",
                column: "CarAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingCarAuctions_UserId",
                table: "BuyingCarAuctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingOtherAuctions_OtherAuctionId",
                table: "BuyingOtherAuctions",
                column: "OtherAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingOtherAuctions_UserId",
                table: "BuyingOtherAuctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingRealStateAuctions_RealStateAuctionId",
                table: "BuyingRealStateAuctions",
                column: "RealStateAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingRealStateAuctions_UserId",
                table: "BuyingRealStateAuctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_BankId",
                table: "UserAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserId",
                table: "UserAccounts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidingCarAuctions");

            migrationBuilder.DropTable(
                name: "BidingOtherAuctions");

            migrationBuilder.DropTable(
                name: "BidingRealStateAuctions");

            migrationBuilder.DropTable(
                name: "BuyingCarAuctions");

            migrationBuilder.DropTable(
                name: "BuyingOtherAuctions");

            migrationBuilder.DropTable(
                name: "BuyingRealStateAuctions");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "CarAuctions");

            migrationBuilder.DropTable(
                name: "OtherAuctions");

            migrationBuilder.DropTable(
                name: "RealStateAuctions");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
