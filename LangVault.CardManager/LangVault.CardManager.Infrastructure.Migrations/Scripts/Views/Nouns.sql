CREATE OR REPLACE VIEW "Nouns" AS
SELECT "Id", "Value"
FROM "EditorialCards"
WHERE "Type" = (SELECT "Type" FROM "EditorialTypes" WHERE "Name" = 'Noun');
