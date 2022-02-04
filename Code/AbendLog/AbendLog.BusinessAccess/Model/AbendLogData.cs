using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AbendLog.BusinessAccess.Model
{
    public class AbendLogData
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? AbendDate { get; set; }

        public string AbendTime { get; set; }
        public string RestartTime { get; set; }
        public string OnCallAssociate { get; set; }
        public string TimeSpend { get; set; }
        public string RCA { get; set; }
        public string Classification { get; set; }
        public string SubClassification { get; set; }
        public string Solution { get; set; }
        public string OpenedBy { get; set; }
        public string ResolvedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? ResolvedDate { get; set; }

        public string CallFromEnsono { get; set; }
        public string Escalation { get; set; }
        public string LevelTimeForEscalation { get; set; }
        public string EscalatedTo { get; set; }
        public string EscalatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? EscalatedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string SLABreach { get; set; }
        public string SLABreachComments { get; set; }
        public string Createdby { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime CreatedDate { get; set; }
        public string Modifiedby { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public bool PermanentFix { get; set; }
        public HttpPostedFileBase file { get; set; }
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string AbendId { get; set; }
        public List<DocumentManagement> lstDocument { get; set; }
    }
}
