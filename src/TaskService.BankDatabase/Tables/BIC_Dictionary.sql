CREATE TABLE [dbo].[BIC_Dictionary]
(
	[BIC]				DECIMAL(15)			NOT NULL,
	[NameP]				VARCHAR(100)		NOT NULL,
	[EnglName]			VARCHAR(100)		NOT NULL,
	[CntrCd]			VARCHAR(10)			NOT NULL,
	[Rgn]				INT					NULL,
	[Ind]				DECIMAL(10)			NULL,
	[Tnp]				VARCHAR(5)			NULL,
	[Nnp]				VARCHAR(30)			NOT NULL,
	[Adr]				VARCHAR(30)			NOT NULL,
	[DateIn]			DATE				NULL,
	[DateOut]			DATE				NULL,
	[PtType]			INT					NULL,
	[Srvcs]				INT					NULL,
	[XchType]			INT					NULL,
	[UID]				DECIMAL(10)			NULL,
	[ParticipantStatus]	VARCHAR(10)			NULL,
	[Account]			DECIMAL(20)			NULL,
	[RegulationAccType]	VARCHAR(10)			NULL,
	[AccountCBRBIC]		DECIMAL(12)			NULL,
	[UURSDate]			DATE				NULL,
	[LWRSDate]			DATE				NULL,
	[BusinessDay]		DATE				NOT NULL,
	[UpdateDay]			DATE				NOT NULL,
	[IsLicenseValid]	BIT					NOT NULL

)
