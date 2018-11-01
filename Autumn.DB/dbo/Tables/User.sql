CREATE TABLE [dbo].[User] (
    [Id]        BIGINT         CONSTRAINT [DF_Table_1_Id1] DEFAULT (NEXT VALUE FOR [TempSequence]) NOT NULL,
    [Firstname] NVARCHAR (50)  NOT NULL,
    [Lastname]  NVARCHAR (50)  NULL,
    [EmailId]   NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

