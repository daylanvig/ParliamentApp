using Microsoft.EntityFrameworkCore.Migrations;

namespace ParliamentApp.Migrations
{
    public partial class RenameVoteValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VoteValueName",
                table: "MemberVotes",
                newName: "VoteValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VoteValue",
                table: "MemberVotes",
                newName: "VoteValueName");
        }
    }
}
