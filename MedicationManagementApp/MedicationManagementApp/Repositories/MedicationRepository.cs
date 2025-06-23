using MedicationManagementApp.Models;

namespace MedicationManagementApp.Repositories
{
    public class MedicationRepository : GenericRepository<Medication>, IMedicationRepository
    {
        public MedicationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
