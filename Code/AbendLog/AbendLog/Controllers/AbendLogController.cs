using AbendLog.BusinessAccess.Manager;
using AbendLog.BusinessAccess.Model;
using AbendLog.Helper;
using AbendLog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AbendLog.Controllers
{
    public class AbendLogController : Controller
    {
        public object ASPAbendDataEntities { get; private set; }

        // GET: AbendLog
        public ActionResult Index()
        {

            if (Session["Name"] != null)
            {
                AbendLog.Models.LandingPageInfocs landingPageInfocs = new AbendLog.Models.LandingPageInfocs();
                Session["AbendData"] = new AbendLogManager().AbendLogData(null, null, null, null, null, null, null, null, null, null);
                List<AbendLogData> lstAbend = (List<AbendLogData>)Session["AbendData"];
                landingPageInfocs.AbendLogRecordsPMS = lstAbend.Where(a => a.Team == "PMS").Count().ToString();
                landingPageInfocs.AbendLogRecordsExceed = lstAbend.Where(a => a.Team == "Exceed").Count().ToString();
                int[] ClassficationTypeDetails = new int[] {  lstAbend.Where(a=>a.Classification== "Implementation" && a.Team=="PMS").Count(),
                    lstAbend.Where(a=>a.Classification== "Incoming Data" && a.Team=="PMS").Count(),
                    lstAbend.Where(a=>a.Classification== "Infrastructure" && a.Team=="PMS").Count(),
                   lstAbend.Where(a=>a.Classification== "Others" && a.Team=="PMS").Count() ,lstAbend.Where(a=>a.Classification== "Implementation" && a.Team=="Exceed").Count(),
                    lstAbend.Where(a=>a.Classification== "Incoming Data" && a.Team=="Exceed").Count(),
                    lstAbend.Where(a=>a.Classification== "Infrastructure" && a.Team=="Exceed").Count(),
                   lstAbend.Where(a=>a.Classification== "Others" && a.Team=="Exceed").Count() };
                landingPageInfocs.ClassficationTypeDetails = ClassficationTypeDetails;
                landingPageInfocs.PermanentFixRecordsExceed = new PermanentFix().PermanentFixData(null, null).Count().ToString();
                landingPageInfocs.PermanentFixRecordsPMS = new PermanentFix().PermanentFixData(null, null).Count().ToString();
                return View(landingPageInfocs);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectClassification"></param>
        /// <returns></returns>
        public ActionResult List(string selectClassification, string team)
        {
            if (Session["Name"] != null)
            {
                AbendLog.Models.ListAbendLog ListAbendLog = new AbendLog.Models.ListAbendLog();
                List<AbendLog.Models.AbendLog> abendLst = new List<AbendLog.Models.AbendLog>();
                var incidentDetails = new List<SelectListItem>();
                incidentDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                var jobNamesDetails = new List<SelectListItem>();
                jobNamesDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                var stepNamesDetails = new List<SelectListItem>();
                stepNamesDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                
                var statusDetails = new List<SelectListItem>();
                statusDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                var classificationDetails = Common.GetAllClassfication();
                var subClassificationDetails = new List<SelectListItem>();
                subClassificationDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                var abendCodeDetails = new List<SelectListItem>();
                abendCodeDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                var rcaDetails = new List<SelectListItem>();
                rcaDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
                var abendStartDateDetails = new List<SelectListItem>();
                abendStartDateDetails.Add(new SelectListItem());
                var abendEndDateDetails = new List<SelectListItem>();
                abendEndDateDetails.Add(new SelectListItem());
                List<AbendLogData> lstAbend = new AbendLogManager().AbendLogData(null, null, null, null, null, string.IsNullOrEmpty(team) ? null : team, null, null, null, null);

                if (lstAbend.Count > 0)
                {
                    foreach (var item in lstAbend.Select(a => a.IncidentNumber).Distinct())
                    {
                        incidentDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }

                    foreach (var item in lstAbend.Select(a => a.JobName).Distinct())
                    {
                        jobNamesDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }

                    foreach (var item in lstAbend.Select(a => a.Status).Distinct())
                    {
                        statusDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }

                    foreach (var item in lstAbend.Select(a => a.StepName).Distinct())
                    {
                        stepNamesDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }
                    //foreach (var item in lstAbend.Select(a => a.Team).Distinct())
                    //{
                    //    TeamsDetails.Add(new SelectListItem() { Value = item, Text = item });
                    //}

                    foreach (var item in lstAbend.Select(a => a.Classification).Distinct())
                    {
                        subClassificationDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }
                    foreach (var item in lstAbend.Select(a => a.AbendCode).Distinct())
                    {
                        abendCodeDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }
                    foreach (var item in lstAbend.Select(a => a.RCA).Distinct())
                    {
                        rcaDetails.Add(new SelectListItem() { Value = item, Text = item });
                    }             
                }

                ListAbendLog.Incidents = incidentDetails;
                ListAbendLog.JobNames = jobNamesDetails;
                ListAbendLog.StepNames = stepNamesDetails;
              
                ListAbendLog.Status = statusDetails;
                ListAbendLog.Classifications = classificationDetails;
                ListAbendLog.SubClassifications = subClassificationDetails;
                ListAbendLog.AbendCodes = abendCodeDetails;
                ListAbendLog.RCAs = rcaDetails;
                ListAbendLog.AbendStartDate = abendStartDateDetails;
                ListAbendLog.AbendEndDate = abendEndDateDetails;
                return View(ListAbendLog);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: AbendLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ModelEmail()
        {
            List<AbendLogData> lst = new List<AbendLogData>();
            lst = (List<AbendLogData>)Session["AbendLogDataList"];
            return View(lst);
        }

        public ActionResult ProductionEmail()
        {
            List<AbendLogData> lst = new List<AbendLogData>();
            lst = (List<AbendLogData>)Session["AbendLogDataList"];
            return View(lst);
        }

        public ActionResult ModelStatusEmail()
        {
            List<AbendLogData> lst = new List<AbendLogData>();
            lst = (List<AbendLogData>)Session["AbendLogDataList"];
            return View(lst);
        }

        public ActionResult ProductionStatusEmail()
        {
            List<AbendLogData> lst = new List<AbendLogData>();
            lst = (List<AbendLogData>)Session["AbendLogDataList"];
            return View(lst);
        }

        [HttpGet]
        public JsonResult GetAbendLogData(string incidentNumber, string jobName, string stepName, string status, string classification, string team, string region, string abendCode, string rca, string startTime, string endTime)
        {
            IEnumerable<AbendLogData> AbendLogDataList = new List<AbendLogData>();
            AbendLogDataList = new AbendLogManager().AbendLogData(incidentNumber, jobName, stepName, abendCode, classification, team, region, rca, string.IsNullOrEmpty(startTime) ? (DateTime?)null : Convert.ToDateTime(startTime),
                string.IsNullOrEmpty(endTime) ? (DateTime?)null : Convert.ToDateTime(endTime));

            Session["AbendLogDataList"] = AbendLogDataList;
            return Json(new
            {
                iTotalRecords = AbendLogDataList.Count(),
                iTotalDisplayRecords = AbendLogDataList.Count(),
                aaData = AbendLogDataList
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: AbendLog/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }
        // POST: AbendLog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AbendLog.BusinessAccess.Model.AbendLogData abendLogData)
        {
            try
            {
                abendLogData.Createdby = Session["LANID"] != null ? Session["LANID"].ToString() : string.Empty;
                // TODO: Add insert logic here
                new AbendLogManager().AddAbendLog(abendLogData);
                return Content("<script language='javascript' type='text/javascript'>alert('Data Saved Successfully.');window.location.href='../AbendLog/List'</script>");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: AbendLog/Edit/5
        public ActionResult Edit(int ID)
        {
            AbendLogData abendLogData = new AbendLogData();

            AbendLogManager AM = new AbendLogManager();
            if (abendLogData != null)
            {
                abendLogData = AM.Edit_AbendLog_Data(ID);
                abendLogData.lstDocument = AM.GetDocuments(ID);

                if(string.IsNullOrEmpty(abendLogData.Modifiedby))
                    abendLogData.Modifiedby = Session["LANID"] != null ? Session["LANID"].ToString() : string.Empty;

            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(abendLogData);
        }

        // POST: AbendLog/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AbendLog.BusinessAccess.Model.AbendLogData abendLogData)
        {
            try
            {
                abendLogData.Modifiedby = Session["LANID"] != null ? Session["LANID"].ToString() : string.Empty;
                // TODO: Add insert logic here
                new AbendLogManager().UpdateAbendLog(abendLogData);
                return Content("<script language='javascript' type='text/javascript'>alert('Data Updated Successfully.');window.location.href='../AbendLog/List'</script>");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UploadFiles(AbendLog.BusinessAccess.Model.AbendLogData abendLogData)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string path = Server.MapPath(string.Format("{0}{1}{2}", "~/Uploads/", abendLogData.ID, "/"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    HttpPostedFileBase file = abendLogData.file;
                    if (file != null)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            file.SaveAs(path + abendLogData.FileName + Path.GetExtension(file.FileName));
                            if (new AbendLogManager().AddDocument(abendLogData.ID, abendLogData.FileName + Path.GetExtension(file.FileName), path + abendLogData.FileName + Path.GetExtension(file.FileName), Session["LANID"] != null ? Session["LANID"].ToString() : string.Empty) > 0)
                            {
                                return Content(string.Format("<script language='javascript' type='text/javascript'>alert('Document successfully uploaded'); window.location.href='/AbendLog//Edit?id={0}';</script>",abendLogData.ID));
                            }
                        }
                    }
                }
            }
            return Content(string.Format("<script language='javascript' type='text/javascript'>alert('Document not uploaded'); window.location.href='/AbendLog//Edit?id={0}';</script>", abendLogData.ID));
        }

        public ActionResult DownloadAttachment(int documentTypeId)
        {
            int abendLogId;
            string fileName = new AbendLogManager().DownloadFileDetails(documentTypeId, out abendLogId);
            if (!string.IsNullOrEmpty(fileName))
            {
                if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Uploads/" + abendLogId), fileName)))
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Uploads/" + abendLogId), fileName));
                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                }
                else
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Uploads/"), "No-Document-Uploaded.txt"));
                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "No-Document-Uploaded.txt");
                }
            }
            else
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Uploads/"), "No-Document-Uploaded.txt"));
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "No-Document-Uploaded.txt");
            }
        }

        public ActionResult DeleteDocument(int documentTypeId)
        {
            int abendLogId;
            //This file give the abendlog id with the file name
            string fileName = new AbendLogManager().DownloadFileDetails(documentTypeId, out abendLogId);

            if (!string.IsNullOrEmpty(fileName))
            {
                // Delete the file from the path
                if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Uploads/" + abendLogId), fileName)))
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads/" + abendLogId), fileName));

                    //This below functio will del;ete the file record on the table.
                    string file = new AbendLogManager().DeleteDocument(documentTypeId);
                    return Content("<script language='javascript' type='text/javascript'>alert('Document Deleted Successfully.'); window.location.href='/AbendLog/List';</script>");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Document Not Deleted.'); window.location.href='/AbendLog/List';</script>");
                }
            }
            else
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Uploads/"), "No-Document-Uploaded.txt"));
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "No-Document-Uploaded.txt");
            }
        }
    }
}
