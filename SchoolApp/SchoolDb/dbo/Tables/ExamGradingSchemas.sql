CREATE TABLE [dbo].[ExamGradingSchemas] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [LowMarks]     DECIMAL (18, 2) NOT NULL,
    [HighMarks]    DECIMAL (18, 2) NOT NULL,
    [Grade]        NVARCHAR (MAX)  NULL,
    [GradePoint]   DECIMAL (18, 2) NULL,
    [GradeType]    INT             NOT NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [ModifiedDate] DATETIME        NULL,
    [DeletedDate]  DATETIME        NULL,
    CONSTRAINT [PK_dbo.ExamGradingSchemas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

