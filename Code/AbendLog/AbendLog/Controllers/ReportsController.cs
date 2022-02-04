using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using AbendLog.Models;
using AbendLog.BusinessAccess.Manager;
using System;
using AbendLog.Helper;
using AbendLog.BusinessAccess.Model;
using System.Linq;

namespace AbendLog.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            ReportViewModel report = new ReportViewModel();
            report.Classifications = Common.GetAllClassfication();
            return View(report);
        }

        public List<AbendLog.BusinessAccess.Model.PermanentFixData> PermanentFixData()
        {
            AbendLog.Models.ListAbendLog ListAbendLog = new AbendLog.Models.ListAbendLog();
            List<AbendLog.BusinessAccess.Model.PermanentFixData> lstAbend = new PermanentFix().PermanentFixData(null, null);
            return lstAbend;
        }

        public JsonResult GetAbendDetailsforCharts()
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
                   lstAbend.Where(a=>a.Classification== "Others" && a.Team=="Exceed").Count(),
                lstAbend.Where(a=>a.Classification== "Implementation" && a.Team=="PMS" && a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020") ).Count(),
                    lstAbend.Where(a=>a.Classification== "Incoming Data" && a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                    lstAbend.Where(a=>a.Classification== "Infrastructure" && a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                   lstAbend.Where(a=>a.Classification== "Others" && a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                lstAbend.Where(a=>a.Classification== "Implementation" && a.Team=="Exceed" && a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020") ).Count(),
                    lstAbend.Where(a=>a.Classification== "Incoming Data" && a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                    lstAbend.Where(a=>a.Classification== "Infrastructure" && a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                   lstAbend.Where(a=>a.Classification== "Others" && a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                lstAbend.Where(a=>a.Classification== "Implementation" && a.Team=="PMS" && a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021") ).Count(),
                    lstAbend.Where(a=>a.Classification== "Incoming Data" && a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                    lstAbend.Where(a=>a.Classification== "Infrastructure" && a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                   lstAbend.Where(a=>a.Classification== "Others" && a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                lstAbend.Where(a=>a.Classification== "Implementation" && a.Team=="Exceed" && a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021") ).Count(),
                    lstAbend.Where(a=>a.Classification== "Incoming Data" && a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                    lstAbend.Where(a=>a.Classification== "Infrastructure" && a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                    lstAbend.Where(a=>a.Classification== "Others" && a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                   lstAbend.Where(a=> a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                   lstAbend.Where(a=>a.Team=="PMS"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count(),
                   lstAbend.Where(a=>a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2019")&&a.AbendDate <Convert.ToDateTime("01/01/2020")).Count(),
                   lstAbend.Where(a=>a.Team=="Exceed"&& a.AbendDate >=Convert.ToDateTime("01/01/2020")&&a.AbendDate <Convert.ToDateTime("01/01/2021")).Count()
                };
                landingPageInfocs.ClassficationTypeDetails = ClassficationTypeDetails;
                landingPageInfocs.PermanentFixRecordsExceed = new PermanentFix().PermanentFixData(null, null).Count().ToString();
                landingPageInfocs.PermanentFixRecordsPMS = new PermanentFix().PermanentFixData(null, null).Count().ToString();
                return Json(landingPageInfocs, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public ActionResult ExportToExcel(ReportViewModel model)
        {
            var gv = new GridView();
            string fileName = string.Empty;
            AbendLog.Models.ListAbendLog ListAbendLog = new AbendLog.Models.ListAbendLog();
            ListAbendLog.AbendLog = new AbendLogManager().AbendLogData(null, null, null, null, model.SelectClassification, model.Team, model.Region,model.RCA, string.IsNullOrEmpty(model.AbendStartDate) ? (DateTime?)null : Convert.ToDateTime(model.AbendStartDate),
                string.IsNullOrEmpty(model.AbendEndDate) ? (DateTime?)null : Convert.ToDateTime(model.AbendEndDate));
            gv.DataSource = ListAbendLog.AbendLog;
            fileName = "AbendLog_" + DateTime.Now.ToString() + ".xls";
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }
    }
}