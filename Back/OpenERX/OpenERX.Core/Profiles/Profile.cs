using OpenERX.Core.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles
{
    public class Profile
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public Profile() 
        {
        this.Id = Guid.NewGuid();
        }
    }
}
