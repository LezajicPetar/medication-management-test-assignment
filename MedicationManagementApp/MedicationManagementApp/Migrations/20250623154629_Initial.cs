using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicationManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientEmail = table.Column<string>(type: "text", nullable: false),
                    DoctorName = table.Column<string>(type: "text", nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: false),
                    MedicationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationRequests_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Description", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "Pain relief", "Paracetamol", 100 },
                    { 2, "Anti-inflammatory", "Ibuprofen", 50 },
                    { 3, "Antibiotic", "Amoxicillin", 80 },
                    { 4, "Sedative", "Diazepam", 30 },
                    { 5, "Diabetes treatment", "Metformin", 120 }
                });

            migrationBuilder.InsertData(
                table: "MedicationRequests",
                columns: new[] { "Id", "Diagnosis", "DoctorName", "MedicationId", "PatientEmail", "PatientName", "Quantity", "RequestDate" },
                values: new object[,]
                {
                    { 1, "Headache", "Dr. Ilić", 1, "ana@example.com", "Ana Petrović", 10, new DateTime(2025, 6, 18, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(247) },
                    { 2, "Inflammation", "Dr. Kovač", 2, "marko@example.com", "Marko Jovanović", 5, new DateTime(2025, 6, 20, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(257) },
                    { 3, "Infection", "Dr. Janković", 3, "ivana@example.com", "Ivana Lukić", 15, new DateTime(2025, 6, 21, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(259) },
                    { 4, "Anxiety", "Dr. Petrović", 4, "nikola@example.com", "Nikola Nikolić", 2, new DateTime(2025, 6, 22, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(261) },
                    { 5, "Diabetes", "Dr. Ilić", 5, "milica@example.com", "Milica Savić", 7, new DateTime(2025, 6, 19, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(263) },
                    { 6, "Fever", "Dr. Nikolić", 1, "jovan@example.com", "Jovan Stević", 140, new DateTime(2025, 6, 21, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(265) },
                    { 7, "Pain", "Dr. Vuković", 2, "sara@example.com", "Sara Đorđević", 4, new DateTime(2025, 6, 22, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(267) },
                    { 8, "Diabetes", "Dr. Matić", 5, "luka@example.com", "Luka Milić", 155, new DateTime(2025, 6, 23, 15, 46, 29, 356, DateTimeKind.Utc).AddTicks(269) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRequests_MedicationId",
                table: "MedicationRequests",
                column: "MedicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationRequests");

            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}
