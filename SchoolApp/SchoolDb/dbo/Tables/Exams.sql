CREATE TABLE [dbo].[Exams] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [ExamDate]           DATETIME        NULL,
    [MaximumMarks]       DECIMAL (18, 2) NOT NULL,
    [Weightage]          DECIMAL (18, 2) NOT NULL,
    [CreatedDate]        DATETIME        NOT NULL,
    [ModifiedDate]       DATETIME        NULL,
    [DeletedDate]        DATETIME        NULL,
    [Name]               NVARCHAR (MAX)  NULL,
    [AssesmentSchema_Id] INT             NOT NULL,
    [Subject_Id]         INT             NOT NULL,
    CONSTRAINT [PK_dbo.Exams] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Exams_dbo.AssessmentSchemas_AssesmentSchema_Id] FOREIGN KEY ([AssesmentSchema_Id]) REFERENCES [dbo].[AssessmentSchemas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Exams_dbo.Subjects_Subject_Id] FOREIGN KEY ([Subject_Id]) REFERENCES [dbo].[Subjects] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AssesmentSchema_Id]
    ON [dbo].[Exams]([AssesmentSchema_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Subject_Id]
    ON [dbo].[Exams]([Subject_Id] ASC);

