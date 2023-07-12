using OpenERX.Commons.Languages;
using OpenERX.Commons.Types.Generics;

namespace OpenERX.Core.Shared
{
    public class Feature : CodeName
    {
        public Feature(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public static Feature User = new(1000, Words.User);
        public static Feature Profile = new(1001, Words.Profile);
        public static Feature Customer = new(1002, Words.Customer);
        public static Feature Broker = new(1003, Words.Broker);
        public static Feature Store = new(1004, Words.Store);
        public static Feature Supplier = new(1005, Words.Supplier);
        public static Feature Item = new(1006, Words.Item);

        //Pedido de Compra e Venda
        public static Feature Order = new(1007, Words.Order);
        public static Feature OrderItem = new(100701, Words.Order);


        //Entrada e Saída de Estoque
        public static Feature Movement = new(1008, Words.Movement);
        public static Feature MovementItem = new(100801, Words.Movement);


        public static Feature Status = new(1009, Words.Status);
        public static Feature Attribute = new(1010, Words.Attribute);
        public static Feature Group = new(1011, Words.Group);
        public static Feature Transaction = new(1012, Words.Transaction);
        public static Feature Invoice = new(1013, Words.Invoice);
    }
}