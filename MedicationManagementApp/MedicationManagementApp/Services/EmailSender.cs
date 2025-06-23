namespace MedicationManagementApp.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmail(string email, string title, string message)
        {
            Console.WriteLine($"Sending email to {email} with title {title} and message {message}");
            await Task.Delay(3000);
            Console.WriteLine($"Email sent to {email}");
        }
    }
}
