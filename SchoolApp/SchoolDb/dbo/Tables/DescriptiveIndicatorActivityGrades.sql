CREATE TABLE [dbo].[DescriptiveIndicatorActivityGrades] (
    [ActivityGrade_Id]        INT NOT NULL,
    [DescriptiveIndicator_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.DescriptiveIndicatorActivityGrades] PRIMARY KEY CLUSTERED ([DescriptiveIndicator_Id] ASC, [ActivityGrade_Id] ASC),
    CONSTRAINT [FK_dbo.ActivityGradeDescriptiveIndicators_dbo.ActivityGrades_ActivityGrade_Id] FOREIGN KEY ([ActivityGrade_Id]) REFERENCES [dbo].[ActivityGrades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ActivityGradeDescriptiveIndicators_dbo.DescriptiveIndicators_DescriptiveIndicator_Id] FOREIGN KEY ([DescriptiveIndicator_Id]) REFERENCES [dbo].[DescriptiveIndicators] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DescriptiveIndicator_Id]
    ON [dbo].[DescriptiveIndicatorActivityGrades]([DescriptiveIndicator_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ActivityGrade_Id]
    ON [dbo].[DescriptiveIndicatorActivityGrades]([ActivityGrade_Id] ASC);

