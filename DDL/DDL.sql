CREATE DATABASE SBODemoGT
GO

USE SBODemoGT
GO

CREATE TABLE GroupClients(
	GroupNum INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GroupName VARCHAR(255) NOT NULL
)
GO

CREATE TABLE Clients(
	CardCode INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CardName VARCHAR(255) NOT NULL,
	GroupNum INTEGER NOT NULL,
	FOREIGN KEY (GroupNum) REFERENCES GroupClients(GroupNum)
	ON UPDATE CASCADE
)
GO

CREATE TABLE Articles(
	ItemCode INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ItemName VARCHAR(255) NOT NULL
)
GO

CREATE TABLE Orders(
	DocEntry INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DocNum INTEGER NOT NULL,
	CardCode INTEGER NOT NULL,
	DocDate DATETIME NOT NULL,
	DocTotal DECIMAL(15,2) NOT NULL,
	NumAtCard INTEGER NOT NULL,
	FOREIGN KEY (CardCode) REFERENCES Clients(CardCode)
	ON UPDATE CASCADE
)
GO

CREATE TABLE OrderDetail(
	DocEntry INTEGER NOT NULL,
	ItemCode INTEGER NOT NULL,
	LineTotal DECIMAL(15,2) NOT NULL,
	VatSum DECIMAL(15, 2) NOT NULL,
	FOREIGN KEY (DocEntry) REFERENCES Orders(DocEntry)
	ON UPDATE CASCADE,
	FOREIGN KEY (ItemCode) REFERENCES Articles(ItemCode)
	ON UPDATE CASCADE
)
GO

CREATE PROCEDURE ListarPedidos
AS
BEGIN
	SELECT TOP 15 * FROM Orders
	INNER JOIN Clients ON Clients.CardCode = Orders.CardCode
	INNER JOIN GroupClients ON GroupClients.GroupNum = Clients.GroupNum;
END
GO

SELECT * FROM Orders.

CREATE PROCEDURE ListarPedido
@docEntry INTEGER
AS
BEGIN
	SELECT * FROM Orders
	INNER JOIN Clients ON Clients.CardCode = Orders.CardCode
	INNER JOIN GroupClients ON GroupClients.GroupNum = Clients.GroupNum
	WHERE Orders.DocEntry = @docEntry;

	SELECT * FROM OrderDetail
	INNER JOIN Articles ON Articles.ItemCode = OrderDetail.ItemCode
	WHERE OrderDetail.DocEntry = @docEntry;

END 
GO

ALTER PROCEDURE FiltrarOrden
@groupNum INTEGER,
@cardCode INTEGER,
@dateInit VARCHAR(255), 
@dateFinish VARCHAR(255)
AS
BEGIN
DECLARE @query NVARCHAR(500);
SET @query = '
	SELECT * FROM Orders
	INNER JOIN Clients ON Clients.CardCode = Orders.CardCode
	INNER JOIN GroupClients ON GroupClients.GroupNum = Clients.GroupNum'

IF @groupNum != ''
	SET @query = @query +  ' WHERE GroupClients.GroupNum = ' + CONVERT(VARCHAR,@groupNum) + '';
IF @cardCode != ''
	SET @query = @query +  ' AND Clients.CardCode = ' + CONVERT(VARCHAR,@cardCode) + '';
IF @dateInit != '' AND @dateFinish != ''
	SET @query = @query +  ' AND Orders.DocDate BETWEEN ''' + @dateInit + ''' AND ''' + @dateFinish + '''';
EXECUTE SP_EXECUTESQL @query
END

EXECUTE FiltrarOrden @groupNum = '', @cardCode = 1, @dateInit = '2022-05-06', @dateFinish = '2022-06-06';