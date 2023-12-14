CREATE OR REPLACE VIEW "Idioms" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "ConstructTypes" WHERE "Name" = 'Idiom');
