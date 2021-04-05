using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventData.Migrations
{
    public partial class Initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateHappens = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGuestsCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypeVariants",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeVariants", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivedEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateArchived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivedEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    EventTypeVariantEventTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeId);
                    table.ForeignKey(
                        name: "FK_EventType_EventTypeVariants_EventTypeVariantEventTypeId",
                        column: x => x.EventTypeVariantEventTypeId,
                        principalTable: "EventTypeVariants",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventGuest",
                columns: table => new
                {
                    ListOfEventsId = table.Column<int>(type: "int", nullable: false),
                    ListOfGuestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuest", x => new { x.ListOfEventsId, x.ListOfGuestsId });
                    table.ForeignKey(
                        name: "FK_EventGuest_Events_ListOfEventsId",
                        column: x => x.ListOfEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuest_Guests_ListOfGuestsId",
                        column: x => x.ListOfGuestsId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventTypeVariants",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[] { 0, "Conference" });

            migrationBuilder.InsertData(
                table: "EventTypeVariants",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[] { 1, "Seminar" });

            migrationBuilder.InsertData(
                table: "EventTypeVariants",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[] { 2, "Hackathon" });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedEvents_EventId",
                table: "ArchivedEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuest_ListOfGuestsId",
                table: "EventGuest",
                column: "ListOfGuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventType_EventTypeVariantEventTypeId",
                table: "EventType",
                column: "EventTypeVariantEventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivedEvents");

            migrationBuilder.DropTable(
                name: "EventGuest");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "EventTypeVariants");
        }
    }
}
