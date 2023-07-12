using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles.ProfileAuths
{
    public class ProfileAuth
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public ProfileAuth()
        {
            Id = Guid.NewGuid();
        }
    }
}
