CREATE TABLE [dbo].[BookPage] (
    [Id]          BIGINT         CONSTRAINT [DF_BookPage_Id] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Title]       NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [BookId]      BIGINT         NOT NULL,
    [Sequence]    SMALLINT       CONSTRAINT [DF_BookPage_Sequence] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BookPage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BookPage_Book] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([Id])
);

