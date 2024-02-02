CREATE OR REPLACE VIEW "PhrasalVerbs" AS
SELECT "Id", "Value"
FROM "EditorialCards"
WHERE "Type" = (SELECT "Type" FROM "EditorialTypes" WHERE "Name" = 'Phrasal Verb');
