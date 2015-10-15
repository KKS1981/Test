CREATE TABLE [dbo].[DescriptiveIndicators] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Category]         NVARCHAR (MAX)  NULL,
    [Text]             NVARCHAR (MAX)  NULL,
    [CreatedDate]      DATETIME        NOT NULL,
    [ModifiedDate]     DATETIME        NULL,
    [DeletedDate]      DATETIME        NULL,
    [DisplayOrder]     INT             NULL,
    [Min]              DECIMAL (18, 2) NULL,
    [Max]              DECIMAL (18, 2) NULL,
    [ShortDescription] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_dbo.DescriptiveIndicators] PRIMARY KEY CLUSTERED ([Id] ASC)
);

