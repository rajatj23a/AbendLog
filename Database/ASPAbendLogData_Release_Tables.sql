IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE [Name] ='ASPAbendLogData')
BEGIN
	CREATE DATABASE ASPAbendLogData
END
GO
USE ASPAbendLogData
GO

IF NOT EXISTS (SELECT*FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME='Users')
BEGIN

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL ,
	[Name] [varchar](100)  NULL,
	[EmailID] [nvarchar](100)  NULL,
	[LANID] [nvarchar](10)  NULL,
	[Password] [nvarchar](20)  NULL,
	[CreatedBy] [varchar](100)  NULL,
	[CreatedDate] [datetime]  NULL,
	[ModifiedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[UserType] [nvarchar](20)  NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Active]
ALTER TABLE [dbo].[Users] ADD  DEFAULT (('AppUser')) FOR [UserType]
END
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME='AbendLog')
BEGIN
CREATE TABLE [dbo].[AbendLog](
	[ID] [int] IDENTITY(1,1)  NOT NULL,
	[IncidentNumber] [varchar](255) NULL,
	[Region] [varchar](255) NULL,
	[Team] [nvarchar](255) NULL,
	[JobName] [varchar](255) NULL,
	[StepName] [varchar](255) NULL,
	[ProgramName] [varchar](255) NULL,
	[AbendCode] [varchar](255) NOT NULL,
	[AbendDescription] [varchar](max) NULL,
	[AbendDate] [datetime] NULL,
	[AbendTime] [nvarchar](255) NULL,
	[RestartTime] [nvarchar](255) NULL,
	[OnCallAssociate] [varchar](255) NULL,
	[TimeSpend] [varchar](255) NULL,
	[RCA] [nvarchar](max) NULL,
	[Classification] [nvarchar](max) NULL,
	[SubClassification] [nvarchar](max) NULL,
	[Solution] [varchar](max) NULL,
	[ResolvedBy] [varchar](255) NULL,
	[ResolvedDate] [datetime] NULL,
	[CallFromEnsono] [varchar](255) NULL,
	[LevelTimeForEscalation] [varchar](255) NULL,
	[EscalatedDate] [datetime] NULL,
	[Status] [varchar](255) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[SLABreach] [varchar](255) NULL,
	[Createdby] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Modifiedby] [varchar](255) NULL,
	[ModifiedDate] [datetime] NULL,
	[PermanentFix] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END 
GO

IF NOT EXISTS (SELECT*FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME='PermanentFix')
BEGIN

CREATE TABLE [dbo].[PermanentFix](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentNumber] [varchar](100)  NULL,
	[RCA] [nvarchar](max) NULL,
	[TemporarilyResolution] [nvarchar](max)  NULL,
	[ProposedPermanentFix] [nvarchar](max)  NULL,
	[ComponentFixed] [nvarchar](max)  NULL,
	[FixStatus] [nvarchar](max)  NULL,
	[StartDate] [datetime]  NULL,
	[EndDate] [datetime] NULL,
	[Comments] [nvarchar](max)  NULL,
	[Resources] [nvarchar](max)  NULL,
	[Reviewer] [nvarchar](max)  NULL,
	[Issues] [nvarchar](max)  NULL,
	[Team] [nvarchar](20)  NULL,
	[ApprovalForTheProposal] [nvarchar](max)  NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedDate] [datetime]  NULL,
	[ModifiedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END
GO

IF NOT EXISTS (SELECT*FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME='DocumentManagement')
BEGIN

CREATE TABLE [dbo].[DocumentManagement](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[AbendId] [int] NOT NULL,
	[DocumentName] [varchar](500) NOT NULL,
	[DocumentPath] [varchar](max) NOT NULL,
	[IsReUpload] [bit] NOT NULL,
	[UploadedBy] [varchar](100) NOT NULL,
	[UploadedDate] [datetime] NOT NULL,
	[ReuploadedBy] [varchar](100) NULL,
	[ReuploadedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[DocumentManagement] ADD  DEFAULT ((0)) FOR [IsReUpload]

END
GO

