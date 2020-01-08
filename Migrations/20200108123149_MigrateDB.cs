using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistration.Migrations
{
    public partial class MigrateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEventRegistrations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    UniversityGraduationDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateRegistraion = table.Column<long>(nullable: false),
                    StatusRegistration = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventRegistrations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventRegistrations");
        }
    }
}
