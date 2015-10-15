CREATE TABLE [dbo].[ExamResults] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Marks]        DECIMAL (18, 2) NOT NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [ModifiedDate] DATETIME        NULL,
    [DeletedDate]  DATETIME        NULL,
    [Remarks]      NVARCHAR (MAX)  NULL,
    [ApprovedBy]   SMALLINT        NULL,
    [Exam_Id]      INT             NOT NULL,
    [Student_Id]   INT             NOT NULL,
    CONSTRAINT [PK_dbo.ExamResults] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExamResults_dbo.Exams_Exam_Id] FOREIGN KEY ([Exam_Id]) REFERENCES [dbo].[Exams] ([Id]),
    CONSTRAINT [FK_dbo.ExamResults_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Exam_Id]
    ON [dbo].[ExamResults]([Exam_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[ExamResults]([Student_Id] ASC);

