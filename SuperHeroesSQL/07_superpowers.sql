USE [SuperHeroes_Database]

INSERT INTO Superpower (Name,Description)
VALUES ('Gadgets', 'Guns and stuff')
SELECT SuperheroID FROM Superhero_Superpower_Relation
WHERE SuperheroID = 1 AND SuperheroID = 2

INSERT INTO Superpower (Name,Description)
VALUES ('Heat vision', 'Ability to release solar energy through the eyes')
SELECT SuperheroID FROM Superhero_Superpower_Relation
WHERE SuperheroID = 3

INSERT INTO Superpower (Name,Description)
VALUES ('Iron Suit', 'Gives superhuman strength and protection')
SELECT SuperheroID FROM Superhero_Superpower_Relation
WHERE SuperheroID = 2

INSERT INTO Superpower (Name,Description)
VALUES ('Superhuman strength', 'This power level is over 9000')
SELECT SuperheroID FROM Superhero_Superpower_Relation
WHERE SuperheroID = 1 AND SuperheroID = 2 AND SuperheroID = 3
