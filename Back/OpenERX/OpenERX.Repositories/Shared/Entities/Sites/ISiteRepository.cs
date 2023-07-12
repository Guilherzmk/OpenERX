using OpenERX.Commons.Types.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Sites
{
    public interface ISiteRepository
    {
        Task<Site> InsertSiteAsync(Guid parentId, Site site);
        Task<Guid> DeleteSiteAsync(Guid parentId);
        Task<IList<Site>> GetAllSitesAsync(Guid parentId);
    }
}
