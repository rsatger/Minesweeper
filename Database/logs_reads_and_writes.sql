CREATE TABLE [dbo].[logs_reads_and_writes] (
    [line_id]         INT           IDENTITY (1, 1) NOT NULL,
    [UTC_timestamp]   DATETIME      NULL,
    [log_id]          INT           NULL,
    [user_name]       VARCHAR (15)  NULL,
    [content]         VARCHAR (100) NULL,
    [message_type_id] INT           NULL,
    PRIMARY KEY CLUSTERED ([line_id] ASC),
    FOREIGN KEY ([message_type_id]) REFERENCES [dbo].[message_type] ([type_id])
);

