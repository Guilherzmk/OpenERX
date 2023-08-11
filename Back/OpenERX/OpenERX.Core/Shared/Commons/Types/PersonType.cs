 
using OpenERX.Commons.Types.Generics;

namespace OpenERX.Core.Shared.Commons.Types
{
    public class PersonType : CodeName
    {
        public static PersonType NaturalPerson = new(1, "Pessoa Física");
        public static PersonType LegalEntity = new(2, "Pessoa Jurídica");
 
 
        public PersonType(int code, string name) : base(code, name) { }
        public static IEnumerable<PersonType> GetAll() => GetAll<PersonType>();
        public static PersonType Get(int code) => Get<PersonType>(code);
    }
}
