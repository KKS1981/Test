CREATE TABLE [dbo].[TeacherActivity] (
    [Teachers_Id]   INT NOT NULL,
    [Activities_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.TeacherActivity] PRIMARY KEY CLUSTERED ([Teachers_Id] ASC, [Activities_Id] ASC),
    CONSTRAINT [FK_dbo.TeacherActivity_dbo.Activities_Activities_Id] FOREIGN KEY ([Activities_Id]) REFERENCES [dbo].[Activities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.TeacherActivity_dbo.Teachers_Teachers_Id] FOREIGN KEY ([Teachers_Id]) REFERENCES [dbo].[Teachers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Teachers_Id]
    ON [dbo].[TeacherActivity]([Teachers_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Activities_Id]
    ON [dbo].[TeacherActivity]([Activities_Id] ASC);

