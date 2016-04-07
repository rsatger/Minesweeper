CREATE TABLE [dbo].[LogsReadsAndWrites] (
    [LineId]        INT           IDENTITY (1, 1) NOT NULL,
    [UtcTimestamp]  DATETIME      NULL,
    [LogId]         INT           NULL,
    [UserName]      VARCHAR (15)  NULL,
    [Content]       VARCHAR (100) NULL,
    [MessageTypeId] INT           NULL,	
    PRIMARY KEY CLUSTERED ([LineId] ASC),
    FOREIGN KEY ([MessageTypeId]) REFERENCES [dbo].[MessageType] ([TypeId])
);

