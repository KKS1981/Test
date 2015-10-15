CREATE TABLE [dbo].[ActivityGradingSchemas] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [LowMarks]     DECIMAL (18, 2) NOT NULL,
    [HighMarks]    DECIMAL (18, 2) NOT NULL,
    [Grade]        NVARCHAR (MAX)  NULL,
    [GradePoint]   DECIMAL (18, 2) NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [ModifiedDate] DATETIME        NULL,
    [DeletedDate]  DATETIME        NULL,
    CONSTRAINT [PK_dbo.ActivityGradingSchemas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

