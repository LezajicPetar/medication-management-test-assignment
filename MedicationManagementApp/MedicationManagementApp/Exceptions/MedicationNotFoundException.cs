namespace MedicationManagementApp.Exceptions
{
    public class MedicationNotFoundException : NotFoundException
    {
        public MedicationNotFoundException(int id) :
            base("Medication", id)
        {
        }
    }
}
