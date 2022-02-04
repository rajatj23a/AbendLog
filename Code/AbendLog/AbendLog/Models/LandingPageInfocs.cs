using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbendLog.Models
{
    public class LandingPageInfocs
    {
        public string UserName { get; set; }
        public string LANID { get; set; }
        public string CurrentDateTime { get; set; }
        public string EmailId { get; set; }
        public string AbendLogRecordsPMS { get; set; }
        public string AbendLogRecordsExceed { get; set; }
        public string AbendLogActiveRecords { get; set; }
        public string PermanentFixRecordsPMS{ get; set; }
        public string PermanentFixRecordsExceed { get; set; }

        public int[] ClassficationTypeDetails { get; set; }

    }
}