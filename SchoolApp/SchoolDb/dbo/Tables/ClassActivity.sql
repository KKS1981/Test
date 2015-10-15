CREATE TABLE [dbo].[ClassActivity] (
    [Classes_Id]    INT NOT NULL,
    [Activities_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.ClassActivity] PRIMARY KEY CLUSTERED ([Classes_Id] ASC, [Activities_Id] ASC),
    CONSTRAINT [FK_dbo.ClassActivity_dbo.Activities_Activities_Id] FOREIGN KEY ([Activities_Id]) REFERENCES [dbo].[Activities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ClassActivity_dbo.Classes_Classes_Id] FOREIGN KEY ([Classes_Id]) REFERENCES [dbo].[Classes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Classes_Id]
    ON [dbo].[ClassActivity]([Classes_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Activities_Id]
    ON [dbo].[ClassActivity]([Activities_Id] ASC);

