using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbendLog.BusinessAccess.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
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
