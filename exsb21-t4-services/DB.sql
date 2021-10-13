CREATE TABLE Skills (
    SkillId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SkillName varchar(255),
);

CREATE TABLE Specializations (
    SpecializationId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SpecializationName varchar(255),
);

CREATE TABLE Candidates (
    CandidateId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CandidateName varchar(255),
    CandidateSurname varchar(255),
    SpecialisationId int,
    Location varchar(255),
    Education varchar(255),
    Email varchar(255),
    Skype varchar(255),
    Phone varchar(255),
    Status int  
);
