using Newtonsoft.Json;
using TaskerWindowsService.Common.Parameters;
using TaskerWindowsService.Services.ExternalServices;

namespace TaskerWindowsService.Services.ProcessServices
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IEmailService _emailService;

        public SendEmailService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool Process(string processParams)
        {
            if (!string.IsNullOrEmpty(processParams))
            {
                var emailParams = JsonConvert.DeserializeObject<SendEmailParams>(processParams);
                if (emailParams == null) return false;

                _emailService.Send(emailParams.EmailRecipient, false, emailParams.EmailSubject, emailParams.EmailText);
            }

            return true;
        }
    }
}
