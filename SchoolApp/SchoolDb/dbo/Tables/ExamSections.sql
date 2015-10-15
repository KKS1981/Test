CREATE TABLE [dbo].[ExamSections] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Exam_Id]         INT             NOT NULL,
    [ExamSectionName] NVARCHAR (MAX)  NOT NULL,
    [MaxMarks]        DECIMAL (18, 2) NOT NULL,
    [CreatedDate]     DATETIME        NOT NULL,
    [ModifiedDate]    DATETIME        NULL,
    [DeletedDate]     DATETIME        NULL,
    CONSTRAINT [PK_dbo.ExamSections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExamSections_dbo.Exams_Exam_Id] FOREIGN KEY ([Exam_Id]) REFERENCES [dbo].[Exams] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Exam_Id]
    ON [dbo].[ExamSections]([Exam_Id] ASC);

