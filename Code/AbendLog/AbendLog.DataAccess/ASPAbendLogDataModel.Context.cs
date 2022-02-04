﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbendLog.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ASPAbendLogDataEntities : DbContext
    {
        public ASPAbendLogDataEntities()
            : base("name=ASPAbendLogDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DocumentManagement> DocumentManagements { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PermanentFix> PermanentFixes { get; set; }
        public virtual DbSet<AbendLog> AbendLogs { get; set; }
    
        public virtual ObjectResult<p_GetAbendlogData_Result> p_GetAbendlogData(string incidentNumber, string jobName, string stepName, string abendCode, string classification, string team, string region, string rCA, Nullable<System.DateTime> abendCreatedDate, Nullable<System.DateTime> abendEndDate)
        {
            var incidentNumberParameter = incidentNumber != null ?
                new ObjectParameter("IncidentNumber", incidentNumber) :
                new ObjectParameter("IncidentNumber", typeof(string));
    
            var jobNameParameter = jobName != null ?
                new ObjectParameter("JobName", jobName) :
                new ObjectParameter("JobName", typeof(string));
    
            var stepNameParameter = stepName != null ?
                new ObjectParameter("StepName", stepName) :
                new ObjectParameter("StepName", typeof(string));
    
            var abendCodeParameter = abendCode != null ?
                new ObjectParameter("AbendCode", abendCode) :
                new ObjectParameter("AbendCode", typeof(string));
    
            var classificationParameter = classification != null ?
                new ObjectParameter("Classification", classification) :
                new ObjectParameter("Classification", typeof(string));
    
            var teamParameter = team != null ?
                new ObjectParameter("Team", team) :
                new ObjectParameter("Team", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var rCAParameter = rCA != null ?
                new ObjectParameter("RCA", rCA) :
                new ObjectParameter("RCA", typeof(string));
    
            var abendCreatedDateParameter = abendCreatedDate.HasValue ?
                new ObjectParameter("AbendCreatedDate", abendCreatedDate) :
                new ObjectParameter("AbendCreatedDate", typeof(System.DateTime));
    
            var abendEndDateParameter = abendEndDate.HasValue ?
                new ObjectParameter("AbendEndDate", abendEndDate) :
                new ObjectParameter("AbendEndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<p_GetAbendlogData_Result>("p_GetAbendlogData", incidentNumberParameter, jobNameParameter, stepNameParameter, abendCodeParameter, classificationParameter, teamParameter, regionParameter, rCAParameter, abendCreatedDateParameter, abendEndDateParameter);
        }
    
        public virtual ObjectResult<p_GetUserData_Result> p_GetUserData(string lANID, string emailID)
        {
            var lANIDParameter = lANID != null ?
                new ObjectParameter("LANID", lANID) :
                new ObjectParameter("LANID", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<p_GetUserData_Result>("p_GetUserData", lANIDParameter, emailIDParameter);
        }
    
        public virtual int p_InsertAbendLogData(string incidentNumber, string team, string region, string jobName, string stepName, string programName, string abendCode, string abendDescription, Nullable<System.DateTime> abendDate, string abendTime, string restartTime, string onCallAssociate, string timeSpend, string rCA, string classification, string subClassification, string solution, string resolvedBy, Nullable<System.DateTime> resolvedDate, string callFromEnsono, string levelTimeForEscalation, Nullable<System.DateTime> escalatedDate, string status, string comments, string sLABreach, string createdby, Nullable<System.DateTime> createdDate, string modifiedby, Nullable<System.DateTime> modifiedDate, Nullable<bool> permanentFix)
        {
            var incidentNumberParameter = incidentNumber != null ?
                new ObjectParameter("IncidentNumber", incidentNumber) :
                new ObjectParameter("IncidentNumber", typeof(string));
    
            var teamParameter = team != null ?
                new ObjectParameter("Team", team) :
                new ObjectParameter("Team", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var jobNameParameter = jobName != null ?
                new ObjectParameter("JobName", jobName) :
                new ObjectParameter("JobName", typeof(string));
    
            var stepNameParameter = stepName != null ?
                new ObjectParameter("StepName", stepName) :
                new ObjectParameter("StepName", typeof(string));
    
            var programNameParameter = programName != null ?
                new ObjectParameter("ProgramName", programName) :
                new ObjectParameter("ProgramName", typeof(string));
    
            var abendCodeParameter = abendCode != null ?
                new ObjectParameter("AbendCode", abendCode) :
                new ObjectParameter("AbendCode", typeof(string));
    
            var abendDescriptionParameter = abendDescription != null ?
                new ObjectParameter("AbendDescription", abendDescription) :
                new ObjectParameter("AbendDescription", typeof(string));
    
            var abendDateParameter = abendDate.HasValue ?
                new ObjectParameter("AbendDate", abendDate) :
                new ObjectParameter("AbendDate", typeof(System.DateTime));
    
            var abendTimeParameter = abendTime != null ?
                new ObjectParameter("AbendTime", abendTime) :
                new ObjectParameter("AbendTime", typeof(string));
    
            var restartTimeParameter = restartTime != null ?
                new ObjectParameter("RestartTime", restartTime) :
                new ObjectParameter("RestartTime", typeof(string));
    
            var onCallAssociateParameter = onCallAssociate != null ?
                new ObjectParameter("OnCallAssociate", onCallAssociate) :
                new ObjectParameter("OnCallAssociate", typeof(string));
    
            var timeSpendParameter = timeSpend != null ?
                new ObjectParameter("TimeSpend", timeSpend) :
                new ObjectParameter("TimeSpend", typeof(string));
    
            var rCAParameter = rCA != null ?
                new ObjectParameter("RCA", rCA) :
                new ObjectParameter("RCA", typeof(string));
    
            var classificationParameter = classification != null ?
                new ObjectParameter("Classification", classification) :
                new ObjectParameter("Classification", typeof(string));
    
            var subClassificationParameter = subClassification != null ?
                new ObjectParameter("SubClassification", subClassification) :
                new ObjectParameter("SubClassification", typeof(string));
    
            var solutionParameter = solution != null ?
                new ObjectParameter("Solution", solution) :
                new ObjectParameter("Solution", typeof(string));
    
            var resolvedByParameter = resolvedBy != null ?
                new ObjectParameter("ResolvedBy", resolvedBy) :
                new ObjectParameter("ResolvedBy", typeof(string));
    
            var resolvedDateParameter = resolvedDate.HasValue ?
                new ObjectParameter("ResolvedDate", resolvedDate) :
                new ObjectParameter("ResolvedDate", typeof(System.DateTime));
    
            var callFromEnsonoParameter = callFromEnsono != null ?
                new ObjectParameter("CallFromEnsono", callFromEnsono) :
                new ObjectParameter("CallFromEnsono", typeof(string));
    
            var levelTimeForEscalationParameter = levelTimeForEscalation != null ?
                new ObjectParameter("LevelTimeForEscalation", levelTimeForEscalation) :
                new ObjectParameter("LevelTimeForEscalation", typeof(string));
    
            var escalatedDateParameter = escalatedDate.HasValue ?
                new ObjectParameter("EscalatedDate", escalatedDate) :
                new ObjectParameter("EscalatedDate", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("Comments", comments) :
                new ObjectParameter("Comments", typeof(string));
    
            var sLABreachParameter = sLABreach != null ?
                new ObjectParameter("SLABreach", sLABreach) :
                new ObjectParameter("SLABreach", typeof(string));
    
            var createdbyParameter = createdby != null ?
                new ObjectParameter("Createdby", createdby) :
                new ObjectParameter("Createdby", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var modifiedbyParameter = modifiedby != null ?
                new ObjectParameter("Modifiedby", modifiedby) :
                new ObjectParameter("Modifiedby", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            var permanentFixParameter = permanentFix.HasValue ?
                new ObjectParameter("PermanentFix", permanentFix) :
                new ObjectParameter("PermanentFix", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_InsertAbendLogData", incidentNumberParameter, teamParameter, regionParameter, jobNameParameter, stepNameParameter, programNameParameter, abendCodeParameter, abendDescriptionParameter, abendDateParameter, abendTimeParameter, restartTimeParameter, onCallAssociateParameter, timeSpendParameter, rCAParameter, classificationParameter, subClassificationParameter, solutionParameter, resolvedByParameter, resolvedDateParameter, callFromEnsonoParameter, levelTimeForEscalationParameter, escalatedDateParameter, statusParameter, commentsParameter, sLABreachParameter, createdbyParameter, createdDateParameter, modifiedbyParameter, modifiedDateParameter, permanentFixParameter);
        }
    
        public virtual int p_InsertUserData(string name, string emailID, string lANID, string password, string createdBy, Nullable<System.DateTime> createdDate, string modifiedBy, Nullable<System.DateTime> modifiedDate, Nullable<bool> active)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            var lANIDParameter = lANID != null ?
                new ObjectParameter("LANID", lANID) :
                new ObjectParameter("LANID", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var modifiedByParameter = modifiedBy != null ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_InsertUserData", nameParameter, emailIDParameter, lANIDParameter, passwordParameter, createdByParameter, createdDateParameter, modifiedByParameter, modifiedDateParameter, activeParameter);
        }
    
        public virtual ObjectResult<p_LoginCredentials_Result> p_LoginCredentials(string lANID, string pASSWORD)
        {
            var lANIDParameter = lANID != null ?
                new ObjectParameter("LANID", lANID) :
                new ObjectParameter("LANID", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<p_LoginCredentials_Result>("p_LoginCredentials", lANIDParameter, pASSWORDParameter);
        }
    
        public virtual int p_UpdateAbendlogData(Nullable<int> iD, string incidentNumber, string region, string team, string jobName, string stepName, string programName, string abendCode, string abendDescription, Nullable<System.DateTime> abendDate, Nullable<System.TimeSpan> abendTime, Nullable<System.TimeSpan> restartTime, string onCallAssociate, string timeSpend, string rCA, string classification, string subClassification, string solution, string resolvedBy, Nullable<System.DateTime> resolvedDate, string callFromEnsono, string levelTimeForEscalation, Nullable<System.DateTime> escalatedDate, string status, string comments, string sLABreach, string createdby, Nullable<System.DateTime> createdDate, string modifiedby, Nullable<System.DateTime> modifiedDate, Nullable<bool> permanentFix)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var incidentNumberParameter = incidentNumber != null ?
                new ObjectParameter("IncidentNumber", incidentNumber) :
                new ObjectParameter("IncidentNumber", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var teamParameter = team != null ?
                new ObjectParameter("Team", team) :
                new ObjectParameter("Team", typeof(string));
    
            var jobNameParameter = jobName != null ?
                new ObjectParameter("JobName", jobName) :
                new ObjectParameter("JobName", typeof(string));
    
            var stepNameParameter = stepName != null ?
                new ObjectParameter("StepName", stepName) :
                new ObjectParameter("StepName", typeof(string));
    
            var programNameParameter = programName != null ?
                new ObjectParameter("ProgramName", programName) :
                new ObjectParameter("ProgramName", typeof(string));
    
            var abendCodeParameter = abendCode != null ?
                new ObjectParameter("AbendCode", abendCode) :
                new ObjectParameter("AbendCode", typeof(string));
    
            var abendDescriptionParameter = abendDescription != null ?
                new ObjectParameter("AbendDescription", abendDescription) :
                new ObjectParameter("AbendDescription", typeof(string));
    
            var abendDateParameter = abendDate.HasValue ?
                new ObjectParameter("AbendDate", abendDate) :
                new ObjectParameter("AbendDate", typeof(System.DateTime));
    
            var abendTimeParameter = abendTime.HasValue ?
                new ObjectParameter("AbendTime", abendTime) :
                new ObjectParameter("AbendTime", typeof(System.TimeSpan));
    
            var restartTimeParameter = restartTime.HasValue ?
                new ObjectParameter("RestartTime", restartTime) :
                new ObjectParameter("RestartTime", typeof(System.TimeSpan));
    
            var onCallAssociateParameter = onCallAssociate != null ?
                new ObjectParameter("OnCallAssociate", onCallAssociate) :
                new ObjectParameter("OnCallAssociate", typeof(string));
    
            var timeSpendParameter = timeSpend != null ?
                new ObjectParameter("TimeSpend", timeSpend) :
                new ObjectParameter("TimeSpend", typeof(string));
    
            var rCAParameter = rCA != null ?
                new ObjectParameter("RCA", rCA) :
                new ObjectParameter("RCA", typeof(string));
    
            var classificationParameter = classification != null ?
                new ObjectParameter("Classification", classification) :
                new ObjectParameter("Classification", typeof(string));
    
            var subClassificationParameter = subClassification != null ?
                new ObjectParameter("SubClassification", subClassification) :
                new ObjectParameter("SubClassification", typeof(string));
    
            var solutionParameter = solution != null ?
                new ObjectParameter("Solution", solution) :
                new ObjectParameter("Solution", typeof(string));
    
            var resolvedByParameter = resolvedBy != null ?
                new ObjectParameter("ResolvedBy", resolvedBy) :
                new ObjectParameter("ResolvedBy", typeof(string));
    
            var resolvedDateParameter = resolvedDate.HasValue ?
                new ObjectParameter("ResolvedDate", resolvedDate) :
                new ObjectParameter("ResolvedDate", typeof(System.DateTime));
    
            var callFromEnsonoParameter = callFromEnsono != null ?
                new ObjectParameter("CallFromEnsono", callFromEnsono) :
                new ObjectParameter("CallFromEnsono", typeof(string));
    
            var levelTimeForEscalationParameter = levelTimeForEscalation != null ?
                new ObjectParameter("LevelTimeForEscalation", levelTimeForEscalation) :
                new ObjectParameter("LevelTimeForEscalation", typeof(string));
    
            var escalatedDateParameter = escalatedDate.HasValue ?
                new ObjectParameter("EscalatedDate", escalatedDate) :
                new ObjectParameter("EscalatedDate", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("Comments", comments) :
                new ObjectParameter("Comments", typeof(string));
    
            var sLABreachParameter = sLABreach != null ?
                new ObjectParameter("SLABreach", sLABreach) :
                new ObjectParameter("SLABreach", typeof(string));
    
            var createdbyParameter = createdby != null ?
                new ObjectParameter("Createdby", createdby) :
                new ObjectParameter("Createdby", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var modifiedbyParameter = modifiedby != null ?
                new ObjectParameter("Modifiedby", modifiedby) :
                new ObjectParameter("Modifiedby", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            var permanentFixParameter = permanentFix.HasValue ?
                new ObjectParameter("PermanentFix", permanentFix) :
                new ObjectParameter("PermanentFix", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_UpdateAbendlogData", iDParameter, incidentNumberParameter, regionParameter, teamParameter, jobNameParameter, stepNameParameter, programNameParameter, abendCodeParameter, abendDescriptionParameter, abendDateParameter, abendTimeParameter, restartTimeParameter, onCallAssociateParameter, timeSpendParameter, rCAParameter, classificationParameter, subClassificationParameter, solutionParameter, resolvedByParameter, resolvedDateParameter, callFromEnsonoParameter, levelTimeForEscalationParameter, escalatedDateParameter, statusParameter, commentsParameter, sLABreachParameter, createdbyParameter, createdDateParameter, modifiedbyParameter, modifiedDateParameter, permanentFixParameter);
        }
    
        public virtual int p_UpdateUserData(Nullable<int> iD, string name, string emailID, string lANID, string password, string createdBy, Nullable<System.DateTime> createdDate, string modifiedBy, Nullable<System.DateTime> modifiedDate, Nullable<bool> active)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            var lANIDParameter = lANID != null ?
                new ObjectParameter("LANID", lANID) :
                new ObjectParameter("LANID", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var modifiedByParameter = modifiedBy != null ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_UpdateUserData", iDParameter, nameParameter, emailIDParameter, lANIDParameter, passwordParameter, createdByParameter, createdDateParameter, modifiedByParameter, modifiedDateParameter, activeParameter);
        }
    
        public virtual ObjectResult<p_GetPermanentFixData_Result> p_GetPermanentFixData(string incidentNumber, string comments, string rCA, string createdBy, Nullable<System.DateTime> pFCreatedDate, Nullable<System.DateTime> pFEndDate)
        {
            var incidentNumberParameter = incidentNumber != null ?
                new ObjectParameter("IncidentNumber", incidentNumber) :
                new ObjectParameter("IncidentNumber", typeof(string));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("Comments", comments) :
                new ObjectParameter("Comments", typeof(string));
    
            var rCAParameter = rCA != null ?
                new ObjectParameter("RCA", rCA) :
                new ObjectParameter("RCA", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var pFCreatedDateParameter = pFCreatedDate.HasValue ?
                new ObjectParameter("PFCreatedDate", pFCreatedDate) :
                new ObjectParameter("PFCreatedDate", typeof(System.DateTime));
    
            var pFEndDateParameter = pFEndDate.HasValue ?
                new ObjectParameter("PFEndDate", pFEndDate) :
                new ObjectParameter("PFEndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<p_GetPermanentFixData_Result>("p_GetPermanentFixData", incidentNumberParameter, commentsParameter, rCAParameter, createdByParameter, pFCreatedDateParameter, pFEndDateParameter);
        }
    
        public virtual ObjectResult<p_GetPermanentFixDataWithId_Result> p_GetPermanentFixDataWithId(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<p_GetPermanentFixDataWithId_Result>("p_GetPermanentFixDataWithId", iDParameter);
        }
    
        public virtual int p_InsertPermanentFixData(string incidentNumber, string rCA, string temporarilyResolution, string proposedPermanentFix, string componentFixed, string fixStatus, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string comments, string resources, string reviewer, string issues, string team, string approvalForTheProposal, string createdBy, Nullable<System.DateTime> createdDate, string modifiedBy, Nullable<System.DateTime> modifiedDate)
        {
            var incidentNumberParameter = incidentNumber != null ?
                new ObjectParameter("IncidentNumber", incidentNumber) :
                new ObjectParameter("IncidentNumber", typeof(string));
    
            var rCAParameter = rCA != null ?
                new ObjectParameter("RCA", rCA) :
                new ObjectParameter("RCA", typeof(string));
    
            var temporarilyResolutionParameter = temporarilyResolution != null ?
                new ObjectParameter("TemporarilyResolution", temporarilyResolution) :
                new ObjectParameter("TemporarilyResolution", typeof(string));
    
            var proposedPermanentFixParameter = proposedPermanentFix != null ?
                new ObjectParameter("ProposedPermanentFix", proposedPermanentFix) :
                new ObjectParameter("ProposedPermanentFix", typeof(string));
    
            var componentFixedParameter = componentFixed != null ?
                new ObjectParameter("ComponentFixed", componentFixed) :
                new ObjectParameter("ComponentFixed", typeof(string));
    
            var fixStatusParameter = fixStatus != null ?
                new ObjectParameter("FixStatus", fixStatus) :
                new ObjectParameter("FixStatus", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("Comments", comments) :
                new ObjectParameter("Comments", typeof(string));
    
            var resourcesParameter = resources != null ?
                new ObjectParameter("Resources", resources) :
                new ObjectParameter("Resources", typeof(string));
    
            var reviewerParameter = reviewer != null ?
                new ObjectParameter("Reviewer", reviewer) :
                new ObjectParameter("Reviewer", typeof(string));
    
            var issuesParameter = issues != null ?
                new ObjectParameter("Issues", issues) :
                new ObjectParameter("Issues", typeof(string));
    
            var teamParameter = team != null ?
                new ObjectParameter("Team", team) :
                new ObjectParameter("Team", typeof(string));
    
            var approvalForTheProposalParameter = approvalForTheProposal != null ?
                new ObjectParameter("ApprovalForTheProposal", approvalForTheProposal) :
                new ObjectParameter("ApprovalForTheProposal", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var modifiedByParameter = modifiedBy != null ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_InsertPermanentFixData", incidentNumberParameter, rCAParameter, temporarilyResolutionParameter, proposedPermanentFixParameter, componentFixedParameter, fixStatusParameter, startDateParameter, endDateParameter, commentsParameter, resourcesParameter, reviewerParameter, issuesParameter, teamParameter, approvalForTheProposalParameter, createdByParameter, createdDateParameter, modifiedByParameter, modifiedDateParameter);
        }
    
        public virtual int p_UpdatePermanentFixDate(Nullable<int> iD, string incidentNumber, string rCA, string temporarilyResolution, string proposedPermanentFix, string componentFixed, string fixStatus, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string comments, string resources, string reviewer, string issues, string team, string approvalForTheProposal, string createdBy, Nullable<System.DateTime> createdDate, string modifiedBy, Nullable<System.DateTime> modifiedDate)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var incidentNumberParameter = incidentNumber != null ?
                new ObjectParameter("IncidentNumber", incidentNumber) :
                new ObjectParameter("IncidentNumber", typeof(string));
    
            var rCAParameter = rCA != null ?
                new ObjectParameter("RCA", rCA) :
                new ObjectParameter("RCA", typeof(string));
    
            var temporarilyResolutionParameter = temporarilyResolution != null ?
                new ObjectParameter("TemporarilyResolution", temporarilyResolution) :
                new ObjectParameter("TemporarilyResolution", typeof(string));
    
            var proposedPermanentFixParameter = proposedPermanentFix != null ?
                new ObjectParameter("ProposedPermanentFix", proposedPermanentFix) :
                new ObjectParameter("ProposedPermanentFix", typeof(string));
    
            var componentFixedParameter = componentFixed != null ?
                new ObjectParameter("ComponentFixed", componentFixed) :
                new ObjectParameter("ComponentFixed", typeof(string));
    
            var fixStatusParameter = fixStatus != null ?
                new ObjectParameter("FixStatus", fixStatus) :
                new ObjectParameter("FixStatus", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("Comments", comments) :
                new ObjectParameter("Comments", typeof(string));
    
            var resourcesParameter = resources != null ?
                new ObjectParameter("Resources", resources) :
                new ObjectParameter("Resources", typeof(string));
    
            var reviewerParameter = reviewer != null ?
                new ObjectParameter("Reviewer", reviewer) :
                new ObjectParameter("Reviewer", typeof(string));
    
            var issuesParameter = issues != null ?
                new ObjectParameter("Issues", issues) :
                new ObjectParameter("Issues", typeof(string));
    
            var teamParameter = team != null ?
                new ObjectParameter("Team", team) :
                new ObjectParameter("Team", typeof(string));
    
            var approvalForTheProposalParameter = approvalForTheProposal != null ?
                new ObjectParameter("ApprovalForTheProposal", approvalForTheProposal) :
                new ObjectParameter("ApprovalForTheProposal", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var modifiedByParameter = modifiedBy != null ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_UpdatePermanentFixDate", iDParameter, incidentNumberParameter, rCAParameter, temporarilyResolutionParameter, proposedPermanentFixParameter, componentFixedParameter, fixStatusParameter, startDateParameter, endDateParameter, commentsParameter, resourcesParameter, reviewerParameter, issuesParameter, teamParameter, approvalForTheProposalParameter, createdByParameter, createdDateParameter, modifiedByParameter, modifiedDateParameter);
        }
    }
}