using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Data
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorJoinRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    EducationalDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificatesAndCourses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationCertificatePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTermsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorJoinRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    ConsultationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrStudyPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalSpecialtyId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptSent = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationId);
                    table.ForeignKey(
                        name: "FK_Consultations_MedicalSpecialties_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialties",
                columns: table => new
                {
                    DoctorJoinRequestId = table.Column<int>(type: "int", nullable: false),
                    MedicalSpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialties", x => new { x.DoctorJoinRequestId, x.MedicalSpecialtyId });
                    table.ForeignKey(
                        name: "FK_DoctorSpecialties_DoctorJoinRequests_DoctorJoinRequestId",
                        column: x => x.DoctorJoinRequestId,
                        principalTable: "DoctorJoinRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialties_MedicalSpecialties_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedicalSpecialtyId",
                table: "Consultations",
                column: "MedicalSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialties_MedicalSpecialtyId",
                table: "DoctorSpecialties",
                column: "MedicalSpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "DoctorSpecialties");

            migrationBuilder.DropTable(
                name: "DoctorJoinRequests");

            migrationBuilder.DropTable(
                name: "MedicalSpecialties");
        }
    }
}
