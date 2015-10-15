CREATE TABLE [dbo].[ClassSubject] (
    [Classes_Id]  INT NOT NULL,
    [Subjects_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.ClassSubject] PRIMARY KEY CLUSTERED ([Classes_Id] ASC, [Subjects_Id] ASC),
    CONSTRAINT [FK_dbo.ClassSubject_dbo.Classes_Classes_Id] FOREIGN KEY ([Classes_Id]) REFERENCES [dbo].[Classes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ClassSubject_dbo.Subjects_Subjects_Id] FOREIGN KEY ([Subjects_Id]) REFERENCES [dbo].[Subjects] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Classes_Id]
    ON [dbo].[ClassSubject]([Classes_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Subjects_Id]
    ON [dbo].[ClassSubject]([Subjects_Id] ASC);

