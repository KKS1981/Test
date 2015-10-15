CREATE TABLE [dbo].[ActivityResults] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [GradePoint]              DECIMAL (18, 2) NOT NULL,
    [CreatedDate]             DATETIME        NOT NULL,
    [ModifiedDate]            DATETIME        NULL,
    [DeletedDate]             DATETIME        NULL,
    [ApprovedBy]              SMALLINT        NULL,
    [Activity_Id]             INT             NOT NULL,
    [DescriptiveIndicator_Id] INT             NOT NULL,
    [Student_Id]              INT             NOT NULL,
    [AcademicTermId]          INT             NOT NULL,
    CONSTRAINT [PK_dbo.ActivityResults] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ActivityResults_dbo.AcademicTerms_AcademicTermId] FOREIGN KEY ([AcademicTermId]) REFERENCES [dbo].[AcademicTerms] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ActivityResults_dbo.Activities_Activity_Id] FOREIGN KEY ([Activity_Id]) REFERENCES [dbo].[Activities] ([Id]),
    CONSTRAINT [FK_dbo.ActivityResults_dbo.DescriptiveIndicators_DescriptiveIndicator_Id] FOREIGN KEY ([DescriptiveIndicator_Id]) REFERENCES [dbo].[DescriptiveIndicators] ([Id]),
    CONSTRAINT [FK_dbo.ActivityResults_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Activity_Id]
    ON [dbo].[ActivityResults]([Activity_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DescriptiveIndicator_Id]
    ON [dbo].[ActivityResults]([DescriptiveIndicator_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[ActivityResults]([Student_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicTermId]
    ON [dbo].[ActivityResults]([AcademicTermId] ASC);

