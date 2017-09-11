IF EXISTS(SELECT * FROM SYS.objects WHERE object_id = OBJECT_ID(N'usp_GetUniversityStudents') AND TYPE IN (N'P',N'PC'))
DROP PROCEDURE [dbo].[usp_GetUniversityStudents]
GO

USE University
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetUniversityStudents]
(
	@University VARCHAR(100)
)
AS

SELECT DISTINCT s.StudentName FROM Students s
JOIN Universities u ON s.UniversityID = u.UniversityID
WHERE u.UniversityName like '%'+@University+'%'

GO