CREATE TABLE [dbo].[Type]
(
    [id] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NOT NULL, 
    [isRequeredDate] BOOLEAN NOT NULL
    [isRequeredName] BOOLEAN NOT NULL

    
);

CREATE TABLE [dbo].[User]
(
    [id] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NULL, 
    [date] DATE NULL,
    [type] INT NOT NULL, 
    CONSTRAINT FK_User_Type FOREIGN KEY ([type]) REFERENCES [dbo].[Type]([id])
);