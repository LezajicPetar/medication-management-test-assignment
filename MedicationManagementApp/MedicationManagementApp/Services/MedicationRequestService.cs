using MedicationManagementApp.DTOs;
using MedicationManagementApp.Exceptions;
using MedicationManagementApp.Repositories;

namespace MedicationManagementApp.Services
{
    public class MedicationRequestService : IMedicationRequestService
    {
        private readonly IMedicationRequestRepository _medicationRequestRepository;
        private readonly IEmailSender _emailSender;

        public MedicationRequestService(
            IMedicationRequestRepository medicationRequestRepository,
            IEmailSender emailSender
            )
        {
            _medicationRequestRepository = medicationRequestRepository;
            _emailSender = emailSender;
        }

        public async Task<MedicationRequestResultDTO> ProcessMedicationRequest(int id)
        {
            var medicationRequest = await _medicationRequestRepository.GetOne(id);
            if (medicationRequest == null)
            {
                throw new MedicationRequestNotFoundException(id);
            }

            var medication = medicationRequest.Medication;

            if (medication.Quantity <= 0)
            {
                throw new OutOfStockException(medication.Name);
            }

            if (medication.Quantity < medicationRequest.Quantity)
            {
                throw new InsufficientStockException(medication.Name);
            }

            await _emailSender.SendEmail(
                medicationRequest.PatientEmail,
                "New Medication Request",
                $"Patient {medicationRequest.PatientName} requested {medicationRequest.Quantity} of medication {medication.Name}."
            );

            return new MedicationRequestResultDTO
            {
                MedicationName = medication.Name,
                Message = "Medication request is successfully processed."
            };
        }
    }
}
