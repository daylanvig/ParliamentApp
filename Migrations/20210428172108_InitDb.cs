using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParliamentApp.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParliamentPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParliamentNumber = table.Column<int>(type: "int", nullable: false),
                    SessionNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParliamentPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembersOfParliament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParliamentPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonShortHonorific = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonOfficialFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonOfficialLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstituencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstituencyProvinceTerritoryName = table.Column<int>(type: "int", nullable: false),
                    CaucusShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParliamentPeriodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersOfParliament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersOfParliament_ParliamentPeriods_ParliamentPeriodId",
                        column: x => x.ParliamentPeriodId,
                        principalTable: "ParliamentPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParliamentPeriodId = table.Column<int>(type: "int", nullable: false),
                    BillNumberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionEventDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DecisionDivisionNumber = table.Column<int>(type: "int", nullable: false),
                    DecisionDivisionSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionResultName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionDivisionNumberOfYeas = table.Column<int>(type: "int", nullable: false),
                    DecisionDivisionNumberOfNays = table.Column<int>(type: "int", nullable: false),
                    DecisionDivisionNumberOfPaired = table.Column<int>(type: "int", nullable: false),
                    DecisionDivisionDocumentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionDivisionDocumentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_ParliamentPeriods_ParliamentPeriodId",
                        column: x => x.ParliamentPeriodId,
                        principalTable: "ParliamentPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    DecisionEventDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DecisionDivisionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstituencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteValueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstituencyProvinceTerritoryName = table.Column<int>(type: "int", nullable: false),
                    CaucusShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteDecision = table.Column<int>(type: "int", nullable: false),
                    DecisionResultName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberVotes_Votes_VoteId",
                        column: x => x.VoteId,
                        principalTable: "Votes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParliamentPeriods",
                columns: new[] { "Id", "EndDate", "ParliamentNumber", "SessionNumber", "StartDate" },
                values: new object[] { 1, null, 43, 2, new DateTimeOffset(new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ParliamentPeriods",
                columns: new[] { "Id", "EndDate", "ParliamentNumber", "SessionNumber", "StartDate" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 43, 1, new DateTimeOffset(new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_MembersOfParliament_ParliamentPeriodId",
                table: "MembersOfParliament",
                column: "ParliamentPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberVotes_VoteId",
                table: "MemberVotes",
                column: "VoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ParliamentPeriods_ParliamentNumber_SessionNumber",
                table: "ParliamentPeriods",
                columns: new[] { "ParliamentNumber", "SessionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ParliamentPeriodId",
                table: "Votes",
                column: "ParliamentPeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembersOfParliament");

            migrationBuilder.DropTable(
                name: "MemberVotes");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "ParliamentPeriods");
        }
    }
}
