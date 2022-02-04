using System;

namespace AbendLog.BusinessAccess.Model
{
    public class DocumentManagement
    {
        public int DocumentId { get; set; }
        public int AbendId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public bool IsReUpload { get; set; }
        public string UploadedBy { get; set; }
        public System.DateTime UploadedDate { get; set; }
        public string ReuploadedBy { get; set; }
        public Nullable<System.DateTime> ReuploadedDate { get; set; }
    }
}