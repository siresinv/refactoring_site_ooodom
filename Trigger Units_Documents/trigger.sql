CREATE TRIGGER trg_UnitDocument_OnlyUnitType
ON UnitDocument
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Document d ON i.DocumentId = d.Id
        JOIN DocumentType dt ON d.DocumentTypeId = dt.Id
        WHERE dt.Name <> 'unit'
    )
    BEGIN
        RAISERROR('Можно добавлять только документы с типом unit', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;