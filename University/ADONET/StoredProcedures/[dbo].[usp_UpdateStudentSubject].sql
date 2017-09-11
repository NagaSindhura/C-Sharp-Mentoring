USE [University]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdateStudentSubject]    Script Date: 5/25/2017 6:54:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_UpdateStudentSubject]
(
	@StudentName VARCHAR(200),
	@oldSemisterName VARCHAR(100),
	@newSemisterName VARCHAR(100)
)
AS

UPDATE student
SET student.SemisterId = oldsemister.SemisterId
from dbo.Students student
INNER JOIN dbo.Semisters semister ON semister.SemisterId = student.SemisterId
LEFT JOIN dbo.Semisters oldsemister ON oldsemister.SemisterId = @newSemisterName
WHERE semister.SemisterName = @oldSemisterName
AND oldsemister.SemisterId IS NOT NULL


GO


