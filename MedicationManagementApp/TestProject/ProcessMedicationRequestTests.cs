using MedicationManagementApp.Exceptions;
using MedicationManagementApp.Models;
using MedicationManagementApp.Repositories;
using MedicationManagementApp.Services;
using Moq;
using Shouldly;

namespace TestProject
{
    public class ProcessMedicationRequestTests
    {
        private readonly Mock<IMedicationRequestRepository> _stubRepo;
        private readonly Mock<IEmailSender> _mockEmailSender;
        private readonly MedicationRequestService _service;
        

        public ProcessMedicationRequestTests()
        {
            _stubRepo = new Mock<IMedicationRequestRepository>();
            _mockEmailSender = new Mock<IEmailSender>();
            _service = new MedicationRequestService(_stubRepo.Object, _mockEmailSender.Object);
        }

        [Fact]
        public async Task ProcessMedicationReques_Should_Throw_NotFoundException_When_Request_Does_Not_Exist()
        {
            //Arrange
            _stubRepo.Setup(r => r.GetOne(1)).ReturnsAsync((MedicationRequest?)null);

            //Act + Assert
            await Should.ThrowAsync<MedicationRequestNotFoundException>(
                () => _service.ProcessMedicationRequest(1)
            );

            _mockEmailSender.Verify(m =>
                m.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Fact]
        public async Task ProcessMedicationRequest_Should_Return_Result_And_Send_Email_When_Successful()
        {
            //Arrange
            var request = CreateRequest(5, 2000);

            _stubRepo.Setup(r => r.GetOne(123)).ReturnsAsync(request);

            //Act
            var result = await _service.ProcessMedicationRequest(123);

            //Assert
            result.ShouldNotBeNull();
            result.MedicationName.ShouldBe($"{request.Medication.Name}");

            _mockEmailSender.Verify(
                e => e.SendEmail("pera@example.com", It.IsAny<string>(), It.IsAny<string>()),
                Times.Once
            );
        }

        [Fact]
        public async Task ProcessMedicationRequest_Should_Throw_OutOfStockException_When_No_Medication_Left()
        {
            //Arrange
            var request = CreateRequest(5, 0);

            _stubRepo.Setup(m => m.GetOne(1)).ReturnsAsync(request);


            //Act + Assert
            await Should.ThrowAsync<OutOfStockException>(() => _service.ProcessMedicationRequest(1));

            _mockEmailSender.Verify(m =>
                m.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never
            );
        }

        [Fact]
        public async Task ProcessMedicationRequest_Should_Throw_InsufficientStockException_When_Stock_Is_Lower_Then_Requested()
        {
            //Arrange
            var request = CreateRequest(5, 1);

            _stubRepo.Setup(m => m.GetOne(1)).ReturnsAsync(request);

            //Act + Assert
            await Should.ThrowAsync<InsufficientStockException>(
                () => _service.ProcessMedicationRequest(1)
            );

            _mockEmailSender.Verify(m =>
                m.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never
            );
        }

        private MedicationRequest CreateRequest(int medicationQuantity, int stock)
        {
            return new MedicationRequest
            {
                Id = 1,
                Quantity = medicationQuantity,
                PatientName = "Pera Perić",
                PatientEmail = "pera@example.com",
                Medication = new Medication { Name = "Ksalol", Quantity = stock }
            };
        }
    }
}