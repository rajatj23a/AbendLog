//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbendLog.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTbl
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string LANID { get; set; }
        public string PASSWORD { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
