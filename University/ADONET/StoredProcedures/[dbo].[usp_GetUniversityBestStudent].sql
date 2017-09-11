USE [University]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetUniversityBestStudent]    Script Date: 5/25/2017 6:53:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_GetUniversityBestStudent]
(
	@UniversityName VARCHAR(100)
)
AS

  SELECT student.StudentName
FROM dbo.Students student
JOIN dbo.Universities university On university.UniversityId = student.UniversityId
JOIN dbo.Semisters Semister On Semister.SemisterId = student.SemisterId
JOIN dbo.Subjects subject ON student.SemisterId = subject.SemisterId AND subject.SemisterId = Semister.SemisterId
JOIn dbo.Marks marks On marks.SemisterId = student.SemisterId AND marks.StudentId = student.StudentID AND marks.SubjectId = subject.SubjectId
WHERE university.UniversityName = @UniversityName
GROUP BY student.StudentID,  student.StudentName
ORDER BY SUM(marks.Score)/COUNT(subject.SubjectId) DESC


GO


