namespace MedicationManagementApp.Services
{
    public interface IEmailSender
    {
        Task SendEmail(string email, string title, string message);
    }
}
