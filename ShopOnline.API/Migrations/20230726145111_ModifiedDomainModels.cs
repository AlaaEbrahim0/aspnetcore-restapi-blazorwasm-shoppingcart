using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.API.Migrations
{
    public partial class ModifiedDomainModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GovernorateId",
                table: "AspNetUsers",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Governorate_GovernorateId",
                table: "AspNetUsers",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Governorate_GovernorateId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GovernorateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "AspNetUsers");
        }
    }
}
