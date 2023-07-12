using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Users
{
    public class UserParams
    {
        public string Name { get; set; }
        public string AccessKey { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public int ProfileCode { get; set; }
        public string ProfileName { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public string Avatar { get; set; }
        public string Note { get; set; }
        public Guid BrokerId { get; set; }
        public Guid AccountId { get; set; }
    }
}
