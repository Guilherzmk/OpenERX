using OpenERX.Commons.Types.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Emails
{
    public interface IEmailRepository
    {
        Task<Email> InsertEmailAsync(Guid parentId, Email email);
        Task<Guid> DeleteAddressAsync(Guid parentId);
        Task<IList<Email>> GetAllEmailsAsync(Guid parentId);
    }
}
