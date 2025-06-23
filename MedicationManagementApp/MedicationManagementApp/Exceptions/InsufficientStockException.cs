namespace MedicationManagementApp.Exceptions
{
    public class InsufficientStockException : BadRequestException
    {
        public InsufficientStockException(string medicationName) :
            base($"Insufficient quantity of medication {medicationName} in stock.")
        {
        }
    }
}
