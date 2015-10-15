CREATE TABLE [dbo].[StudentActivity] (
    [Students_Id]           INT NOT NULL,
    [OptionalActivities_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.StudentActivity] PRIMARY KEY CLUSTERED ([Students_Id] ASC, [OptionalActivities_Id] ASC),
    CONSTRAINT [FK_dbo.StudentActivity_dbo.Activities_OptionalActivities_Id] FOREIGN KEY ([OptionalActivities_Id]) REFERENCES [dbo].[Activities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.StudentActivity_dbo.Students_Students_Id] FOREIGN KEY ([Students_Id]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Students_Id]
    ON [dbo].[StudentActivity]([Students_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OptionalActivities_Id]
    ON [dbo].[StudentActivity]([OptionalActivities_Id] ASC);

