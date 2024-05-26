using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migTicketConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyReservations");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Flight_fk = table.Column<int>(type: "int", nullable: false),
                    Passenger_fk = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<int>(type: "int", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.Passenger_fk, x.Flight_fk });
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_Flight_fk",
                        column: x => x.Flight_fk,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_passengers_Passenger_fk",
                        column: x => x.Passenger_fk,
                        principalTable: "passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Flight_fk",
                table: "Ticket",
                column: "Flight_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.CreateTable(
                name: "MyReservations",
                columns: table => new
                {
                    ListFlightFlightId = table.Column<int>(type: "int", nullable: false),
                    ListPassengerPassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyReservations", x => new { x.ListFlightFlightId, x.ListPassengerPassportNumber });
                    table.ForeignKey(
                        name: "FK_MyReservations_Flights_ListFlightFlightId",
                        column: x => x.ListFlightFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyReservations_passengers_ListPassengerPassportNumber",
                        column: x => x.ListPassengerPassportNumber,
                        principalTable: "passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyReservations_ListPassengerPassportNumber",
                table: "MyReservations",
                column: "ListPassengerPassportNumber");
        }
    }
}
