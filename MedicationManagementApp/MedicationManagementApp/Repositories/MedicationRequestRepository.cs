using MedicationManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationManagementApp.Repositories
{
    public class MedicationRequestRepository : GenericRepository<MedicationRequest>, IMedicationRequestRepository
    {
        public MedicationRequestRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<MedicationRequest?> GetOne(int id)
        {
            return await _dbContext.MedicationRequests
                .Include(a => a.Medication)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
