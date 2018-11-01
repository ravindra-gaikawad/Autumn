CREATE TABLE [dbo].[Diary] (
    [Id]          BIGINT         CONSTRAINT [DF_Diary_Id] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Title]       NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (500) NULL,
    [CreatedOn]   DATETIME2 (7)  CONSTRAINT [DF_Diary_CreatedOn] DEFAULT (sysutcdatetime()) NOT NULL,
    [ModifiedOn]  DATETIME2 (7)  NULL,
    [PageCount]   INT            CONSTRAINT [DF_Diary_PageCount] DEFAULT ((0)) NOT NULL,
    [IsPublic]    BIT            CONSTRAINT [DF_Diary_IsPublic] DEFAULT ((0)) NOT NULL,
    [AuthorId]    BIGINT         NOT NULL,
    CONSTRAINT [PK_Diary] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diary_User] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[User] ([Id])
);

