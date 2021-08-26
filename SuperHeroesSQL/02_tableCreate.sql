USE [SuperHeroes_Database]

CREATE TABLE Superhero 
(
    ID int PRIMARY KEY IDENTITY,
    Name nvarchar(50),
    Alias nvarchar(50),
    Origin nvarchar(50)
);

CREATE TABLE Assistant 
(
    ID int PRIMARY KEY IDENTITY,
    Name nvarchar(50),
);

CREATE TABLE Superpower 
(
    ID int PRIMARY KEY IDENTITY,
	Name nvarchar(50),
	Description nvarchar(50)
);