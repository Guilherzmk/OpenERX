using OpenERX.Commons.Types.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Fields
{
    public interface IFieldsRepository
    {
        Task<DataField> InsertFieldAsync(Guid parentId, DataField dataField);
        Task<Guid> DeleteFieldAsync(Guid parentId);
        Task<IList<DataField>> GetAllFieldsAsync(Guid parentId);


    }
}
