CREATE OR REPLACE VIEW "Adjectives" AS
SELECT "Id", "Value"
FROM "EditorialCards"
WHERE "Type" = (SELECT "Type" FROM "EditorialTypes" WHERE "Name" = 'Adjective');
