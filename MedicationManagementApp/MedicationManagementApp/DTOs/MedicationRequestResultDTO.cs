namespace MedicationManagementApp.DTOs
{
    public class MedicationRequestResultDTO
    {
        public string MedicationName { get; set; } = string.Empty;
        public required string Message { get; set; }
    }
}
