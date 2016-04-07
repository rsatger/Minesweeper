INSERT INTO dbo.LogsReadsAndWrites(LogId, UtcTimestamp, UserName, Content, MessageTypeId) 
VALUES (@logId, CURRENT_TIMESTAMP, @user, @message, @type)