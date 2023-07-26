using GetTalim.Service.Dtos.Notifications;
namespace GetTalim.Service.Interfaces.Notifications;

public interface IMailSender
{
    public Task<bool> SendAsync(EmailMessage message);
}
