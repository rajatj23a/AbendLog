using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbendLog.Helper
{
    public static class Common
    {
        public static List<SelectListItem> GetAllClassfication()
        {
            var classificationDetails = new List<SelectListItem>();
            classificationDetails.Add(new SelectListItem() { Value = "", Text = "--Select--" });
            classificationDetails.Add(new SelectListItem() { Value = "Implementation", Text = "Implementation" });
            classificationDetails.Add(new SelectListItem() { Value = "Incoming Data", Text = "Incoming Data" });
            classificationDetails.Add(new SelectListItem() { Value = "Infrastructure", Text = "Infrastructure" });
            classificationDetails.Add(new SelectListItem() { Value = "Others", Text = "Others" });
            return classificationDetails;
        }
    }
}