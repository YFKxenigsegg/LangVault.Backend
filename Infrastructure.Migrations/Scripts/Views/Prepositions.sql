CREATE OR REPLACE VIEW "Prepositions" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "WordTypes" WHERE "Name" = 'Preposition');
