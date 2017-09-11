USE [University]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdateStudentDetails]    Script Date: 5/25/2017 6:54:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_UpdateStudentDetails]
(
	@StudentName VARCHAR(100),
	@UniversityName VARCHAR(100),
	@SemisterName VARCHAR(100)
)
AS

Declare @UniversityId INT
Declare @SemisterId INT

SELECT @UniversityId  = u.UniversityId
from dbo.Universities u WHERE u.UniversityName = @UniversityName

SELECT @SemisterId  = u.SemisterId
from dbo.Semisters u WHERE u.SemisterName = @SemisterName


if(@UniversityId IS NOT NUll OR @SemisterId IS NOT NULL)
begin
	UPDATE S
	SET s.SemisterId = @SemisterId, s.UniversityId = @UniversityId
	FROM dbo.Students s
	where s.StudentName = @SemisterName
END


GO


