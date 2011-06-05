SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alex Loret de Mola
-- Create date: 05/17/2011
-- Description:	
-- =============================================
CREATE PROCEDURE Test_Collections
AS
BEGIN
	SET NOCOUNT ON;
	
	SET IDENTITY_INSERT Collections ON;
	
	--INSERT INTO Workspaces(Id, Title) VALUES (1, 'TestSingle')
	
	INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (1, '1', 'TestSingleCollection', 1, GETUTCDATE(), '111111')
		INSERT INTO WorkspaceCollections(WorkspaceId, CollectionId) VALUES (1, 1)
	
	--INSERT INTO Workspaces(Id, Title) VALUES (2, 'TestMultiple')
	
	INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (2, '2', 'TestMultipleCollectionFixedCategories', 1, GETUTCDATE(), '222222')
		INSERT INTO WorkspaceCollections(WorkspaceId, CollectionId) VALUES (2, 2)

	INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (3, '3', 'TestMultipleCollectionFlexibleCategories', 0, GETUTCDATE(), '333333')
		INSERT INTO WorkspaceCollections(WorkspaceId, CollectionId) VALUES (2, 3)
	
	--INSERT INTO Workspaces(Id, Title) VALUES (3, 'TestEmpty')
	
	SET IDENTITY_INSERT Collections OFF;

END
GO