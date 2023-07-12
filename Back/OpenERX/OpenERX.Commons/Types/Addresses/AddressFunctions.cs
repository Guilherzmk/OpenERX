using System.Text;
using OpenERX.Commons.Functions;

namespace OpenERX.Commons.Types.Addresses
{
    public static class AddressFunctions
    {
        public static string Format(
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string zipCode,
            string addressTypeName)
        {

            var sb = new StringBuilder();

            sb.Append(Format(street, number, complement, district, city, state, zipCode));

            if (!string.IsNullOrWhiteSpace(addressTypeName))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append("(" + addressTypeName.ToUpper() + ")");
            }

            return sb.ToString().ToUpper();
        }

        public static string Format(
           string street,
           string number,
           string complement,
           string district,
           string city,
           string state,
           string zipCode)
        {
            var sb = new StringBuilder();
 
            if (!string.IsNullOrWhiteSpace(street))
            {
                sb.Append(street);
            }

            if (!string.IsNullOrWhiteSpace(number))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(", ");
                }

                sb.Append(number);
            }


            if (!string.IsNullOrWhiteSpace(complement))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append(complement);
            }
            if (!string.IsNullOrWhiteSpace(district))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append(district);
            }
            if (!string.IsNullOrWhiteSpace(city))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(", ");
                }

                sb.Append(city);
            }
            if (!string.IsNullOrWhiteSpace(state))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" - ");
                }

                sb.Append(state);
            }
            if (!string.IsNullOrWhiteSpace(zipCode))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append("CEP:" + NumberFunctions.GetLong(zipCode).ToString("00000-000"));
            }


            return sb.ToString().ToUpper();
        }

        public static string GoogleMapsLink(
          string street,
          string number,
          string district,
          string city,
          string state)
        {
            var sb = new StringBuilder();
            sb.Append("https://maps.google.com/maps?q=");


            if (!string.IsNullOrWhiteSpace(street))
            {
                sb.Append(street.Replace(" ", "+"));
            }

            if (!string.IsNullOrWhiteSpace(number))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append(number.Replace(" ", "+"));
            }


            if (!string.IsNullOrWhiteSpace(district))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append(district.Replace(" ", "+"));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append(city.Replace(" ", "+"));
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    sb.Append(" ");
                }

                sb.Append(state);
            }
            //if (!string.IsNullOrWhiteSpace(zipCode))
            //{
            //    if (!string.IsNullOrWhiteSpace(sb.ToString()))
            //    {
            //        sb.Append(" ");
            //    }

            //    sb.Append("CEP:" + NumberFunctions.GetLong(zipCode).ToString("00000-000"));
            //}




            return sb.ToString().ToLower();
        }
 
        public static bool IsValid(
            string street,
            string city,
            string state)
        {

            return !string.IsNullOrWhiteSpace(street) ||
                   !string.IsNullOrWhiteSpace(city) ||
                   !string.IsNullOrWhiteSpace(state);

        }
 
    }
}
