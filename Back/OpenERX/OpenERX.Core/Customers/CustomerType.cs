 
using OpenERX.Commons.Types.Generics;

namespace OpenERX.Core.Customers
{
    public class CustomerType : CodeName
    {
        public static CustomerType Type1 = new(1, "Type1");
        public static CustomerType Type2 = new(2, "Type2");
        public static CustomerType Type3 = new(3, "Type3");
        public static CustomerType Type4 = new(4, "Type4");
 
        public CustomerType(int code, string name) : base(code, name) { }
        public static IEnumerable<CustomerType> GetAll() => GetAll<CustomerType>();
        public static CustomerType Get(int code) => Get<CustomerType>(code);
    }
}
