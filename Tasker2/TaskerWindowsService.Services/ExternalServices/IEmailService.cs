namespace TaskerWindowsService.Services.ExternalServices
{
    public interface IEmailService
    {
        bool Send(string email, bool isHtml, string subj, string text);
    }
}
