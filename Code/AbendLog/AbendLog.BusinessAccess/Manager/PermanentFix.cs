using AbendLog.BusinessAccess.Model;
using AbendLog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbendLog.BusinessAccess.Manager
{
    public class PermanentFix
    {
        ASPAbendLogDataEntities DBEntities = new ASPAbendLogDataEntities();

        //Edit functionality of Permanent fix.
        public PermanentFixData Edit_PermanentFix_Data(int ID)
        {
            PermanentFixData lstPermanentfixdata = new PermanentFixData();

            var list = DBEntities.PermanentFixes.Where(i => i.ID == ID);
            if (list != null)
            {
                if (list.Count() != 0)
                {
                    AbendLog.DataAccess.PermanentFix permanentfix = DBEntities.PermanentFixes.Where(i => i.ID == ID).FirstOrDefault();
                    lstPermanentfixdata.IncidentNumber = permanentfix.IncidentNumber;
                    lstPermanentfixdata.RCA = permanentfix.RCA;
                    lstPermanentfixdata.TemporarilyResolution = permanentfix.TemporarilyResolution;
                    lstPermanentfixdata.ProposedPermanentFix = permanentfix.ProposedPermanentFix;
                    lstPermanentfixdata.ComponentFixed = permanentfix.ComponentFixed;
                    lstPermanentfixdata.FixStatus = permanentfix.FixStatus;
                    lstPermanentfixdata.StartDate = Convert.ToDateTime( permanentfix.StartDate);
                    lstPermanentfixdata.EndDate =Convert.ToDateTime( permanentfix.EndDate);
                    lstPermanentfixdata.Comments = permanentfix.Comments;
                    lstPermanentfixdata.Resources = permanentfix.Resources;
                    lstPermanentfixdata.Reviewer = permanentfix.Reviewer;
                    lstPermanentfixdata.Issues = permanentfix.Issues;
                    lstPermanentfixdata.Team = permanentfix.Team;
                    lstPermanentfixdata.ApprovalForTheProposal = permanentfix.ApprovalForTheProposal;
                    lstPermanentfixdata.CreatedBy = permanentfix.CreatedBy;
                    lstPermanentfixdata.CreatedDate = Convert.ToDateTime(permanentfix.CreatedDate);
                }
            }

            return lstPermanentfixdata;
        }



        public List<PermanentFixData> PermanentFixData(string incidentNumber, string rCA)
        {

            List<PermanentFixData> lstPermanentFix = new List<PermanentFixData>();

            foreach (p_GetPermanentFixData_Result GetPermamentFixData_Result in DBEntities.p_GetPermanentFixData(incidentNumber,rCA,null,null,null,null))
            {
                PermanentFixData permanentdata = new PermanentFixData();
                permanentdata.ID = (GetPermamentFixData_Result.ID);
                permanentdata.IncidentNumber = GetPermamentFixData_Result.IncidentNumber.ToString();
                permanentdata.Team = GetPermamentFixData_Result.Team.ToString();
                permanentdata.RCA = (GetPermamentFixData_Result.RCA);
                permanentdata.ComponentFixed = GetPermamentFixData_Result.ComponentFixed.ToString();
                permanentdata.Issues = (GetPermamentFixData_Result.Issues);
                permanentdata.CreatedBy = (GetPermamentFixData_Result.CreatedBy);
                permanentdata.CreatedDate = Convert.ToDateTime(GetPermamentFixData_Result.CreatedDate);
                lstPermanentFix.Add(permanentdata);
            }
            return lstPermanentFix;

        }

        /// <summary>
        /// Adding the permanent Fix based on the data entered by Users
        /// </summary>
        /// <param name="permanentFixData">Data of the abend in the model format</param>
        public void AddPermanentFix(BusinessAccess.Model.PermanentFixData permanentFixData)
        {
            try
            {
                DBEntities.p_InsertPermanentFixData(permanentFixData.IncidentNumber, permanentFixData.RCA, permanentFixData.TemporarilyResolution, permanentFixData.ProposedPermanentFix, 
                    permanentFixData.ComponentFixed, permanentFixData.FixStatus,Convert.ToDateTime( permanentFixData.StartDate), Convert.ToDateTime( permanentFixData.EndDate), permanentFixData.Comments, permanentFixData.Resources, permanentFixData.Reviewer
                    , permanentFixData.Issues, permanentFixData.Team, permanentFixData.ApprovalForTheProposal,
                    permanentFixData.CreatedBy, System.DateTime.Now, null,null);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// <summary>
        /// Updating the permanent Fix Data based on the data entered by Users
        /// </summary>
        /// <param name="permanentFixData">Data of the abend in the model format</param>
        public void UpdatePermanentFix(BusinessAccess.Model.PermanentFixData permanentFixData)
        {
            try
            {
                var permanentFix = DBEntities.PermanentFixes.Where(a => a.ID == permanentFixData.ID).FirstOrDefault();
                permanentFix.IncidentNumber = permanentFixData.IncidentNumber;
                permanentFix.RCA = permanentFixData.RCA;
                permanentFix.TemporarilyResolution = permanentFixData.TemporarilyResolution;
                permanentFix.ProposedPermanentFix = permanentFixData.ProposedPermanentFix;
                permanentFix.ComponentFixed = permanentFixData.ComponentFixed;
                permanentFix.FixStatus = permanentFixData.FixStatus;
                permanentFix.StartDate = Convert.ToDateTime( permanentFixData.StartDate);
                permanentFix.EndDate = Convert.ToDateTime( permanentFixData.EndDate);
                permanentFix.Comments = permanentFixData.Comments;
                permanentFix.Resources = permanentFixData.Resources;
                permanentFix.Reviewer = permanentFixData.Reviewer;
                permanentFix.Issues = permanentFixData.Issues;
                permanentFix.Team = permanentFixData.Team;
                permanentFix.ApprovalForTheProposal = permanentFixData.ApprovalForTheProposal;
                permanentFix.ModifiedBy = permanentFixData.ModifiedBy;
                permanentFix.ModifiedDate = System.DateTime.Now;
                DBEntities.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
