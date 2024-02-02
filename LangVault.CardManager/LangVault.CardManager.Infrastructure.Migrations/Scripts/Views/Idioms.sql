CREATE OR REPLACE VIEW "Idioms" AS
SELECT "Id", "Value"
FROM "EditorialCards"
WHERE "Type" = (SELECT "Type" FROM "EditorialTypes" WHERE "Name" = 'Idiom');
