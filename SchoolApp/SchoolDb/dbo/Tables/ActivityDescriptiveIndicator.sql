CREATE TABLE [dbo].[ActivityDescriptiveIndicator] (
    [Activities_Id]            INT NOT NULL,
    [DescriptiveIndicators_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.ActivityDescriptiveIndicator] PRIMARY KEY CLUSTERED ([Activities_Id] ASC, [DescriptiveIndicators_Id] ASC),
    CONSTRAINT [FK_dbo.ActivityDescriptiveIndicator_dbo.Activities_Activities_Id] FOREIGN KEY ([Activities_Id]) REFERENCES [dbo].[Activities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ActivityDescriptiveIndicator_dbo.DescriptiveIndicators_DescriptiveIndicators_Id] FOREIGN KEY ([DescriptiveIndicators_Id]) REFERENCES [dbo].[DescriptiveIndicators] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Activities_Id]
    ON [dbo].[ActivityDescriptiveIndicator]([Activities_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DescriptiveIndicators_Id]
    ON [dbo].[ActivityDescriptiveIndicator]([DescriptiveIndicators_Id] ASC);

