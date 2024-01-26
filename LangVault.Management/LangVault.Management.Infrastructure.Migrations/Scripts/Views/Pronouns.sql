CREATE OR REPLACE VIEW "Pronouns" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "WordTypes" WHERE "Name" = 'Pronoun');
