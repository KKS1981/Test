CREATE TABLE [dbo].[StudentSubject] (
    [Students_Id]         INT NOT NULL,
    [OptionalSubjects_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.StudentSubject] PRIMARY KEY CLUSTERED ([Students_Id] ASC, [OptionalSubjects_Id] ASC),
    CONSTRAINT [FK_dbo.StudentSubject_dbo.Students_Students_Id] FOREIGN KEY ([Students_Id]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.StudentSubject_dbo.Subjects_OptionalSubjects_Id] FOREIGN KEY ([OptionalSubjects_Id]) REFERENCES [dbo].[Subjects] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Students_Id]
    ON [dbo].[StudentSubject]([Students_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OptionalSubjects_Id]
    ON [dbo].[StudentSubject]([OptionalSubjects_Id] ASC);

