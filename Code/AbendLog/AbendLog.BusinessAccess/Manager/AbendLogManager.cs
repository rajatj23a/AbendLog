using AbendLog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbendLog.BusinessAccess.Model;
using System.Data;

namespace AbendLog.BusinessAccess.Manager
{
    public class AbendLogManager
    {
        ASPAbendLogDataEntities DBEntities = new ASPAbendLogDataEntities();

        public AbendLogManager()
        {

        }

        public AbendLogData Edit_AbendLog_Data(int ID)
        {
            AbendLogData lstAbendLogData = new AbendLogData();

            var list = DBEntities.AbendLogs.Where(i => i.ID == ID);
            if (list != null)
            {
                if (list.Count() != 0)
                {
                    AbendLog.DataAccess.AbendLog abendlog = DBEntities.AbendLogs.Where(i => i.ID == ID).FirstOrDefault();
                    lstAbendLogData.IncidentNumber = abendlog.IncidentNumber;
                    lstAbendLogData.Region = abendlog.Region;
                    lstAbendLogData.Team = abendlog.Team;
                    lstAbendLogData.ProgramName = abendlog.ProgramName;
                    lstAbendLogData.StepName = abendlog.StepName;
                    lstAbendLogData.ProgramName = abendlog.ProgramName;
                    lstAbendLogData.AbendCode = abendlog.AbendCode;
                    lstAbendLogData.AbendDescription = abendlog.AbendDescription;
                    lstAbendLogData.AbendDate = abendlog.AbendDate;
                    lstAbendLogData.AbendTime = abendlog.AbendTime;
                    lstAbendLogData.RestartTime = abendlog.RestartTime;
                    lstAbendLogData.OnCallAssociate = abendlog.OnCallAssociate;
                    lstAbendLogData.TimeSpend = abendlog.TimeSpend;
                    lstAbendLogData.RCA = abendlog.RCA;
                    lstAbendLogData.Classification = abendlog.Classification;
                    lstAbendLogData.SubClassification = abendlog.SubClassification;
                    lstAbendLogData.Solution = abendlog.Solution;
                    lstAbendLogData.ResolvedBy = abendlog.ResolvedBy;
                    lstAbendLogData.ResolvedDate = abendlog.ResolvedDate;
                    lstAbendLogData.CallFromEnsono = abendlog.CallFromEnsono;
                    lstAbendLogData.LevelTimeForEscalation = abendlog.LevelTimeForEscalation;
                    lstAbendLogData.EscalatedDate = abendlog.EscalatedDate;
                    lstAbendLogData.Status = abendlog.Status;
                    lstAbendLogData.Comments = abendlog.Comments;
                    lstAbendLogData.SLABreach = abendlog.SLABreach;
                    lstAbendLogData.Createdby = abendlog.Createdby;
                    lstAbendLogData.CreatedDate = abendlog.CreatedDate;
                    lstAbendLogData.Modifiedby = abendlog.Modifiedby;
                    lstAbendLogData.ModifiedDate = abendlog.ModifiedDate;
                    lstAbendLogData.PermanentFix = abendlog.PermanentFix;

                }

            }

            return lstAbendLogData;
        }

        public List<AbendLogData> AbendLogData(string incidentNumber, string jobName, string stepName, string abendCode, string classification, string team,string region,string rca, DateTime? startTime, DateTime? endTime)
        {
            List<AbendLogData> lstAbendLogData = new List<AbendLogData>();

            foreach (p_GetAbendlogData_Result GetAbendlogData_Result in DBEntities.p_GetAbendlogData(incidentNumber, jobName, stepName, abendCode, classification, team, region,rca, startTime, endTime))
            {
                AbendLogData abendLogData = new AbendLogData();
                abendLogData.ID = (GetAbendlogData_Result.ID);
                abendLogData.JobName = (GetAbendlogData_Result.JobName);
                abendLogData.IncidentNumber = GetAbendlogData_Result.IncidentNumber;
                abendLogData.Region = GetAbendlogData_Result.Region;
                abendLogData.Team = GetAbendlogData_Result.Team;
                abendLogData.ProgramName = GetAbendlogData_Result.ProgramName;
                abendLogData.StepName = GetAbendlogData_Result.StepName;
                abendLogData.ProgramName = GetAbendlogData_Result.ProgramName;
                abendLogData.AbendCode = GetAbendlogData_Result.AbendCode;
                abendLogData.AbendDescription = GetAbendlogData_Result.AbendDescription;
                abendLogData.AbendDate = GetAbendlogData_Result.AbendDate;
                abendLogData.AbendTime = GetAbendlogData_Result.AbendTime;
                abendLogData.RestartTime = GetAbendlogData_Result.RestartTime;
                abendLogData.OnCallAssociate = GetAbendlogData_Result.OnCallAssociate;
                abendLogData.TimeSpend = GetAbendlogData_Result.TimeSpend;
                abendLogData.RCA = GetAbendlogData_Result.RCA;
                abendLogData.Classification = GetAbendlogData_Result.Classification;
                abendLogData.SubClassification = GetAbendlogData_Result.SubClassification;
                abendLogData.Solution = GetAbendlogData_Result.Solution;
                abendLogData.ResolvedBy = GetAbendlogData_Result.ResolvedBy;
                abendLogData.ResolvedDate = GetAbendlogData_Result.ResolvedDate;
                abendLogData.CallFromEnsono = GetAbendlogData_Result.CallFromEnsono;
                abendLogData.LevelTimeForEscalation = GetAbendlogData_Result.LevelTimeForEscalation;
                abendLogData.EscalatedDate = GetAbendlogData_Result.EscalatedDate;
                abendLogData.Status = GetAbendlogData_Result.Status;
                abendLogData.Comments = GetAbendlogData_Result.Comments;
                abendLogData.SLABreach = GetAbendlogData_Result.SLABreach;
                abendLogData.Createdby = GetAbendlogData_Result.Createdby;
                abendLogData.CreatedDate = GetAbendlogData_Result.CreatedDate;
                abendLogData.Modifiedby = GetAbendlogData_Result.Modifiedby;
                abendLogData.ModifiedDate = GetAbendlogData_Result.ModifiedDate;
                abendLogData.PermanentFix = GetAbendlogData_Result.PermanentFix;

                lstAbendLogData.Add(abendLogData);
            }

            return lstAbendLogData;
        }

        /// <summary>
        /// Adding the Abend Log based on the data entered by Users
        /// </summary>
        /// <param name="abendLog">Data of the abend in the model format</param>
        public void AddAbendLog(BusinessAccess.Model.AbendLogData abendLog)
        {
            try
            {
                DBEntities.p_InsertAbendLogData(abendLog.IncidentNumber, abendLog.Team, abendLog.Region, abendLog.JobName,
                    abendLog.StepName, abendLog.ProgramName, abendLog.AbendCode, abendLog.AbendDescription,
                    abendLog.AbendDate, abendLog.AbendTime, abendLog.RestartTime, abendLog.OnCallAssociate,
                    abendLog.TimeSpend, abendLog.RCA, abendLog.Classification, abendLog.SubClassification,
                    abendLog.Solution, abendLog.ResolvedBy, abendLog.ResolvedDate,
                    abendLog.CallFromEnsono, abendLog.LevelTimeForEscalation,
                     abendLog.EscalatedDate, abendLog.Status,
                    abendLog.Comments, string.IsNullOrEmpty(abendLog.SLABreach) ? string.Empty:abendLog.SLABreach,  abendLog.Createdby,
                    DateTime.Now, null, null, abendLog.PermanentFix);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private System.DateTime GETDATE()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Updating the Abend Log based on the data entered by Users
        /// </summary>
        /// <param name="abendLog">Data of the abend in the model format</param>
        public void UpdateAbendLog(BusinessAccess.Model.AbendLogData abendLogData)
        {
            try
            {
                var abendLog = DBEntities.AbendLogs.Where(a => a.ID == abendLogData.ID).FirstOrDefault();
                abendLog.IncidentNumber = abendLogData.IncidentNumber;
                abendLog.Region = abendLogData.Region;
                abendLog.Team = abendLogData.Team;
                abendLog.JobName = abendLogData.JobName;
                abendLog.StepName = abendLogData.StepName;
                abendLog.ProgramName = abendLogData.ProgramName;
                abendLog.AbendCode = abendLogData.AbendCode;
                abendLog.AbendDescription = abendLogData.AbendDescription;
                abendLog.AbendDate = abendLogData.AbendDate;
                abendLog.AbendTime = abendLogData.AbendTime;
                abendLog.RestartTime = abendLogData.RestartTime;
                abendLog.OnCallAssociate = abendLogData.OnCallAssociate;
                abendLog.TimeSpend = abendLogData.TimeSpend;
                abendLog.RCA = abendLogData.RCA;
                abendLog.Classification = abendLogData.Classification;
                abendLog.Solution = abendLogData.Solution;
                abendLog.ResolvedBy = abendLogData.ResolvedBy;
                abendLog.ResolvedDate = abendLogData.ResolvedDate;
                abendLog.CallFromEnsono = abendLogData.CallFromEnsono;
                abendLog.LevelTimeForEscalation = abendLogData.LevelTimeForEscalation;
                abendLog.EscalatedDate = abendLogData.EscalatedDate;
                abendLog.Status = abendLogData.Status;
                abendLog.Comments = abendLogData.Comments;
                abendLog.SLABreach = string.IsNullOrEmpty(abendLogData.SLABreach)?string.Empty:abendLogData.SLABreach;
                abendLog.Modifiedby = abendLogData.Modifiedby;
                abendLog.ModifiedDate = DateTime.Now;
                abendLog.PermanentFix = abendLogData.PermanentFix;
                DBEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public string DownloadFileDetails(int documentId,out int abendlogId)
        {
            abendlogId = 0;
            try
            {
                
               var documentDetails = DBEntities.DocumentManagements.Where(a => a.DocumentId == documentId).FirstOrDefault();
               
                if (documentDetails != null)
                {
                    abendlogId = documentDetails.AbendId;
                    
                    return documentDetails.DocumentName;
                }
            }
            catch (Exception ex)
            {

            }
            return string.Empty;
        }

        public int AddDocument(int AbendId, string DocumentName, string DocumentPath, string UploadedBy)
        {
            try
            {
                DataAccess.DocumentManagement document = new DataAccess.DocumentManagement();
                
                document.AbendId = AbendId;
                document.DocumentName = DocumentName;
                document.DocumentPath = DocumentPath;
                document.UploadedBy = UploadedBy;
                document.UploadedDate = DateTime.Now;
                DBEntities.DocumentManagements.Add(document);
                DBEntities.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<Model.DocumentManagement> GetDocuments(int AbendId)
        {
            try
            {
                List<Model.DocumentManagement> lstDocument = new List<Model.DocumentManagement>();

                foreach (var doc in DBEntities.DocumentManagements.Where(a => a.AbendId == AbendId).ToList())
                {
                    Model.DocumentManagement document = new Model.DocumentManagement();
                    document.DocumentId = doc.DocumentId;
                    document.AbendId = doc.AbendId;
                    document.DocumentName = doc.DocumentName;
                    document.DocumentPath = doc.DocumentPath;
                    document.UploadedBy = doc.UploadedBy;
                    lstDocument.Add(document);
                }
                return lstDocument;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public string DeleteDocument(int documentId)
        {
            try
            {

                var documentDetails = DBEntities.DocumentManagements.Where(a => a.DocumentId == documentId).FirstOrDefault();

                if (documentDetails != null)
                {
                    DBEntities.DocumentManagements.Remove(documentDetails);
                    DBEntities.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return string.Empty;
        }

        public bool AddExcelData(DataTable dataTable,string lanid)
        {
            bool output = false;
            try
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    var abendLogCount = DBEntities.p_GetAbendlogData(null, null, null, null, null, null, null, null, null, null);
                    if (abendLogCount.Where(a => a.IncidentNumber == item[0].ToString()).Count() == 0)
                    {
                        DataAccess.AbendLog abendLog = new DataAccess.AbendLog();
                        abendLog.IncidentNumber = item[0].ToString();
                        abendLog.Region = item[1].ToString();
                        abendLog.Team = item[2].ToString();
                        abendLog.JobName = item[3].ToString();
                        abendLog.StepName = item[4].ToString();
                        abendLog.ProgramName = item[5].ToString();
                        abendLog.AbendCode = item[6].ToString();
                        abendLog.AbendDescription = item[7].ToString();
                        abendLog.AbendDate = Convert.ToDateTime(item[8].ToString());
                        abendLog.AbendTime = item[9].ToString();
                        abendLog.RestartTime = item[10].ToString();
                        abendLog.OnCallAssociate = item[11].ToString();
                        abendLog.TimeSpend = item[12].ToString();
                        abendLog.RCA = item[13].ToString();
                        abendLog.Classification = item[14].ToString();
                        abendLog.SubClassification = item[15].ToString();
                        abendLog.Solution = item[16].ToString();
                        abendLog.ResolvedBy = item[17].ToString();
                        abendLog.ResolvedDate = Convert.ToDateTime(item[18].ToString());
                        abendLog.CallFromEnsono = item[19].ToString();
                        abendLog.LevelTimeForEscalation = item[20].ToString();
                        if (!string.IsNullOrEmpty(item[21].ToString()) && item[21].ToString().ToUpper()!="NULL")
                            abendLog.EscalatedDate = Convert.ToDateTime(item[21].ToString());
                        abendLog.Status = item[22].ToString();
                        abendLog.Comments = item[23].ToString();
                        abendLog.SLABreach = item[24].ToString();
                        abendLog.Createdby = lanid.ToString();
                        abendLog.CreatedDate = DateTime.Now;
                        abendLog.PermanentFix = false;
                        DBEntities.AbendLogs.Add(abendLog);
                        DBEntities.SaveChanges();
                    }
                }
                output = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return output;
        }
    }
}
