using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversitySharedDatabase.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false),
                        /*.Annotation("SqlServer:Identity", "1, 1"),*/
                    ClubName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Eligibility = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "DesignationCouncils",
                columns: table => new
                {
                    DesgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationCouncils", x => x.DesgId);
                });

            migrationBuilder.CreateTable(
                name: "Grievances",
                columns: table => new
                {
                    GrievanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grievances", x => x.GrievanceId);
                });

            /*migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    QuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.QuId);
                });*/

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VolunteerCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    ShareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    EventOrIdea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.ShareId);
                });

            migrationBuilder.CreateTable(
                name: "StatusFeilds",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFeilds", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    TotalAttendedStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                        /*.Annotation("SqlServer:Identity", "1, 1"),*/
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                   /* QuId = table.Column<int>(type: "int", nullable: false),
                    SecurityAns = table.Column<string>(type: "nvarchar(max)", nullable: false)*/
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    /*table.ForeignKey(
                        name: "FK_Users_SecurityQuestions_QuId",
                        column: x => x.QuId,
                        principalTable: "SecurityQuestions",
                        principalColumn: "QuId",
                        onDelete: ReferentialAction.Cascade);*/
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    IdeaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    IdeaTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaId);
                    table.ForeignKey(
                        name: "FK_Ideas_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ideas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClubs",
                columns: table => new
                {
                    UserClubRegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DesgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClubs", x => x.UserClubRegId);
                    table.ForeignKey(
                        name: "FK_UserClubs_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClubs_DesignationCouncils_DesgId",
                        column: x => x.DesgId,
                        principalTable: "DesignationCouncils",
                        principalColumn: "DesgId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClubs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    UserEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Attendence = table.Column<bool>(type: "bit", nullable: false),
                    LikesOrDislike = table.Column<bool>(type: "bit", nullable: false),
                    Suggestion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => x.UserEventID);
                    table.ForeignKey(
                        name: "FK_UserEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGrievances",
                columns: table => new
                {
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrievanceId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrievances", x => x.ReferenceId);
                    table.ForeignKey(
                        name: "FK_UserGrievances_Grievances_GrievanceId",
                        column: x => x.GrievanceId,
                        principalTable: "Grievances",
                        principalColumn: "GrievanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrievances_StatusFeilds_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusFeilds",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrievances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserServices",
                columns: table => new
                {
                    RegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserServices", x => x.RegId);
                    table.ForeignKey(
                        name: "FK_UserServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserServices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserIdeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LikeStatus = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIdeas_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId"
                        );
                    table.ForeignKey(
                        name: "FK_UserIdeas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId"
                        );
                });

            migrationBuilder.InsertData(
                table: "DesignationCouncils",
                columns: new[] { "DesgId", "Designation" },
                values: new object[,]
                {
                    { 1, "NA" },
                    { 2, "President" },
                    { 3, "Vice-president" },
                    { 4, "Treasurer" },
                    { 5, "Executive member" },
                    { 6, "Associate co-ordinator" },
                    { 7, "Secretary " }
                });

            migrationBuilder.InsertData(
                table: "Grievances",
                columns: new[] { "GrievanceId", "Type" },
                values: new object[,]
                {
                    { 1, "Complaint" },
                    { 2, "Suggestion" },
                    { 3, "Technical Problem" }
                });

            /*migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "QuId", "Question" },
                values: new object[,]
                {
                    { 8, "Where was your best family vacation as a kid?" },
                    { 7, "Who was your childhood hero?" },
                    { 6, "When you were young, what did you want to be when you grew up?" },
                    { 5, "What is the name of the town where you were born?" },
                    { 1, "What is your mother's maiden name?" },
                    { 3, "What was your first car?" },
                    { 2, "What is the name of your first pet?" },
                    { 4, "What elementary school did you attend?" }
                });*/

            migrationBuilder.InsertData(
                table: "StatusFeilds",
                columns: new[] { "StatusId", "Status" },
                values: new object[,]
                {
                    { 2, "InProgress" },
                    { 1, "Pending /Open" },
                    { 3, "Closed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClubId",
                table: "Events",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ClubId",
                table: "Ideas",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_UserId",
                table: "Ideas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClubs_ClubId",
                table: "UserClubs",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClubs_DesgId",
                table: "UserClubs",
                column: "DesgId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClubs_UserId",
                table: "UserClubs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_UserId",
                table: "UserEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrievances_GrievanceId",
                table: "UserGrievances",
                column: "GrievanceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrievances_StatusId",
                table: "UserGrievances",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrievances_UserId",
                table: "UserGrievances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIdeas_IdeaId",
                table: "UserIdeas",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIdeas_UserId",
                table: "UserIdeas",
                column: "UserId");

            /*migrationBuilder.CreateIndex(
                name: "IX_Users_QuId",
                table: "Users",
                column: "QuId");*/

            migrationBuilder.CreateIndex(
                name: "IX_UserServices_ServiceId",
                table: "UserServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServices_UserId",
                table: "UserServices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "UserClubs");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "UserGrievances");

            migrationBuilder.DropTable(
                name: "UserIdeas");

            migrationBuilder.DropTable(
                name: "UserServices");

            migrationBuilder.DropTable(
                name: "DesignationCouncils");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Grievances");

            migrationBuilder.DropTable(
                name: "StatusFeilds");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Users");

           /* migrationBuilder.DropTable(
                name: "SecurityQuestions");*/
        }
    }
}
