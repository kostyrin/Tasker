using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskerWindowsService.Common.Parameters
{
    public class SendEmailParams
    {
        public string EmailRecipient { get; set; }
        public string EmailSubject { get; set; }
        public string EmailText { get; set; }
    }
}
