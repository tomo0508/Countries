using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Converters
{
  public  class Headers
    {


        public static string BorderHeader(int count)
        {
            if (count > 1)
               return  "Land borders: ";
            else if (count == 1)
                return "Land border:";
            else
                return "No land borders";

        }

        public static string CurrencyHeader(int count)
        {
            if (count > 1)
                return "Currencies: ";
            else
               return "Currency: ";

        }

        public static string LanguageHeader(int count)
        {
            if (count > 1)
                return "Languages: ";
            else
                return "Language: ";

        }
    }
}
