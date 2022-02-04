using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AbendLog.Models
{
    public class AbendLog
    {
        public string IncidentNumber { get; set; }
        public string PermanentFix { get; set; }
        public string Region { get; set; }
        public string JobName { get; set; }
        public string StepName { get; set; }
        public string ProgramName { get; set; }
        public string AbendCode { get; set; }
        public string AbendDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime AbendDate { get; set; }

        public string AbendTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime RestartTime { get; set; }

        public string OnCallAssociate { get; set; }
        public string TimeSpend { get; set; }
        public string RCA { get; set; }
        public string Classification { get; set; }
        public string SubClassification { get; set; }
        public string Solution { get; set; }
        public string OpenedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpenedDate { get; set; }

        public string ResolvedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime ResolvedDate { get; set; }

        public bool CallFromEnsono { get; set; }
        public string Escalation { get; set; }
        public string LevelTimeForEscalation { get; set; }
        public string EscalatedTo { get; set; }
        public string EscalatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EscalatedDate { get; set; }

        public string Status { get; set; }
        public string Comments { get; set; }
        public bool SLABreach { get; set; }
        public string SLABreachComments { get; set; }
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime ModifiedDate { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ServiceTypeId { get; set; }
        public string AcceptedBy { get; set; }
        public string AdminComments { get; set; }
        public string UserServicesName { get; set; }
        public string ServiceRequest { get; set; }
        public string AcceptedDate { get; set; }
        public List<SelectListItem> SelectListServices { get; set; }
        public string Message { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public bool IsMobile { get; set; }
        public string ServiceName { get; set; }
        public IEnumerable<SelectListItem> SelectIEnumerableSubServices { get; set; }
        public IEnumerable<SelectListItem> SelectIEnumerableServices { get; set; }

        public IEnumerable<SelectListItem> SelectIEnumerableBrand { get; set; }
        public IEnumerable<SelectListItem> SelectIEnumerableCountry { get; set; }
        public IEnumerable<SelectListItem> SelectIEnumerableState { get; set; }
        public IEnumerable<SelectListItem> SelectIEnumerableCity { get; set; }
        public IEnumerable<SelectListItem> SelectIEnumerableStatus { get; set; }

        public int BrandId { get; set; }
        public string MobileNumber { get; set; }

        public string AlternateNumber { get; set; }
        public string GeneratedOTP { get; set; }
        public bool ResendOTP { get; set; }
        public string Service { get; set; }

        public string ServiceDate { get; set; }
        public string SubService { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsExistingUser { get; set; }
        public string LeadBalance { get; set; }

        public int AcceptedLead { get; set; }
        public string Amount { get; set; }
        public int DismissLead { get; set; }
        public bool IsAgree { get; set; }
        public bool IsWarrantyPeriod { get; set; }
        public bool IsDeleted { get; set; }

        public string CustomerReview { get; set; }
        public decimal AmountRecovered { get; set; }
        public decimal AmountPaid { get; set; }
        public string PartnerStartTime { get; set; }
        public string PartnerEndTime { get; set; }
        public string FileName { get; set; }
        public string PathName { get; set; }

        public string StatusName { get; set; }

    }
}