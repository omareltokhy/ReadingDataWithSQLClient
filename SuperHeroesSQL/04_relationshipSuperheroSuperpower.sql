USE [SuperHeroes_Database]

CREATE TABLE Superhero_Superpower_Relation(
SuperheroID INT NOT NULL,
SuperpowerID INT NOT NULL,
FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID),
FOREIGN KEY (SuperpowerID) REFERENCES Superpower(ID),
UNIQUE (SuperheroID, SuperpowerID)
);
