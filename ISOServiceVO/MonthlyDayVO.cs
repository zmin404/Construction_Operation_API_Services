using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class MonthlyDayVO
    {
        [DataMember]
        public Nullable<bool> d1 { get; set; }
    }
}
