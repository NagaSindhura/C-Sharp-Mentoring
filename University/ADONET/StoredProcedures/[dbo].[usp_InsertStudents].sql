USE [University]
GO

/****** Object:  StoredProcedure [dbo].[usp_InsertStudents]    Script Date: 5/25/2017 6:54:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_InsertStudents]
(
	@StudentName VARCHAR(100),
	@UniversityName VARCHAR(100),
	@SemisterName VARCHAR(100)
)
AS

DECLARE @SemisterIdID INT;
DECLARE @UniversityID INT;
DECLARE @StudentID INT;

INSERT INTO dbo.Semisters(SemisterName)
SELECT @SemisterName
WHERE NOT EXISTS(SELECT 1 FROM DBO.Semisters WHERE SemisterName = @SemisterName)

SET @SemisterIdID = SCOPE_IDENTITY();

INSERT INTO dbo.Universities(UniversityName)
SELECT @UniversityName
WHERE NOT EXISTS(SELECT 1 FROM DBO.Universities WHERE UniversityName = @UniversityName)

SET @UniversityID = SCOPE_IDENTITY();

IF(@UniversityID IS NULL)
BEGIN
	SELECT @UniversityID = UniversityID FROM dbo.Universities WHERE UniversityName = @UniversityName
END

INSERT INTO dbo.Students( StudentName,UniversityID,SemisterId)
VALUES(@StudentName,@UniversityID,@SemisterIdID)

SET @StudentID = SCOPE_IDENTITY();


INSERT INTO dbo.Marks( StudentId,SemisterId,SubjectId,Score)
SELECT @StudentID, s.SemisterId,SubjectId, 0
FROm Subjects s
WHERE SemisterId = @SemisterIdID


GO


