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
    
    public partial class PermanentFix
    {
        public int ID { get; set; }
        public string IncidentNumber { get; set; }
        public string RCA { get; set; }
        public string TemporarilyResolution { get; set; }
        public string ProposedPermanentFix { get; set; }
        public string ComponentFixed { get; set; }
        public string FixStatus { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Comments { get; set; }
        public string Resources { get; set; }
        public string Reviewer { get; set; }
        public string Issues { get; set; }
        public string Team { get; set; }
        public string ApprovalForTheProposal { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
