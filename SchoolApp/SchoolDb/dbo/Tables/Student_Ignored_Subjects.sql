CREATE TABLE [dbo].[Student_Ignored_Subjects] (
    [StudentId] INT NOT NULL,
    [SubjectId] INT NOT NULL,
    CONSTRAINT [PK_dbo.Student_Ignored_Subjects] PRIMARY KEY CLUSTERED ([StudentId] ASC, [SubjectId] ASC),
    CONSTRAINT [FK_dbo.Student_Ignored_Subjects_dbo.Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Student_Ignored_Subjects_dbo.Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subjects] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentId]
    ON [dbo].[Student_Ignored_Subjects]([StudentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SubjectId]
    ON [dbo].[Student_Ignored_Subjects]([SubjectId] ASC);

