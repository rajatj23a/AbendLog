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
    
    public partial class p_GetAbendlogData_Result
    {
        public int ID { get; set; }
        public string IncidentNumber { get; set; }
        public string Region { get; set; }
        public string Team { get; set; }
        public string JobName { get; set; }
        public string StepName { get; set; }
        public string ProgramName { get; set; }
        public string AbendCode { get; set; }
        public string AbendDescription { get; set; }
        public Nullable<System.DateTime> AbendDate { get; set; }
        public string AbendTime { get; set; }
        public string RestartTime { get; set; }
        public string OnCallAssociate { get; set; }
        public string TimeSpend { get; set; }
        public string RCA { get; set; }
        public string Classification { get; set; }
        public string SubClassification { get; set; }
        public string Solution { get; set; }
        public string ResolvedBy { get; set; }
        public Nullable<System.DateTime> ResolvedDate { get; set; }
        public string CallFromEnsono { get; set; }
        public string LevelTimeForEscalation { get; set; }
        public Nullable<System.DateTime> EscalatedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string SLABreach { get; set; }
        public string Createdby { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Modifiedby { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool PermanentFix { get; set; }
    }
}