CREATE OR REPLACE VIEW "PhrasalVerbs" AS
SELECT "Id", "Value"
FROM "Words"
WHERE "Type" = (SELECT "Value" FROM "ConstructTypes" WHERE "Name" = 'Phrasal Verb');
