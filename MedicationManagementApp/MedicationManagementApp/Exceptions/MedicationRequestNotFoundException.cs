namespace MedicationManagementApp.Exceptions
{
    public class MedicationRequestNotFoundException : NotFoundException
    {
        public MedicationRequestNotFoundException(int id) :
            base("Medication request", id)
        {
        }
    }
}
