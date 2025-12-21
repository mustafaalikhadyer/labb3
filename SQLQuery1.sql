-- Personal
INSERT INTO Personal (Fornamn, Efternamn, Personnummer, Befattning)
VALUES
(N'Anna', N'Lind', '19800101-1234', N'Lärare'),
(N'Björn', N'Eriksson', '19750505-5678', N'Lärare'),
(N'Sara', N'Holm', '19891212-2222', N'Administratör'),
(N'Karin', N'Berg', '19661111-9999', N'Rektor');

-- Klasser
INSERT INTO Klass (KlassNamn, AnsvarigLarareID)
VALUES
('NA21A', 1),
('TE21B', 2);

-- Kurser
INSERT INTO Kurs (KursNamn)
VALUES
('Matematik 1c'),
('Svenska 1'),
('Fysik 1');

-- Studenter
INSERT INTO Student (Fornamn, Efternamn, Personnummer, KlassID)
VALUES
(N'Maja', N'Svensson', '20040123-1111', 1),
(N'Liam', N'Andersson', '20040210-2222', 1),
(N'Ella', N'Johansson', '20040515-3333', 2),
(N'Noah', N'Karlsson', '20040312-4444', 2);

-- Betyg
INSERT INTO Betyg (StudentID, KursID, LarareID, Betyg, Datum)
VALUES
(1, 1, 1, 'A', '2025-01-10'),
(1, 2, 1, 'B', '2025-02-05'),
(2, 1, 1, 'C', '2025-02-03'),
(3, 3, 2, 'A', '2025-02-20');



-- Alla lärare
SELECT *
FROM Personal
WHERE Befattning = N'Lärare';

-- Alla studenter sorterade på efternamn
SELECT *
FROM Student
ORDER BY Efternamn ASC;

-- Alla studenter i klass med KlassID = 1
SELECT *
FROM Student
WHERE KlassID = 1;

-- Alla studenter i klass NA21A
SELECT S.*
FROM Student S
JOIN Klass K ON S.KlassID = K.KlassID
WHERE K.KlassNamn = 'NA21A';

-- Alla betyg satta senaste månaden
SELECT *
FROM Betyg
WHERE Datum >= DATEADD(MONTH, -1, GETDATE());
