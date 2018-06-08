CREATE TABLE Majors (
	MajorID INT NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_MajorID PRIMARY KEY (MajorID)
)

CREATE TABLE Students (
	StudentID INT NOT NULL,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(20) NOT NULL,
	MajorID INT NOT NULL,

	CONSTRAINT PK_StudentID PRIMARY KEY (StudentID),
	CONSTRAINT FK_MajorID_Majors
	FOREIGN KEY (MajorID) REFERENCES Majors (MajorID)
)

CREATE TABLE Payments (
	PaymentID INT NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2) NOT NULL,
	StudentID INT NOT NULL,

	CONSTRAINT PK_PaymentID PRIMARY KEY (PaymentID),
	CONSTRAINT FK_StudentID_Students
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Subjects (
	SubjectID INT NOT NULL,
	SubjectName NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_SubjectID PRIMARY KEY (SubjectID)
)

CREATE TABLE Agenda (
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,

	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY (StudentID, SubjectID),
	CONSTRAINT FK_StudentID
	FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
	CONSTRAINT FK_SubjectID
	FOREIGN KEY (SubjectID) REFERENCES Subjects (SubjectID)
)