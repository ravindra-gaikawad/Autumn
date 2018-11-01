CREATE TABLE [dbo].[Book] (
    [Id]           BIGINT         CONSTRAINT [DF_Book_Id] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Title]        NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (500) NULL,
    [CreatedOn]    DATETIME2 (7)  CONSTRAINT [DF_Book_CreatedOn] DEFAULT (sysutcdatetime()) NOT NULL,
    [ModifiedOn]   DATETIME2 (7)  NULL,
    [PageCount]    INT            CONSTRAINT [DF_Book_PageCount] DEFAULT ((0)) NOT NULL,
    [ChapterCount] TINYINT        CONSTRAINT [DF_Book_ChapterCount] DEFAULT ((0)) NOT NULL,
    [IsPublic]     BIT            CONSTRAINT [DF_Book_IsPublic] DEFAULT ((0)) NOT NULL,
    [AuthorId]     BIGINT         NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Book_User] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[User] ([Id])
);

