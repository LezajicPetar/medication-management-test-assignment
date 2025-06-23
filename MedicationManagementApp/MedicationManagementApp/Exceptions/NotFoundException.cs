namespace MedicationManagementApp.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string item,int id) : base($"{item} with id {id} could not be found.")
        {
        }
    }
}
