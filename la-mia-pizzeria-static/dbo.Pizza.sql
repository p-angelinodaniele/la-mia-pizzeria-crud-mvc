CREATE TABLE [dbo].[Pizza] (
    [Name]        NVARCHAR (20)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Image]       NVARCHAR (MAX) NOT NULL,
    [Prezzo]      FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Pizza] PRIMARY KEY CLUSTERED ([Name] ASC)
);

