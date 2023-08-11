 
using OpenERX.Commons.Constants;
using OpenERX.Commons.Languages;
using OpenERX.Commons.Types.Generics;

namespace OpenERX.Core.Customers
{
public class CustomerStatus : CodeNameColor
{
public static CustomerStatus Active = new(1, Words.Active, MaterialColor.GREEN_500);
public static CustomerStatus Disabled = new(2, Words.Disabled, MaterialColor.GREY_500);
public static CustomerStatus Canceled = new(3, Words.Canceled, MaterialColor.RED_500);

public CustomerStatus(int code, string name, string color) : base(code, name, color) { }
public static IEnumerable<CustomerStatus> GetAll() => GetAll<CustomerStatus>();
public static CustomerStatus Get(int code) => Get<CustomerStatus>(code);
}
}
