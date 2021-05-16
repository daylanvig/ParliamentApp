using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParliamentApp.Migrations
{
    public partial class RemoveDuplicateValuesMemberVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaucusShortName",
                table: "MemberVotes");

            migrationBuilder.DropColumn(
                name: "ConstituencyName",
                table: "MemberVotes");

            migrationBuilder.DropColumn(
                name: "ConstituencyProvinceTerritoryName",
                table: "MemberVotes");

            migrationBuilder.DropColumn(
                name: "DecisionDivisionNumber",
                table: "MemberVotes");

            migrationBuilder.DropColumn(
                name: "DecisionEventDateTime",
                table: "MemberVotes");

            migrationBuilder.DropColumn(
                name: "DecisionResultName",
                table: "MemberVotes");

            migrationBuilder.RenameColumn(
                name: "VoteDecision",
                table: "MemberVotes",
                newName: "MemberOfParliamentId");

            migrationBuilder.AlterColumn<int>(
                name: "VoteValueName",
                table: "MemberVotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ToDateTime",
                table: "MembersOfParliament",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "FromDateTime",
                table: "MembersOfParliament",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_MemberVotes_MemberOfParliamentId",
                table: "MemberVotes",
                column: "MemberOfParliamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberVotes_MembersOfParliament_MemberOfParliamentId",
                table: "MemberVotes",
                column: "MemberOfParliamentId",
                principalTable: "MembersOfParliament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberVotes_MembersOfParliament_MemberOfParliamentId",
                table: "MemberVotes");

            migrationBuilder.DropIndex(
                name: "IX_MemberVotes_MemberOfParliamentId",
                table: "MemberVotes");

            migrationBuilder.RenameColumn(
                name: "MemberOfParliamentId",
                table: "MemberVotes",
                newName: "VoteDecision");

            migrationBuilder.AlterColumn<string>(
                name: "VoteValueName",
                table: "MemberVotes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CaucusShortName",
                table: "MemberVotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstituencyName",
                table: "MemberVotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConstituencyProvinceTerritoryName",
                table: "MemberVotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DecisionDivisionNumber",
                table: "MemberVotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DecisionEventDateTime",
                table: "MemberVotes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "DecisionResultName",
                table: "MemberVotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDateTime",
                table: "MembersOfParliament",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDateTime",
                table: "MembersOfParliament",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
