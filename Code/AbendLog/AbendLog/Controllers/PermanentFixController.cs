using AbendLog.BusinessAccess.Manager;
using AbendLog.BusinessAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbendLog.Controllers
{
    public class PermanentFixController : Controller
    {
        // GET: PermanentFix
        public ActionResult Index()
        {
            return View();
        }
        // GET: PermanentFix/Edit/5
        public ActionResult EditPF(int ID)
        {
            PermanentFixData permanentFixData = new PermanentFixData();

            PermanentFix AM = new PermanentFix();
            if (permanentFixData != null)
            {
                permanentFixData = AM.Edit_PermanentFix_Data(ID);

            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(permanentFixData);
        }

        // POST: PermanentFix/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPF(AbendLog.BusinessAccess.Model.PermanentFixData permanentFixData)
        {

            try
            {
                permanentFixData.ModifiedBy= Session["LANID"].ToString();
                new PermanentFix().UpdatePermanentFix(permanentFixData);
                return Content("<script language='javascript' type='text/javascript'>alert('Data Updated Successfully.');window.location.href='../PermanentFix/Index'</script>");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // GET: PermanentFix/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: PermanentFix/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AbendLog.BusinessAccess.Model.PermanentFixData permanentfixData)
        {
            try
            {
                permanentfixData.CreatedBy = Session["LANID"].ToString();
                new PermanentFix().AddPermanentFix(permanentfixData);
                return Content("<script language='javascript' type='text/javascript'>alert('Data Saved Successfully.');window.location.href='../PermanentFix/Index'</script>");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Filter(string selectClassification)
        {
            if (Session["Name"] != null)
            {
                AbendLog.Models.ListAbendLog ListAbendLog = new AbendLog.Models.ListAbendLog();
                List<AbendLog.Models.AbendLog> abendLst = new List<AbendLog.Models.AbendLog>();
                var incidentDetails = new List<SelectListItem>();
                incidentDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });         
                var rcaDetails = new List<SelectListItem>();
                rcaDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                List<PermanentFixData> lstAbend = new PermanentFix().PermanentFixData(null, null);

                if (lstAbend.Count > 0)
                {
                    foreach (var item in lstAbend.Select(a => a.IncidentNumber).Distinct())
                    {
                        incidentDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }

                   
                    foreach (var item in lstAbend.Select(a => a.RCA).Distinct())
                    {
                        rcaDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }
                }

                ListAbendLog.Incidents = incidentDetails;      
                ListAbendLog.RCAs = rcaDetails;
                return View(ListAbendLog);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        

        [HttpGet]
        public JsonResult getPermanentFixData(string incidentNumber,  string rca)
        {
            PermanentFix PF = new PermanentFix();

            IEnumerable<PermanentFixData> PermanentFixDatalist = new List<PermanentFixData>();
            PermanentFixDatalist = new PermanentFix().PermanentFixData(incidentNumber, rca);
           
            return Json(new
            {
                iTotalRecords = PermanentFixDatalist.Count(),
                iTotalDisplayRecords = PermanentFixDatalist.Count(),
                aaData = PermanentFixDatalist
            }, JsonRequestBehavior.AllowGet);
        }

    }
}