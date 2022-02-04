
using AbendLog.BusinessAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AbendLog.Models
{
    public class ListAbendLog
    {
        public List<AbendLogData> AbendLog { get; set; }


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

        public List<SelectListItem> Incidents { get; set; }

        public string SelectIncidentNumber { get; set; }

        public List<SelectListItem> JobNames { get; set; }

        public string SelectJobName
        {
            get; set;
        }
        public List<SelectListItem> StepNames { get; set; }
        public string SelectStepName { get; set; }

        public List<SelectListItem> Status { get; set; }
        public string SelectStatus { get; set; }

        public List<SelectListItem> Classifications { get; set; }
        public string SelectClassification { get; set; }

        public List<SelectListItem> SubClassifications { get; set; }
        public string SelectSubClassification { get; set; }

        public List<SelectListItem> AbendCodes { get; set; }
        public string SelectAbendCode { get; set; }

        public List<SelectListItem> Teams { get; set; }
        public string SelectTeam { get; set; }

        public List<SelectListItem> RCAs { get; set; }
        public string SelectRCA { get; set; }

        public List<SelectListItem> CreatedBys { get; set; }
        public string SelectCreatedBy { get; set; }

        public List<SelectListItem> CreatedDates { get; set; }
        public string SelectCreatedDate { get; set; }

        public List<SelectListItem> ModifiedBys { get; set; }
        public string SelectModifiedBy { get; set; }

        public List<SelectListItem> ModifiedDates { get; set; }
        public string SelectModifiedDates { get; set; }

        public List<SelectListItem> AbendLogClassifications { get; set; }
        public string AbendLogSelectClassification { get; set; }

        public List<SelectListItem> PermanentFixClassifications { get; set; }
        public string PermanentFixSelectClassification { get; set; }

        public List<SelectListItem> AbendStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SelectAbendStartDate { get; set; }

        public List<SelectListItem> AbendEndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SelectAbendEndDate { get; set; }
    }
}