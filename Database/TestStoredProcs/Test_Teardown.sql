SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alex Loret de Mola
-- Create date: 05/17/2011
-- Description:	Stored procedure for the teardown of any testing-related data.
-- =============================================
CREATE PROCEDURE Test_Teardown
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM EntryAuthors
    DELETE FROM EntryContributors
	DELETE FROM WorkspaceCollections
	DELETE FROM EntryCategories
	DELETE FROM CollectionCategories
    DELETE FROM CollectionContentTypes
	DELETE FROM People
	DELETE FROM Links
    DELETE FROM Categories
    DELETE FROM ContentTypes
    DELETE FROM Entries
    DELETE FROM Collections
    DELETE FROM Workspaces
END
GO
