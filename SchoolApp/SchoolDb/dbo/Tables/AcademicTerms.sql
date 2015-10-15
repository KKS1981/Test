CREATE TABLE [dbo].[AcademicTerms] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Label]           NVARCHAR (MAX) NULL,
    [DeletedDate]     DATETIME       NULL,
    [ModifiedDate]    DATETIME       NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [Order]           INT            NOT NULL,
    [AcademicYear_Id] INT            NOT NULL,
    CONSTRAINT [PK_dbo.AcademicTerms] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AcademicTerms_dbo.AcademicYears_AcademicYear_Id] FOREIGN KEY ([AcademicYear_Id]) REFERENCES [dbo].[AcademicYears] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicYear_Id]
    ON [dbo].[AcademicTerms]([AcademicYear_Id] ASC);

