using AbendLog.BusinessAccess.Manager;
using AbendLog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbendLog.Controllers
{
    public class MigrationController : Controller
    {
        // GET: UserManagement
        public ActionResult Upload()
        {
            if (Session["LANID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "AbendLog");
            }
        }

        public ActionResult DownloadAttachment()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Template/"), "AbendLog_Template.xlsx"));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "AbendLog_Template.xlsx");
        }


        [HttpPost]
        public ActionResult Upload(AbendLog.Models.UploadFile upload)
        {
            if (Session["LANID"] != null)
            {
                try
                {
                    string targetFolder = Server.MapPath("~/Template/Upload Files");
                    string targetPath = Path.Combine(targetFolder, DateTime.Now.ToString("mm/dd/yyyy") + "_" + upload.file.FileName);
                    upload.file.SaveAs(targetPath);

                    DataTable dataTable = exceldata(targetPath);
                    new AbendLogManager().AddExcelData(dataTable,Session["LANID"].ToString());
                    return Content("<script language='javascript' type='text/javascript'>alert('Records updated successfully.'); window.location.href='/Migration/Upload';</script>");

                }
                catch (Exception ex)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('" + ex.Message.ToString() + "'); " +
                        "window.location.href='/Migration/Upload';</script>");
                }
            }
            else
            {
                return RedirectToAction("Index", "AbendLog");
            }
        }

        public static DataTable exceldata(string filePath)
        {
            DataTable dtexcel = new DataTable();
            bool hasHeaders = false;
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //Looping Total Sheet of Xl File
            /*foreach (DataRow schemaRow in schemaTable.Rows)
            {
            }*/
            //Looping a first Sheet of Xl File
            DataRow schemaRow = schemaTable.Rows[0];
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_"))
            {
                string query = "SELECT  * FROM ["+ sheet + "]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                dtexcel.Locale = CultureInfo.CurrentCulture;
                daexcel.Fill(dtexcel);
            }

            conn.Close();
            return dtexcel;

        }
    }
}