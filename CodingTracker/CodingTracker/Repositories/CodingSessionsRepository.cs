using Dapper;
using System.Data.SQLite;

namespace CodingTracker.Repositories
{
    internal class CodingSessionsRepository
    {
        private static CodingSessionsRepository? _instance;

        //What is better pass the connection string or pass the configuration?
        //This class should not care about where is the connection string, since the connection string is the only thing relevant for this class

        public static string? ConnectionString
        {
            get;
            set
            {
                if (_instance != null)
                {
                    throw new InvalidOperationException("Cannot change connection string, instance has already been initialized.");
                }
                field = value;
            }
        }

        public static CodingSessionsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (ConnectionString == null)
                    {
                        throw new InvalidOperationException("Instance cannot be created until the connection string is set.");
                    }
                    _instance = new CodingSessionsRepository();
                }
                return _instance;
            }
        }

        //Connection does not need to be opened? Is it opened internally?
        //Move the open close statements to separate test method
        private CodingSessionsRepository()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            connection.Close();
        }

        public void CreateTable()
        {
            var sql = "CREATE TABLE CodingSessions (StartDate DATETIME NOT NULL, EndDate DATETIME NOT NULL, id INTEGER, PRIMARY KEY(id AUTOINCREMENT));";

            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute(sql);
        }
    }
}
