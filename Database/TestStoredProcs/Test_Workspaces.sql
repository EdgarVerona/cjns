SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alex Loret de Mola
-- Create date: 05/17/2011
-- Description:	
-- =============================================
CREATE PROCEDURE Test_Workspaces
AS
BEGIN
	SET NOCOUNT ON;
	
	SET IDENTITY_INSERT Workspaces ON;
	
	INSERT INTO Workspaces(Id, Title) VALUES (1, 'TestSingle')
	INSERT INTO Workspaces(Id, Title) VALUES (2, 'TestMultiple')
	INSERT INTO Workspaces(Id, Title) VALUES (3, 'TestEmpty')
	
	SET IDENTITY_INSERT Workspaces OFF;

END
GO