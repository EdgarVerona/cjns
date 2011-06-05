SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alex Loret de Mola
-- Create date: 05/17/2011
-- Description:	
-- =============================================
CREATE PROCEDURE Test_ContentTypes
AS
BEGIN
	SET NOCOUNT ON;
	
	SET IDENTITY_INSERT ContentTypes ON;
	
	INSERT INTO ContentTypes(Id, Text) VALUES (1, 'application/atom+xml')
	INSERT INTO ContentTypes(Id, Text) VALUES (2, 'image/png')
	INSERT INTO ContentTypes(Id, Text) VALUES (3, 'application/json')
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (1, '1', 'TestSingleCollection', 1, GETUTCDATE(), '111111')
	
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (1, 1)
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (1, 2)
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (1, 3)
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (2, '2', 'TestMultipleCollectionFixedCategories', 1, GETUTCDATE(), '222222')
	
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (2, 1)
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (2, 2)
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (2, 3)
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (3, '3', 'TestMultipleCollectionFlexibleCategories', 0, GETUTCDATE(), '333333')
	
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (3, 1)
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (3, 2)
	INSERT INTO CollectionContentTypes(CollectionId, ContentTypeId) VALUES (3, 3)
	
	
	SET IDENTITY_INSERT ContentTypes OFF;

END
GO