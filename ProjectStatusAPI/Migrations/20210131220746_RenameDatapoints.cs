using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStatusAPI.Migrations
{
    public partial class RenameDatapoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datapoints_Projects_ProjectId",
                table: "Datapoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Datapoints",
                table: "Datapoints");

            migrationBuilder.DropIndex(
                name: "IX_Datapoints_ProjectId",
                table: "Datapoints");

            migrationBuilder.RenameTable(
                name: "Datapoints",
                newName: "DataPoints");

            migrationBuilder.AddColumn<int>(
                name: "ProjectDtoId",
                table: "DataPoints",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataPoints",
                table: "DataPoints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_ProjectDtoId",
                table: "DataPoints",
                column: "ProjectDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataPoints_Projects_ProjectDtoId",
                table: "DataPoints",
                column: "ProjectDtoId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataPoints_Projects_ProjectDtoId",
                table: "DataPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataPoints",
                table: "DataPoints");

            migrationBuilder.DropIndex(
                name: "IX_DataPoints_ProjectDtoId",
                table: "DataPoints");

            migrationBuilder.DropColumn(
                name: "ProjectDtoId",
                table: "DataPoints");

            migrationBuilder.RenameTable(
                name: "DataPoints",
                newName: "Datapoints");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datapoints",
                table: "Datapoints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Datapoints_ProjectId",
                table: "Datapoints",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datapoints_Projects_ProjectId",
                table: "Datapoints",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
