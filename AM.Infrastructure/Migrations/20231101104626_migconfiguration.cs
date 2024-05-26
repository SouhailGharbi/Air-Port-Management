using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_ListFlightFlightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_passengers_ListPassengerPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_Planefk",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "MyPlane");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "MyReservations");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlane",
                newName: "PlaneCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_ListPassengerPassportNumber",
                table: "MyReservations",
                newName: "IX_MyReservations_ListPassengerPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlane",
                table: "MyPlane",
                column: "PlaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyReservations",
                table: "MyReservations",
                columns: new[] { "ListFlightFlightId", "ListPassengerPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlane_Planefk",
                table: "Flights",
                column: "Planefk",
                principalTable: "MyPlane",
                principalColumn: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyReservations_Flights_ListFlightFlightId",
                table: "MyReservations",
                column: "ListFlightFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyReservations_passengers_ListPassengerPassportNumber",
                table: "MyReservations",
                column: "ListPassengerPassportNumber",
                principalTable: "passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlane_Planefk",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_MyReservations_Flights_ListFlightFlightId",
                table: "MyReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_MyReservations_passengers_ListPassengerPassportNumber",
                table: "MyReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyReservations",
                table: "MyReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlane",
                table: "MyPlane");

            migrationBuilder.RenameTable(
                name: "MyReservations",
                newName: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "MyPlane",
                newName: "Planes");

            migrationBuilder.RenameIndex(
                name: "IX_MyReservations_ListPassengerPassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_ListPassengerPassportNumber");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "ListFlightFlightId", "ListPassengerPassportNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_ListFlightFlightId",
                table: "FlightPassenger",
                column: "ListFlightFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_passengers_ListPassengerPassportNumber",
                table: "FlightPassenger",
                column: "ListPassengerPassportNumber",
                principalTable: "passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_Planefk",
                table: "Flights",
                column: "Planefk",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
