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
    
    public partial class tbl_SOPMeetingPDF
    {
        public int ID { get; set; }
        public int SiteID { get; set; }
        public string SOPMeetingPDF { get; set; }
    
        public virtual tbl_Site tbl_Site { get; set; }
    }
}
