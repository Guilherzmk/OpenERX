 
using OpenERX.Commons.Types.Generics;

namespace OpenERX.Commons.Types.Fields
{
    public class DataType : StringCodeName
    {
        public static DataType String = new("string", "Texto");
        public static DataType Integer = new("integer", "Inteiro");
        public static DataType Boolean = new("boolean", "Booleano");
        public static DataType Float = new("float", "Número Flutuante");
        public static DataType Money = new("money", "Dinheiro");
        public static DataType Percentage = new("percentage", "Porcentagem");
        public static DataType Date = new("date", "Data");
        public static DataType DateTime = new("datetime", "Data e Hora");
        public static DataType Guid = new("guid", "Guid");
        public static DataType Fields = new("fields", "Campos");
        public static DataType Object = new("object", "Objeto");
        public static DataType KeyValueList = new("key_value_list", "Lista de Chave e Valor");
        public static DataType ListValues = new("list_values", "Lista de Valores");
        public static DataType ListPhones = new("list_phones", "Lista de Telefones");

        public DataType(string code, string name) : base(code, name) { }
        public static IEnumerable<DataType> GetAll() => GetAll<DataType>();
        public static DataType Get(string code) => Get<DataType>(code);
    }
}
