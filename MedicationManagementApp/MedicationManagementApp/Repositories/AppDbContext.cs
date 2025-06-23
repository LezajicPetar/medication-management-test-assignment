using MedicationManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MedicationManagementApp.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Medication> Medications => Set<Medication>();
        public DbSet<MedicationRequest> MedicationRequests => Set<MedicationRequest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medication>().HasData(
                new Medication { Id = 1, Name = "Paracetamol", Description = "Pain relief", Quantity = 100 },
                new Medication { Id = 2, Name = "Ibuprofen", Description = "Anti-inflammatory", Quantity = 50 },
                new Medication { Id = 3, Name = "Amoxicillin", Description = "Antibiotic", Quantity = 80 },
                new Medication { Id = 4, Name = "Diazepam", Description = "Sedative", Quantity = 30 },
                new Medication { Id = 5, Name = "Metformin", Description = "Diabetes treatment", Quantity = 120 }
            );

            modelBuilder.Entity<MedicationRequest>().HasData(
                new MedicationRequest
                {
                    Id = 1,
                    PatientName = "Ana Petrović",
                    Quantity = 10,
                    RequestDate = DateTime.UtcNow.AddDays(-5),
                    PatientEmail = "ana@example.com",
                    DoctorName = "Dr. Ilić",
                    Diagnosis = "Headache",
                    MedicationId = 1
                },
                new MedicationRequest
                {
                    Id = 2,
                    PatientName = "Marko Jovanović",
                    Quantity = 5,
                    RequestDate = DateTime.UtcNow.AddDays(-3),
                    PatientEmail = "marko@example.com",
                    DoctorName = "Dr. Kovač",
                    Diagnosis = "Inflammation",
                    MedicationId = 2
                },
                new MedicationRequest
                {
                    Id = 3,
                    PatientName = "Ivana Lukić",
                    Quantity = 15,
                    RequestDate = DateTime.UtcNow.AddDays(-2),
                    PatientEmail = "ivana@example.com",
                    DoctorName = "Dr. Janković",
                    Diagnosis = "Infection",
                    MedicationId = 3
                },
                new MedicationRequest
                {
                    Id = 4,
                    PatientName = "Nikola Nikolić",
                    Quantity = 2,
                    RequestDate = DateTime.UtcNow.AddDays(-1),
                    PatientEmail = "nikola@example.com",
                    DoctorName = "Dr. Petrović",
                    Diagnosis = "Anxiety",
                    MedicationId = 4
                },
                new MedicationRequest
                {
                    Id = 5,
                    PatientName = "Milica Savić",
                    Quantity = 7,
                    RequestDate = DateTime.UtcNow.AddDays(-4),
                    PatientEmail = "milica@example.com",
                    DoctorName = "Dr. Ilić",
                    Diagnosis = "Diabetes",
                    MedicationId = 5
                },
                new MedicationRequest
                {
                    Id = 6,
                    PatientName = "Jovan Stević",
                    Quantity = 140,
                    RequestDate = DateTime.UtcNow.AddDays(-2),
                    PatientEmail = "jovan@example.com",
                    DoctorName = "Dr. Nikolić",
                    Diagnosis = "Fever",
                    MedicationId = 1
                },
                new MedicationRequest
                {
                    Id = 7,
                    PatientName = "Sara Đorđević",
                    Quantity = 4,
                    RequestDate = DateTime.UtcNow.AddDays(-1),
                    PatientEmail = "sara@example.com",
                    DoctorName = "Dr. Vuković",
                    Diagnosis = "Pain",
                    MedicationId = 2
                },
                new MedicationRequest
                {
                    Id = 8,
                    PatientName = "Luka Milić",
                    Quantity = 155,
                    RequestDate = DateTime.UtcNow,
                    PatientEmail = "luka@example.com",
                    DoctorName = "Dr. Matić",
                    Diagnosis = "Diabetes",
                    MedicationId = 5
                }
            );
        }
    }

}
