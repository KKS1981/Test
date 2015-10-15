CREATE TABLE [dbo].[Student_Ignored_Activities] (
    [StudentId]  INT NOT NULL,
    [ActivityId] INT NOT NULL,
    CONSTRAINT [PK_dbo.Student_Ignored_Activities] PRIMARY KEY CLUSTERED ([StudentId] ASC, [ActivityId] ASC),
    CONSTRAINT [FK_dbo.Student_Ignored_Activities_dbo.Activities_ActivityId] FOREIGN KEY ([ActivityId]) REFERENCES [dbo].[Activities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Student_Ignored_Activities_dbo.Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentId]
    ON [dbo].[Student_Ignored_Activities]([StudentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ActivityId]
    ON [dbo].[Student_Ignored_Activities]([ActivityId] ASC);

