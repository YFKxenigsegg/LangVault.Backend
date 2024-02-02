CREATE OR REPLACE VIEW "Conjuctions" AS
SELECT "Id", "Value"
FROM "EditorialCards"
WHERE "Type" = (SELECT "Type" FROM "EditorialTypes" WHERE "Name" = 'Conjuction');
