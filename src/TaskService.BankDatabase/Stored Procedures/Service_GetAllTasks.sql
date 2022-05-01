CREATE PROCEDURE [dbo].[Service_GetAllTasks]
AS
BEGIN
	SELECT 
		TaskID
		,TaskType
		,IsEnabled
		,Branch
		,TaskName
		,Dependency
		,LastWorkTime
		,TaskStartTime
		,TaskEndTime
		,FilePath
		,Url
		,FieldsCount
		,FieldsSeparator
		,Params
		,ManualStart
	FROM
		[dbo].[ServiceTasks]
	WHERE
		AuthoriziedBy IS NOT NULL OR AuthoriziedBy <> ''
END