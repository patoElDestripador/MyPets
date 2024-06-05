CREATE TABLE Owners (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(50),
    LastNames VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Addres VARCHAR(30),
    Phone Varchar(25)
);

CREATE TABLE Vets (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(120),
    Phone Varchar(25),
    Addres VARCHAR(30),
    Email VARCHAR(100) UNIQUE
);

CREATE TABLE Pets(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(120),
    Specie ENUM("Perro","Gato","Hamster","Ave","reptil","Aracnido","Serpiente"),
    Race ENUM("DOGO","NO SE DE RAZAS","Viuda negra","Tarantula","Chiuhua","Boa","Anaconda","Hamster ruso","Hamster de laboratorio"),
    DateBirth DATE,
    OwnerId INTEGER,
    Photo Text,
    FOREIGN KEY(OwnerId) REFERENCES Owners(Id)
);

CREATE TABLE Quotes (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Date DATETIME,
    PetId INTEGER,
    VetId INTEGER,
    FOREIGN KEY(PetId) REFERENCES Pets(Id),
    FOREIGN KEY(VetId) REFERENCES Vets(Id)
);