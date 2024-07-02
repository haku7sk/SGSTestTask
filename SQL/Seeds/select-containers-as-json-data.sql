
SELECT
    '[' || string_agg(
    '{"ID": "' || ID ||
    '", "Number": ' || Number ||
    ', "Type": "' || replace(Type, '"', '\"') ||
    '", "Length": ' || Length ||
    ', "Width": ' || Width ||
    ', "Height": ' || Height ||
    ', "Weight": ' || Weight ||
    ', "IsEmpty": ' || CASE WHEN IsEmpty THEN 'true' ELSE 'false' END ||
    ', "DateReceived": "' || to_char(DateReceived, 'YYYY-MM-DD"T"HH24:MI:SS"Z"') || '"}',
    ',') || ']' as jsonData
FROM Containers;

