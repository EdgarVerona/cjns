SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alex Loret de Mola
-- Create date: 05/17/2011
-- Description:	
-- =============================================
CREATE PROCEDURE Test_Entries
AS
BEGIN
	SET NOCOUNT ON;
	
	SET IDENTITY_INSERT Entries ON;
	
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (1, '1', 'TestSingleCollection', 1, GETUTCDATE(), '111111')
	
	INSERT INTO Entries
		(Id, ContentType,			 SourceUri, Text,   AtomId, DatePublished, Rights, Summary, Title,  DateUpdated,  IsDraft, CollectionId) VALUES
		(1,  'application/atom+xml', '1',		'blah', '111', GETUTCDATE(),   '',     '',      'test', GETUTCDATE(), 0,       1)
	INSERT INTO Entries
		(Id, ContentType,			 SourceUri, Text,   AtomId, DatePublished, Rights, Summary, Title,  DateUpdated,  IsDraft, CollectionId) VALUES
		(2,  'application/atom+xml', '2',		'blah', '222', GETUTCDATE(),   '',     '',      'test', GETUTCDATE(), 0,       1)
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (2, '2', 'TestMultipleCollectionFixedCategories', 1, GETUTCDATE(), '222222')

	INSERT INTO Entries
		(Id, ContentType,			 SourceUri, Text,   AtomId, DatePublished, Rights, Summary, Title,  DateUpdated,  IsDraft, CollectionId) VALUES
		(3,  'application/atom+xml', '3',		'blah', '333', GETUTCDATE(),   '',     '',      'test', GETUTCDATE(), 0,       2)	
	
	--INSERT INTO Collections(Id, Href, Title, AreCategoriesFixed, DateCreated, AtomId) VALUES (3, '3', 'TestMultipleCollectionFlexibleCategories', 0, GETUTCDATE(), '333333')
	
	INSERT INTO Entries
		(Id, ContentType,			 SourceUri, Text,   AtomId, DatePublished, Rights, Summary, Title,  DateUpdated,  IsDraft, CollectionId) VALUES
		(4,  'application/atom+xml', '4',		'blah', '444', GETUTCDATE(),   '',     '',      'test', GETUTCDATE(), 0,       3)	
	
	SET IDENTITY_INSERT Entries OFF;

END
GO