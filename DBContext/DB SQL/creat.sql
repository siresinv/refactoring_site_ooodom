CREATE TABLE Company (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    -- Можно добавить другие поля, если нужно
);

CREATE TABLE CompanyCard (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255),
    Shortname NVARCHAR(255),
    DirectorFullName NVARCHAR(255),
    Url NVARCHAR(255),
    Post NVARCHAR(255),
    Address NVARCHAR(255),
    Email NVARCHAR(255),
    Site NVARCHAR(255),
    LocationLink NVARCHAR(255),
    CompanyId UNIQUEIDENTIFIER,
    FOREIGN KEY (CompanyId) REFERENCES Company(Id)
);

CREATE TABLE Phone (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255),
    Value NVARCHAR(255),
    CompanyCardId UNIQUEIDENTIFIER,
    FOREIGN KEY (CompanyCardId) REFERENCES CompanyCard(Id)
);

CREATE TABLE Work_Hour (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255),
    Value NVARCHAR(255),
    CompanyCardId UNIQUEIDENTIFIER,
    FOREIGN KEY (CompanyCardId) REFERENCES CompanyCard(Id)
);

CREATE TABLE Reception (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255),
    Value NVARCHAR(255),
    CompanyCardId UNIQUEIDENTIFIER,
    FOREIGN KEY (CompanyCardId) REFERENCES CompanyCard(Id)
);

CREATE TABLE Document (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    DocumentTypeId UNIQUEIDENTIFIER,
    Name NVARCHAR(255),
    Year INT,
    Version INT,
    StorageLink NVARCHAR(255),
    FOREIGN KEY (DocumentTypeId) REFERENCES DocumentType(Id)
);

CREATE TABLE DocumentType (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255),
    NickName NVARCHAR(255)
);

CREATE TABLE Report (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255),
    NickName NVARCHAR(255)
);

CREATE TABLE ReportDocumentType (
    ReportId UNIQUEIDENTIFIER,
    DocumentTypeId UNIQUEIDENTIFIER,
    PRIMARY KEY (ReportId, DocumentTypeId),
    FOREIGN KEY (ReportId) REFERENCES Report(Id),
    FOREIGN KEY (DocumentTypeId) REFERENCES DocumentType(Id)
);

CREATE TABLE Unit (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    CompanyId UNIQUEIDENTIFIER,
    FOREIGN KEY (CompanyId) REFERENCES Company(Id)
);

CREATE TABLE UnitDocument (
    UnitId UNIQUEIDENTIFIER,
    DocumentId UNIQUEIDENTIFIER,
    PRIMARY KEY (UnitId, DocumentId),
    FOREIGN KEY (UnitId) REFERENCES Unit(Id),
    FOREIGN KEY (DocumentId) REFERENCES Document(Id)
);

CREATE TABLE UnitCard (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    StreetName NVARCHAR(255),
    Number NVARCHAR(50),
    ConstructYear INT,
    StagesAmount INT,
    EntranceAmount INT,
    LiftAmount INT,
    FlatAmount INT,
    IsManagementing BIT,
    UnitId UNIQUEIDENTIFIER,
    FOREIGN KEY (UnitId) REFERENCES Unit(Id)
);

-- Связь CompanyCard с документами (многие ко многим)
CREATE TABLE CompanyCardDocument (
    CompanyCardId UNIQUEIDENTIFIER,
    DocumentId UNIQUEIDENTIFIER,
    PRIMARY KEY (CompanyCardId, DocumentId),
    FOREIGN KEY (CompanyCardId) REFERENCES CompanyCard(Id),
    FOREIGN KEY (DocumentId) REFERENCES Document(Id)
);