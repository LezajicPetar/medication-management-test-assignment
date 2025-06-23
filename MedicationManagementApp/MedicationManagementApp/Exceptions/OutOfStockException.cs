namespace MedicationManagementApp.Exceptions
{
    public class OutOfStockException : BadRequestException
    {
        public OutOfStockException(string medicationName) :
            base($"Out of stock of medication {medicationName}.")
        {
        }
    }
}
