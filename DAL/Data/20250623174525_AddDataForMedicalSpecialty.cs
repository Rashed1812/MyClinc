using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Data
{
    /// <inheritdoc />
    public partial class AddDataForMedicalSpecialty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MedicalSpecialties",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibleToPatient",
                table: "MedicalSpecialties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentStatus",
                table: "Consultations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "MedicalSpecialties",
                columns: new[] { "Id", "Description", "IconClass", "IsVisibleToPatient", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "خطط غذائية متخصصة وعلاج اضطرابات التغذية", "🥗", true, "التغذية العلاجية", 30m },
                    { 2, "استشارات جراحية متقدمة وتقييم الحالات", "⚕️", true, "الجراحة العامة", 50m },
                    { 3, "علاج الاضطرابات النفسية والدعم النفسي", "🧠", true, "الطب النفسي", 40m },
                    { 4, null, "❤️", false, "أمراض القلب", null },
                    { 5, null, "🩺", false, "الأمراض الجلدية", null },
                    { 6, null, "👶", false, "طب الأطفال", null },
                    { 7, null, "🦴", false, "العظام", null },
                    { 8, null, "🧠", false, "الأعصاب", null },
                    { 9, null, "🏥", false, "تخصص آخر", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "IsVisibleToPatient",
                table: "MedicalSpecialties");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MedicalSpecialties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
