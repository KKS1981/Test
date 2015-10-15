CREATE TABLE [dbo].[TeacherSubjects] (
    [Teachers_Id] INT NOT NULL,
    [Subjects_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.TeacherSubjects] PRIMARY KEY CLUSTERED ([Teachers_Id] ASC, [Subjects_Id] ASC),
    CONSTRAINT [FK_dbo.TeacherSubjects_dbo.Subjects_Subjects_Id] FOREIGN KEY ([Subjects_Id]) REFERENCES [dbo].[Subjects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.TeacherSubjects_dbo.Teachers_Teachers_Id] FOREIGN KEY ([Teachers_Id]) REFERENCES [dbo].[Teachers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Teachers_Id]
    ON [dbo].[TeacherSubjects]([Teachers_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Subjects_Id]
    ON [dbo].[TeacherSubjects]([Subjects_Id] ASC);

