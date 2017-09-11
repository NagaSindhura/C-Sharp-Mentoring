USE [University]
GO

/****** Object:  StoredProcedure [dbo].[usp_InsertUniversity]    Script Date: 5/25/2017 6:54:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_InsertUniversity]
(
	@UniversityName VARCHAR(100)
)
AS

INSERT INTO dbo.Universities(UniversityName)
VALUES(@UniversityName)



GO


