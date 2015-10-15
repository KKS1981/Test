CREATE TABLE [dbo].[ClassLabelAssessmentSchemas] (
    [ClassLabels_Id]       INT NOT NULL,
    [AssessmentSchemas_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.ClassLabelAssessmentSchemas] PRIMARY KEY CLUSTERED ([ClassLabels_Id] ASC, [AssessmentSchemas_Id] ASC),
    CONSTRAINT [FK_dbo.ClassLabelAssessmentSchemas_dbo.AssessmentSchemas_AssessmentSchemas_Id] FOREIGN KEY ([AssessmentSchemas_Id]) REFERENCES [dbo].[AssessmentSchemas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ClassLabelAssessmentSchemas_dbo.ClassLabels_ClassLabels_Id] FOREIGN KEY ([ClassLabels_Id]) REFERENCES [dbo].[ClassLabels] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ClassLabels_Id]
    ON [dbo].[ClassLabelAssessmentSchemas]([ClassLabels_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssessmentSchemas_Id]
    ON [dbo].[ClassLabelAssessmentSchemas]([AssessmentSchemas_Id] ASC);

