SELECT
    '[' || string_agg(
            '{"ID": "' || ID ||
            '", "ContainerID": "' || ContainerID ||
            '", "StartDate": "' || to_char(StartDate, 'YYYY-MM-DD"T"HH24:MI:SS"Z"') ||
            '", "EndDate": "' || to_char(EndDate, 'YYYY-MM-DD"T"HH24:MI:SS"Z"') ||
            '", "OperationType": "' || replace(OperationType, '"', '\"') ||
            '", "OperatorName": "' || replace(OperatorName, '"', '\"') ||
            '", "InspectionPlace": "' || replace(InspectionPlace, '"', '\"') || '"}',
            ',') || ']'
FROM Operations
WHERE ContainerID = 'container-id';
