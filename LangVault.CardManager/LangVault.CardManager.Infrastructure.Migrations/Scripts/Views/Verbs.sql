CREATE OR REPLACE VIEW "Verbs" AS
SELECT "Id", "Value"
FROM "EditorialCards"
WHERE "Type" = (SELECT "Type" FROM "EditorialTypes" WHERE "Name" = 'Verb');
