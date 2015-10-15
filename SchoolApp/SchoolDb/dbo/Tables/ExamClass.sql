CREATE TABLE [dbo].[ExamClass] (
    [Classes_Id] INT NOT NULL,
    [Exams_Id]   INT NOT NULL,
    CONSTRAINT [PK_dbo.ExamClass] PRIMARY KEY CLUSTERED ([Classes_Id] ASC, [Exams_Id] ASC),
    CONSTRAINT [FK_dbo.ExamClass_dbo.Classes_Classes_Id] FOREIGN KEY ([Classes_Id]) REFERENCES [dbo].[Classes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ExamClass_dbo.Exams_Exams_Id] FOREIGN KEY ([Exams_Id]) REFERENCES [dbo].[Exams] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Classes_Id]
    ON [dbo].[ExamClass]([Classes_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Exams_Id]
    ON [dbo].[ExamClass]([Exams_Id] ASC);

