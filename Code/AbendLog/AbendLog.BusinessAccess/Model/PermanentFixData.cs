using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbendLog.BusinessAccess.Model
{
    public class PermanentFixData
    {
        public int ID { get; set; }
        public string IncidentNumber { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string RCA { get; set; }
        public string TemporarilyResolution { get; set; }
        public string ProposedPermanentFix { get; set; }
        public string ComponentFixed { get; set; }
        public string FixStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Resources { get; set; }
        public string Reviewer { get; set; }
        public string Issues { get; set; }
        public string Team { get; set; }
        public string ApprovalForTheProposal { get; set; }
        public string Comments { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }


    }
}
