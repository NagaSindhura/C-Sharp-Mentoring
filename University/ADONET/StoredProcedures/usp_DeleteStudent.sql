USE [University]
GO

/****** Object:  StoredProcedure [dbo].[usp_DeleteStudent]    Script Date: 5/25/2017 6:53:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteStudent]
(
	@StudentName VARCHAR(200)
)
AS

DELETE FROM Students WHERE StudentName = @StudentName

GO


