namespace MedicationManagementApp.Models
{
    public class MedicationRequest
    {
        public int Id { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public string PatientEmail { get; set; } = string.Empty;

        public string DoctorName { get; set; } = string.Empty;

        public string Diagnosis { get; set; } = string.Empty;

        public int MedicationId { get; set; }

        public Medication? Medication { get; set; }
    }
}
