CREATE OR REPLACE VIEW "Adverbs" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "WordTypes" WHERE "Name" = 'Adverb');
