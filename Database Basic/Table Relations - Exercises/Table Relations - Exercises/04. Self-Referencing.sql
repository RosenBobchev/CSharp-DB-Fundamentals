CREATE TABLE Teachers (
	TeacherID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	ManagerID INT,

	CONSTRAINT PK_TeacherID PRIMARY KEY (TeacherID),
	CONSTRAINT FK_TeacherID_ManagerID 
	FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)