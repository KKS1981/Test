CREATE TABLE [dbo].[Menus] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Roles]        NVARCHAR (MAX) NULL,
    [Controller]   NVARCHAR (MAX) NULL,
    [Action]       NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    [Parent_Id]    INT            NULL,
    CONSTRAINT [PK_dbo.Menus] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Menus_dbo.Menus_Parent_Id] FOREIGN KEY ([Parent_Id]) REFERENCES [dbo].[Menus] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Id]
    ON [dbo].[Menus]([Parent_Id] ASC);

