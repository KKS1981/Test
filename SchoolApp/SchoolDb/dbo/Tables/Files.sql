CREATE TABLE [dbo].[Files] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FileName]     NVARCHAR (MAX) NULL,
    [UploadDate]   DATETIME       NOT NULL,
    [S3Key]        NVARCHAR (MAX) NULL,
    [Size]         BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    CONSTRAINT [PK_dbo.Files] PRIMARY KEY CLUSTERED ([Id] ASC)
);

