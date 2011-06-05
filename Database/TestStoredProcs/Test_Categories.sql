SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alex Loret de Mola
-- Create date: 05/17/2011
-- Description:	
-- =============================================
CREATE PROCEDURE Test_Categories
AS
BEGIN
	SET NOCOUNT ON;
	
	SET IDENTITY_INSERT Categories ON;
	
	INSERT INTO Categories(Id, Term, Scheme, Label) VALUES (1, 'TestCategory1', 'TestCategory1', 'TestCategory1')
	INSERT INTO Categories(Id, Term, Scheme, Label) VALUES (2, 'TestCategory2', 'TestCategory2', 'TestCategory2')
	INSERT INTO Categories(Id, Term, Scheme, Label) VALUES (3, 'TestCategory3', 'TestCategory3', 'TestCategory3')
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (1, '1', 'TestSingleCollection', 1, GETUTCDATE(), '111111')
	
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (1, 1)
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (1, 2)
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (1, 3)
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (2, '2', 'TestMultipleCollectionFixedCategories', 1, GETUTCDATE(), '222222')
	
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (2, 1)
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (2, 2)
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (2, 3)
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (3, '3', 'TestMultipleCollectionFlexibleCategories', 0, GETUTCDATE(), '333333')
	
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (3, 1)
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (3, 2)
	INSERT INTO CollectionCategories(CollectionId, CategoryId) VALUES (3, 3)


	-- Assign a category for each initial test entry.
	INSERT INTO EntryCategories(EntryId, CategoryId) VALUES(1, 1)	
	INSERT INTO EntryCategories(EntryId, CategoryId) VALUES(2, 2)
	INSERT INTO EntryCategories(EntryId, CategoryId) VALUES(3, 3)
	INSERT INTO EntryCategories(EntryId, CategoryId) VALUES(4, 1)
	
	
	SET IDENTITY_INSERT Categories OFF;

END
GO