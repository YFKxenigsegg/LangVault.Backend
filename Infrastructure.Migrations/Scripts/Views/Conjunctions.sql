CREATE OR REPLACE VIEW "Conjuctions" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "WordTypes" WHERE "Name" = 'Conjuction');
