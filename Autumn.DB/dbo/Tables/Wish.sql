CREATE TABLE [dbo].[Wish] (
    [Id]         BIGINT         CONSTRAINT [DF_Wish_Id] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Title]      NVARCHAR (100) NOT NULL,
    [CreatedOn]  DATETIME2 (7)  CONSTRAINT [DF_Wish_CreatedOn] DEFAULT (sysutcdatetime()) NOT NULL,
    [ModifiedOn] DATETIME2 (7)  NULL,
    [IsPublic]   BIT            CONSTRAINT [DF_Wish_IsPublic] DEFAULT ((0)) NOT NULL,
    [AuthorId]   BIGINT         NOT NULL,
    CONSTRAINT [PK_Wish] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Wish_User] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[User] ([Id])
);

