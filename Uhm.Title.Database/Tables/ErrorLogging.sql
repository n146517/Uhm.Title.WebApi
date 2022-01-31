CREATE TABLE [dbo].[ErrorLogging]
(
	[ErrorLoggingId] INT identity, 
    [InnerException] VARCHAR(50) NULL, 
    [ExceptionMsg] VARCHAR(50) NULL, 
    [ExceptionType] VARCHAR(50) NULL, 
    [ExceptionSource] VARCHAR(50) NULL, 
    [ExceptionURL] VARCHAR(50) NULL, 
    [LoggingDate] INT NULL
)
