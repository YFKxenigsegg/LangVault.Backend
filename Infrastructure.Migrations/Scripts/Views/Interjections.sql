CREATE OR REPLACE VIEW "Interjections" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "WordTypes" WHERE "Name" = 'Interjection');
