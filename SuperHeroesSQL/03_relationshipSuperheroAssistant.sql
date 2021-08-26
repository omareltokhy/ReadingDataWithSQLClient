USE [SuperHeroes_Database]

ALTER TABLE Assistant
ADD SuperheroID INT NOT NULL

ALTER TABLE Assistant
ADD CONSTRAINT fkSuperheroID FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID);

