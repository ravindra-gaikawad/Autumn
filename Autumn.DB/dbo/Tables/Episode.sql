CREATE TABLE [dbo].[Episode] (
    [Id]          BIGINT         CONSTRAINT [DF_Episode_Id] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Title]       NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [ForDate]     DATETIME2 (7)  NOT NULL,
    [Location]    NVARCHAR (50)  NULL,
    [AuthorId]    BIGINT         NOT NULL,
    CONSTRAINT [PK_Episode] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Episode_User] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[User] ([Id])
);

