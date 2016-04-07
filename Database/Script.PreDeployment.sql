﻿/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF OBJECT_ID('dbo.LogsReadsAndWrites', 'U') IS NOT NULL
	DELETE FROM LogsReadsAndWrites

IF OBJECT_ID('dbo.MessageType', 'U') IS NOT NULL
	DELETE FROM MessageType