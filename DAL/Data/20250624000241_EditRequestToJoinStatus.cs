using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Data
{
    /// <inheritdoc />
    public partial class EditRequestToJoinStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DoctorJoinRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DoctorJoinRequests");
        }
    }
}
