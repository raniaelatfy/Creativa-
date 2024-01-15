using Microsoft.EntityFrameworkCore.Migrations;

namespace Creativa.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeLances_Branches_BranchId",
                table: "FreeLances");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeLances_User_Id",
                table: "FreeLances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeLances",
                table: "FreeLances");

            migrationBuilder.RenameTable(
                name: "FreeLances",
                newName: "FreeLance");

            migrationBuilder.RenameIndex(
                name: "IX_FreeLances_BranchId",
                table: "FreeLance",
                newName: "IX_FreeLance_BranchId");

            migrationBuilder.AddColumn<string>(
                name: "LinkProfile",
                table: "FreeLance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FreeLance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tech_used",
                table: "FreeLance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type_project",
                table: "FreeLance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "duration",
                table: "FreeLance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "personality_ID",
                table: "FreeLance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "FreeLance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeLance",
                table: "FreeLance",
                columns: new[] { "Id", "BranchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FreeLance_Branches_BranchId",
                table: "FreeLance",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeLance_User_Id",
                table: "FreeLance",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeLance_Branches_BranchId",
                table: "FreeLance");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeLance_User_Id",
                table: "FreeLance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeLance",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "LinkProfile",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "Tech_used",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "Type_project",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "personality_ID",
                table: "FreeLance");

            migrationBuilder.DropColumn(
                name: "status",
                table: "FreeLance");

            migrationBuilder.RenameTable(
                name: "FreeLance",
                newName: "FreeLances");

            migrationBuilder.RenameIndex(
                name: "IX_FreeLance_BranchId",
                table: "FreeLances",
                newName: "IX_FreeLances_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeLances",
                table: "FreeLances",
                columns: new[] { "Id", "BranchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FreeLances_Branches_BranchId",
                table: "FreeLances",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeLances_User_Id",
                table: "FreeLances",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
