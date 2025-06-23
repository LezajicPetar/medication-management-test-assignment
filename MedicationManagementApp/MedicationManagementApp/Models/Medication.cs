namespace MedicationManagementApp.Models
{
    public class Medication
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}
