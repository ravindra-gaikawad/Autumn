CREATE TABLE [dbo].[DiaryPage] (
    [Id]          BIGINT         CONSTRAINT [DF_DiaryPage_Id] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Title]       NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [DiaryId]     BIGINT         NOT NULL,
    [Sequence]    SMALLINT       CONSTRAINT [DF_DiaryPage_Sequence] DEFAULT ((1)) NOT NULL,
    [ForDate]     DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_DiaryPage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DiaryPage_Diary] FOREIGN KEY ([DiaryId]) REFERENCES [dbo].[Diary] ([Id])
);

