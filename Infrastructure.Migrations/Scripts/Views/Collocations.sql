CREATE OR REPLACE VIEW "Collocations" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "ConstructTypes" WHERE "Name" = 'Collocation');
