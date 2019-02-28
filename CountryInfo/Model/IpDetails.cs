using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Model
{
    public class IpDetails
    {

        private static readonly string url = "http://api.ipstack.com/";
        private const string AccessKey = "your key";
        public async static Task<string> GetLocation()
        {


            var myIp = await new HttpClient().GetStringAsync("https://api.ipify.org/");


            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url + myIp + AccessKey);
            var result = await response.Content.ReadAsStringAsync();
            IpDetail countryCode = JsonConvert.DeserializeObject<IpDetail>(result);
            
            return countryCode.country_code.ToString(); ;

        }

        public class IpDetail 
        {

            public string country_code { get; set; }
        }
    }
}

