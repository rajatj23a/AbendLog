using AbendLog.BusinessAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace AbendLog.Models
{
    public class ReportViewModel
    {
        public string RequestId { get; set; }

        public string Team { get; set; }
        public string Region { get; set; }
        public string RCA { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public List<SelectListItem> Classifications { get; set; }
        public string SelectClassification { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string AbendStartDate { get; set; }
    

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string AbendEndDate { get; set; }
    }
}