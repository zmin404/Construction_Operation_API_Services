//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISODAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_PersonType
    {
        public tbl_PersonType()
        {
            this.tbl_Person = new HashSet<tbl_Person>();
        }
    
        public int PersonTypeID { get; set; }
        public string PersonType { get; set; }
        public bool Active { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<tbl_Person> tbl_Person { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}
