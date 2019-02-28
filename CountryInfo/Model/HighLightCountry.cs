using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Model
{
    class HighLightCountry
    { 
    public object Features { get; internal set; }

    public class Properties
    {
        public string name { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<object>>> coordinates { get; set; }
    }

    public class FeatureCollection
    {
        public string type { get; set; }
        public string id { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class RootObject
    {
        public string type { get; set; }
        public List<HighLightCountry> features { get; set; }
    }






}
}
