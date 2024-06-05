using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPets.Services.ExternalApis
{
    public interface IMailSenderApiService
    {
        Task<bool> SendMailAsync(string toemail, int quoteId, string ownerName, string dateAssgined, string hourAssigned);
    }
}