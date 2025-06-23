using MedicationManagementApp.DTOs;

namespace MedicationManagementApp.Services
{
    public interface IMedicationRequestService
    {
        Task<MedicationRequestResultDTO> ProcessMedicationRequest(int id);
    }
}
