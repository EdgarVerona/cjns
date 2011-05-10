using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitizenJournalismNetworkServer.Domain.Models;
using CitizenJournalismNetworkServer.Domain.Repositories;
using System.Data.Entity;
using System.Data.Entity.Database;
using System.Data.Common;
using System.Data.SqlClient;


namespace CitizenJournalismNetworkServer.AcceptanceTest.TestHelpers
{
    public class TestDatabaseHelper
    {

        public static void ClearDatabase()
        {
            SqlConnection conn = new SqlConnection("TEST");
            SqlCommand command = new SqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM EntryCategories;");
            sql.Append("DELETE FROM CollectionCategories;");
            sql.Append("DELETE FROM CollectionContentTypes;");
            sql.Append("DELETE FROM WorkspaceCollections;");
            sql.Append("DELETE FROM EntryAuthors;");
            sql.Append("DELETE FROM EntryContributors;");
            sql.Append("DELETE FROM Links;");
            sql.Append("DELETE FROM Categories;");
            sql.Append("DELETE FROM ContentTypes");
            sql.Append("DELETE FROM Workspaces;");
            sql.Append("DELETE FROM People;");
            sql.Append("DELETE FROM Entries;");
            sql.Append("DELETE FROM Collections;");

            command.CommandText = sql.ToString();
            command.CommandType = System.Data.CommandType.Text;

            command.ExecuteNonQuery();
        }

        public static IList<ContentType> CreateTestContentTypes()
        {
            List<ContentType> results = new List<ContentType>();

            ContentTypeRepository repo = new ContentTypeRepository();

            ContentType item = new ContentType()
            {
                Text = "text"
            };

            results.Add(item);
            repo.Add(item);

            item = new ContentType()
            {
                Text = "html"
            };

            results.Add(item);
            repo.Add(item);

            item = new ContentType()
            {
                Text = "xhtml"
            };

            results.Add(item);
            repo.Add(item);

            repo.Save();

            return results;
        }


        public static Collection CreateTestCollection(string title)
        {
            Collection result = new Collection()
            {
                AreCategoriesFixed = true,
                AtomId = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow,
                Title = title
            };

            return result;
        }

    }
}
