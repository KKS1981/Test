CREATE TABLE [dbo].[Settings] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Key]          NVARCHAR (MAX) NULL,
    [Value]        NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    CONSTRAINT [PK_dbo.Settings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

