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
    
    public partial class DocumentManagement
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