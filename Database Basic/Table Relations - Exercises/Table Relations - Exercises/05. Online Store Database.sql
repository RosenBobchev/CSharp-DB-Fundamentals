CREATE TABLE Cities (
	CityID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_CityID PRIMARY KEY (CityID)
)

CREATE TABLE Customers (
	CustomerID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL,

	CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID),
	CONSTRAINT FK_CityID_Cities
	FOREIGN KEY (CityID) REFERENCES Cities (CityID)
)

CREATE TABLE ItemTypes (
	ItemTypeID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_ItemTypeID PRIMARY KEY (ItemTypeID)
)

CREATE TABLE Items (
	ItemID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	ItemTypeID INT NOT NULL,

	CONSTRAINT PK_ItemID PRIMARY KEY (ItemID),
	CONSTRAINT FK_ItemTypeID_ItemTypes
	FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes (ItemTypeID)
)

CREATE TABLE Orders (
	OrderID INT NOT NULL,
	CustomerID INT NOT NULL,

	CONSTRAINT PK_OrderID PRIMARY KEY (OrderID),
	CONSTRAINT FK_CustomerID_Customers
	FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
)

CREATE TABLE OrderItems (
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,

	CONSTRAINT PK_OrderID_ItemID PRIMARY KEY (OrderID, ItemID),
	CONSTRAINT FK_OrderID_Orders
	FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
	CONSTRAINT FK_ItemID_Items
	FOREIGN KEY (ItemID) REFERENCES Items (ItemID)
)