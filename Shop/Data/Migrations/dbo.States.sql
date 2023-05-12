CREATE TABLE [dbo].[States]
(
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [productId] INT NOT NULL, 
    [productQuantity] INT NOT NULL,

    CONSTRAINT [FK_States_Products] FOREIGN KEY ([productId]) REFERENCES [dbo].[Products] ([id])
)