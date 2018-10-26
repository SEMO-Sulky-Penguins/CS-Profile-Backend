using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSProfile.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CollegeStatus = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true),
                    Organizations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileItems");
        }
    }
}
