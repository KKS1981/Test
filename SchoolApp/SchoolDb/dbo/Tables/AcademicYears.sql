CREATE TABLE [dbo].[AcademicYears] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [StartMon]     INT            NOT NULL,
    [EndMon]       INT            NOT NULL,
    [StartYear]    INT            NOT NULL,
    [EndYear]      INT            NOT NULL,
    [DeletedDate]  DATETIME2 (7)  NULL,
    [ModifiedDate] DATETIME       NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [Label]        NVARCHAR (MAX) NULL,
    [IsCurrent]    BIT            NOT NULL,
    CONSTRAINT [PK_dbo.AcademicYears] PRIMARY KEY CLUSTERED ([Id] ASC)
);

