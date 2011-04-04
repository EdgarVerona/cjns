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
            /*SqlConnection conn = new SqlConnection("TEST");
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM ";*/
        }

    }
}
