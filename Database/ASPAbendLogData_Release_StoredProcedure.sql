USE ASPAbendLogData
GO


IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_LoginCredentials')
BEGIN
 DROP PROCEDURE [dbo].[p_LoginCredentials]
END
GO

CREATE PROCEDURE [dbo].[p_LoginCredentials]
(
@LANID NVARCHAR(10),
@PASSWORD NVARCHAR(20))
AS
BEGIN
	SELECT ID,Name,LANID,EmailID,UserType FROM Users
	WHERE LANID=@LANID and PASSWORD = @PASSWORD and Active = 1
END
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_GetAbendlogData')
BEGIN
 DROP PROCEDURE [dbo].[p_GetAbendlogData]
END
GO

CREATE PROCEDURE [dbo].[p_GetAbendlogData]
(
	@IncidentNumber VARCHAR(100) = NULL,
	@JobName VARCHAR (100) = NULL,
	@StepName VARCHAR (100) = NULL,
	@AbendCode VARCHAR(100) = NULL,
	@Classification NVARCHAR (max) = NULL,
	@Team NVARCHAR(100) = NULL,
	@Region NVARCHAR (100)=NUll,
	@RCA NVARCHAR (Max)=NUll,
	@AbendCreatedDate DateTime = NULL,
	@AbendEndDate DateTime = NULL
)
AS
BEGIN

 IF (@IncidentNumber IS NULL OR RTRIM(LTRIM(@IncidentNumber)) = '' )
      SET @IncidentNumber = NULL; 
 IF (@JobName IS NULL OR RTRIM(LTRIM(@JobName)) = '' )
      SET @JobName = NULL; 
 IF (@StepName IS NULL OR RTRIM(LTRIM(@StepName)) = '' )
      SET @StepName = NULL; 
 IF (@AbendCode IS NULL OR RTRIM(LTRIM(@AbendCode)) = '' )
      SET @AbendCode = NULL; 
 IF (@Classification IS NULL OR RTRIM(LTRIM(@Classification)) = '' )
      SET @Classification = NULL;  
 IF (@Region IS NULL OR RTRIM(LTRIM(@Region)) = '' )
      SET @Region = NULL; 
IF (@RCA IS NULL OR RTRIM(LTRIM(@RCA)) = '' )
      SET @RCA = NULL;
IF (@Team IS NULL OR RTRIM(LTRIM(@Team)) = '' )
      SET @Team = NULL;

SELECT[ID] ,[IncidentNumber],[Region],[Team],[JobName],[StepName],[ProgramName] ,[AbendCode]
      ,[AbendDescription]      ,[AbendDate]      ,[AbendTime]      ,[RestartTime]      ,[OnCallAssociate]      ,[TimeSpend]  
	   ,[RCA]      ,[Classification]      ,[SubClassification] ,[Solution]          ,[ResolvedBy]      ,[ResolvedDate]      ,[CallFromEnsono]      
      ,[LevelTimeForEscalation]                 ,[EscalatedDate]      ,[Status]
      ,[Comments],[SLABreach],[Createdby],[CreatedDate],[Modifiedby],[ModifiedDate] ,[PermanentFix] FROM [dbo].AbendLog
WHERE (IncidentNumber = ISNULL(@IncidentNumber, IncidentNumber) OR @IncidentNumber IS NULL) AND
(JobName = ISNULL(@JobName, JobName) OR @JobName IS NULL) AND
(StepName = ISNULL(@StepName, StepName) OR @StepName IS NULL) AND
(AbendCode LIKE '%'+  ISNULL(@AbendCode, AbendCode) +'%' OR @AbendCode IS NULL) AND
(Classification = ISNULL(@Classification, Classification) OR @Classification IS NULL) AND
(Region = ISNULL(@Region, Region) OR @Region IS NULL) AND
(Team = ISNULL(@Team, Team) OR @Team IS NULL) AND
(RCA = ISNULL(@RCA, RCA) OR @RCA IS NULL) AND
(CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, AbendDate)))  >= CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, @AbendCreatedDate)))  OR @AbendCreatedDate IS NULL) AND
(CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, AbendDate)))  <= CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, @AbendEndDate)))  OR @AbendEndDate IS NULL)
END
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_InsertAbendLogData')
BEGIN
 DROP PROCEDURE [dbo].[p_InsertAbendLogData]
END
GO

CREATE PROCEDURE [dbo].[p_InsertAbendLogData](@IncidentNumber varchar(100),@Team NVARCHAR(200),@Region varchar (100),@JobName varchar (100),@StepName varchar (100),@ProgramName varchar(100),@AbendCode varchar(100),@AbendDescription varchar(100),@AbendDate date,
@AbendTime nvarchar(10),@RestartTime nvarchar(10),@OnCallAssociate varchar(100),@TimeSpend varchar(100),@RCA nvarchar(max),@Classification nvarchar (max),@SubClassification nvarchar (max),@Solution varchar(100),@ResolvedBy varchar(100),
@ResolvedDate date,@CallFromEnsono varchar(100),@LevelTimeForEscalation varchar(100),@EscalatedDate date,
@Status varchar(100),@Comments nvarchar(max),@SLABreach varchar(100),@Createdby varchar(100),@CreatedDate date,@Modifiedby varchar(100),@ModifiedDate date,@PermanentFix bit)
as
begin
insert into AbendLog(IncidentNumber,Region,Team,JobName,StepName,ProgramName,AbendCode,AbendDescription,AbendDate,AbendTime,RestartTime,OnCallAssociate,TimeSpend,RCA,Classification,SubClassification,Solution,ResolvedBy,ResolvedDate,CallFromEnsono,LevelTimeForEscalation
,EscalatedDate,Status,Comments,SLABreach,Createdby,CreatedDate,Modifiedby,ModifiedDate,PermanentFix)
values (@IncidentNumber,@Region,@Team,@JobName,@StepName,@ProgramName,@AbendCode,@AbendDescription,@AbendDate,@AbendTime,@RestartTime,@OnCallAssociate,@TimeSpend,@RCA,@Classification,@SubClassification,@Solution,@ResolvedBy,@ResolvedDate,@CallFromEnsono,@LevelTimeForEscalation,@EscalatedDate,@Status,@Comments,@SLABreach,@Createdby,@CreatedDate,@Modifiedby,@ModifiedDate,@PermanentFix)
END
GO



IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_UpdateAbendlogData')
BEGIN
 DROP PROCEDURE [dbo].[p_UpdateAbendlogData]
END
GO


CREATE PROCEDURE [dbo].[p_UpdateAbendlogData](@ID int,@IncidentNumber varchar(100),@Region varchar (100),@Team NVARCHAR(200),@JobName varchar (100),@StepName varchar (100),@ProgramName varchar(100),@AbendCode varchar(100),@AbendDescription varchar(100),@AbendDate date,
@AbendTime time,@RestartTime time,@OnCallAssociate varchar(100),@TimeSpend varchar(100),@RCA nvarchar(max),@Classification nvarchar (max),@SubClassification NVARCHAR (MAX),@Solution varchar(100),@ResolvedBy varchar(100),
@ResolvedDate date,@CallFromEnsono varchar(100),@LevelTimeForEscalation varchar(100),@EscalatedDate date,
@Status varchar(100),@Comments nvarchar(max),@SLABreach varchar(100),@Createdby varchar(100),@CreatedDate date,@Modifiedby varchar(100),@ModifiedDate date,@PermanentFix bit)
AS
BEGIN
UPDATE AbendLog set IncidentNumber=@IncidentNumber,Region=@Region,Team =@Team,StepName=@StepName,ProgramName=@ProgramName,AbendCode=@AbendCode,AbendDescription=@AbendDescription,AbendDate=@AbendDate,AbendTime=@AbendTime,
RestartTime=@RestartTime,OnCallAssociate=@OnCallAssociate,TimeSpend=@TimeSpend,RCA=@RCA,Classification=@Classification,SubClassification=@SubClassification,Solution=@Solution,ResolvedBy=@ResolvedBy,ResolvedDate=@ResolvedDate,CallFromEnsono=@CallFromEnsono,
LevelTimeForEscalation=@LevelTimeForEscalation,EscalatedDate=@EscalatedDate,Status=@Status,Comments=@Comments,SLABreach=@SLABreach,
Createdby=@Createdby,CreatedDate=@CreatedDate,Modifiedby=@Modifiedby,ModifiedDate=@ModifiedDate,PermanentFix=@PermanentFix
WHERE id=@ID
END
GO

--Ends Here

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_GetPermanentFixData')
BEGIN
 DROP PROCEDURE [dbo].[p_GetPermanentFixData]
END
GO
CREATE PROCEDURE [dbo].[p_GetPermanentFixData]
(
	@IncidentNumber VARCHAR(100) =  NULL,	
	@Comments NVARCHAR(100) =  NULL,	
	@RCA NVARCHAR (Max)=NUll,
	@CreatedBy VARCHAR(100)=NULL,	
	@PFCreatedDate DateTime = NULL,
	@PFEndDate DateTime = NULL
	
)
AS
BEGIN

 IF (@IncidentNumber IS NULL OR RTRIM(LTRIM(@IncidentNumber)) = '' )
      SET @IncidentNumber = NULL; 
 IF (@Comments IS NULL OR RTRIM(LTRIM(@Comments)) = '' )
      SET @Comments = NULL; 
IF (@RCA IS NULL OR RTRIM(LTRIM(@RCA)) = '' )
      SET @RCA = NULL;
 IF (@CreatedBy IS NULL OR RTRIM(LTRIM(@CreatedBy)) = '' )
      SET @CreatedBy = NULL; 
   


SELECT[ID] ,[IncidentNumber],[RCA],[TemporarilyResolution],[ProposedPermanentFix],[ComponentFixed],[FixStatus] ,[StartDate]
      ,[EndDate]      ,[Comments]      ,[Resources]      ,[Reviewer]      ,[Issues]      ,[Team]  
	   ,[ApprovalForTheProposal]      ,[CreatedBy]      ,[CreatedDate] ,[ModifiedBy]          ,[ModifiedDate]               
       FROM [dbo].PermanentFix
WHERE (IncidentNumber = ISNULL(@IncidentNumber, IncidentNumber) OR @IncidentNumber IS NULL) AND
(Comments = ISNULL(@Comments, Comments) OR @Comments IS NULL) AND
(CreatedBy = ISNULL(@CreatedBy, CreatedBy) OR @CreatedBy IS NULL) AND
(RCA = ISNULL(@RCA, RCA) OR @RCA IS NULL) AND
(CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, CreatedDate)))  >= CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, @PFCreatedDate)))  OR @PFCreatedDate IS NULL) AND
(CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, CreatedDate)))  <= CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, @PFEndDate)))  OR @PFEndDate IS NULL)
END
GO


IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_GetPermanentFixDataWithId')
BEGIN
 DROP PROCEDURE [dbo].[p_GetPermanentFixDataWithId]
END
GO

CREATE PROCEDURE [dbo].[p_GetPermanentFixDataWithId](@ID int)
AS
BEGIN
SELECT [ID]
      ,[IncidentNumber]
      ,[RCA]
	  ,[TemporarilyResolution]
	  ,[ProposedPermanentFix]
	  ,[ComponentFixed]
	  ,[FixStatus]
	  ,[StartDate]
	  ,[EndDate]
	  ,[Comments]
	  ,[Resources]
	  ,[Reviewer]
	  ,[Issues]
	  ,[Team]
	  ,[ApprovalForTheProposal]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate] FROM [dbo].PermanentFix WHERE ID = @ID
END
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_InsertPermanentFixData')
BEGIN
 DROP PROCEDURE [dbo].[p_InsertPermanentFixData]
END
GO

CREATE PROCEDURE [dbo].[p_InsertPermanentFixData]
(
	@IncidentNumber varchar(100),@RCA nvarchar(max),
	@TemporarilyResolution NVARCHAR(MAX),
	@ProposedPermanentFix NVARCHAR(MAX),
	@ComponentFixed NVARCHAR(MAX),
	@FixStatus NVARCHAR(MAX),
	@StartDate DATE,
	@EndDate DATE,
	@Comments NVARCHAR (MAX),
	@Resources NVARCHAR (MAX) ,
	@Reviewer NVARCHAR (MAX) ,
	@Issues NVARCHAR (MAX),
	@Team NVARCHAR(20),
	@ApprovalForTheProposal NVARCHAR(MAX),
	@CreatedBy varchar(100),
	@CreatedDate date,
	@ModifiedBy varchar(100),
	@ModifiedDate date
)
AS
BEGIN
INSERT INTO PermanentFix (IncidentNumber,RCA,TemporarilyResolution,ProposedPermanentFix,ComponentFixed,FixStatus,StartDate,EndDate,Comments,Resources,Reviewer,
Issues,Team,ApprovalForTheProposal,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) values (@IncidentNumber,@RCA,@TemporarilyResolution,@ProposedPermanentFix,@ComponentFixed,
@FixStatus,@StartDate,@EndDate,@Comments,@Resources,@Reviewer,@Issues,@Team,@ApprovalForTheProposal,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate)
END
GO



IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_UpdatePermanentFixDate')
BEGIN
 DROP PROCEDURE [dbo].[p_UpdatePermanentFixDate]
END
GO

CREATE PROCEDURE [dbo].[p_UpdatePermanentFixDate](@ID int,@IncidentNumber varchar(100),@RCA nvarchar(max),@TemporarilyResolution NVARCHAR(MAX),
@ProposedPermanentFix NVARCHAR(MAX),
@ComponentFixed NVARCHAR(MAX),
@FixStatus NVARCHAR(MAX),
@StartDate DATE,
@EndDate DATE,
@Comments NVARCHAR (MAX),
@Resources NVARCHAR (MAX) ,
@Reviewer NVARCHAR (MAX) ,
@Issues NVARCHAR (MAX),
@Team NVARCHAR(20),
@ApprovalForTheProposal NVARCHAR(MAX),@CreatedBy varchar(100),@CreatedDate date,@ModifiedBy varchar(100),@ModifiedDate date)
AS
BEGIN
UPDATE PermanentFix set IncidentNumber=@IncidentNumber,RCA=@RCA,TemporarilyResolution=@TemporarilyResolution,ProposedPermanentFix=@ProposedPermanentFix
,ComponentFixed=@ComponentFixed,FixStatus=@FixStatus,StartDate=@StartDate,EndDate=@EndDate,Comments=@Comments,Resources=@Resources,Reviewer=@Reviewer
,Issues=@Issues,Team=@Team,ApprovalForTheProposal=@ApprovalForTheProposal,CreatedBy=@CreatedBy,CreatedDate=@CreatedDate,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate
WHERE ID=@ID
END
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_GetUserData')
BEGIN
 DROP PROCEDURE [dbo].[p_GetUserData]
END
GO

CREATE PROCEDURE [dbo].[p_GetUserData]
(
	@LANID VARCHAR(10) = NULL,
	@EmailID VARCHAR (100) = NULL
	
)
AS
BEGIN

 IF (@LANID IS NULL OR RTRIM(LTRIM(@LANID)) = '' )
      SET @LANID = NULL; 
 IF (@EmailID IS NULL OR RTRIM(LTRIM(@EmailID)) = '' )
      SET @EmailID = NULL; 
 

SELECT[ID] ,	[Name], 	[EmailID] ,	[LANID] ,	[Password] ,	[CreatedBy] ,	[CreatedDate] ,	[ModifiedBy] ,	[ModifiedDate] ,	[Active]  FROM [dbo].Users
WHERE (LANID = ISNULL(@LANID, LANID) OR @LANID IS NULL) AND
(EmailID = ISNULL(@EmailID, EmailID) OR @EmailID IS NULL) 

END
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_InsertUserData')
BEGIN
 DROP PROCEDURE [dbo].[p_InsertUserData]
END
GO

CREATE PROCEDURE [dbo].[p_InsertUserData](@Name varchar(100),@EmailID NVARCHAR(200),@LANID nvarchar (10),@Password nvarchar (20),@CreatedBy varchar (100),@CreatedDate datetime,@ModifiedBy varchar(100),@ModifiedDate datetime,@Active bit)
AS
BEGIN
INSERT INTO Users(Name,EmailID,LANID,Password,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active)
VALUES (@Name,@EmailID,@LANID,@Password,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate,@Active)
END
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [Name]='p_UpdateUserData')
BEGIN
 DROP PROCEDURE [dbo].[p_UpdateUserData]
END
GO


CREATE PROCEDURE [dbo].[p_UpdateUserData](@ID int,@Name varchar(100),@EmailID NVARCHAR(200),@LANID nvarchar (10),@Password nvarchar (20),@CreatedBy varchar (100),@CreatedDate datetime,@ModifiedBy varchar(100),@ModifiedDate datetime,@Active bit)
AS
BEGIN
UPDATE Users set Name=@Name,EmailID=@EmailID,LANID =@LANID,Password=@Password,CreatedBy=@CreatedBy,CreatedDate=@CreatedDate,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate,Active=@Active
WHERE id=@ID
END
GO




