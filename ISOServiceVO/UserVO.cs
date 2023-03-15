using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class UserVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserRoleID { get; set; }
        [DataMember]
        //public Nullable<int> PersonandSiteID { get; set; }
        public Nullable<int> PersonID { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int LastModifiedBy { get; set; }
        [DataMember]
        public System.DateTime LastModifiedOn { get; set; }

        [DataMember]
        public string UserRole { get; set; }
        [DataMember]
        public string PersonName { get; set; }
    }
}
