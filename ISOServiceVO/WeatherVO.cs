using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class WeatherVO
    {
        [DataMember]
        public int WeatherID { get; set; }
        [DataMember]
        public string Weather { get; set; }
    }
}
