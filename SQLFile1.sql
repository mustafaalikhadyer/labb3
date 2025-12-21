
CREATE TABLE Personal (
    PersonalID INT IDENTITY(1,1) PRIMARY KEY,
    Fornamn NVARCHAR(50),
    Efternamn NVARCHAR(50),
    Personnummer NVARCHAR(12),
    Befattning NVARCHAR(50)
);


CREATE TABLE Klass (
    KlassID INT IDENTITY(1,1) PRIMARY KEY,
    KlassNamn NVARCHAR(20),
    AnsvarigLarareID INT NULL,
    CONSTRAINT FK_Klass_Personal FOREIGN KEY (AnsvarigLarareID) REFERENCES Personal(PersonalID)
);


CREATE TABLE Kurs (
    KursID INT IDENTITY(1,1) PRIMARY KEY,
    KursNamn NVARCHAR(50)
);


CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    Fornamn NVARCHAR(50),
    Efternamn NVARCHAR(50),
    Personnummer NVARCHAR(12),
    KlassID INT,
    CONSTRAINT FK_Student_Klass FOREIGN KEY (KlassID) REFERENCES Klass(KlassID)
);


CREATE TABLE Betyg (
    BetygID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    KursID INT,
    LarareID INT,
    Betyg CHAR(1),
    Datum DATE,
    CONSTRAINT FK_Betyg_Student FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    CONSTRAINT FK_Betyg_Kurs FOREIGN KEY (KursID) REFERENCES Kurs(KursID),
    CONSTRAINT FK_Betyg_Larare FOREIGN KEY (LarareID) REFERENCES Personal(PersonalID)
);






