using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class ContractPDFVO
    {
         [DataMember]
         public int ID { get; set; }
         [DataMember]
         public int SiteID { get; set; }
         [DataMember]
         public string ContractPDF { get; set; }
    }
}
