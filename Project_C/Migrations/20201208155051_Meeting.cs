using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_C.Migrations
{
    public partial class Meeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMeetings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SessionInfosession_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeetings", x => new { x.UserId, x.SessionInfosession_id });
                    table.ForeignKey(
                        name: "FK_UserMeetings_Session_SessionInfosession_id",
                        column: x => x.SessionInfosession_id,
                        principalTable: "Session",
                        principalColumn: "session_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeetings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeetings_SessionInfosession_id",
                table: "UserMeetings",
                column: "SessionInfosession_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMeetings");
        }
    }
}
