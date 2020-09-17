using System;
using Npgsql;

namespace LandscapingCompany
{
    class DbContext
    {
        public static DbContext Instance { get; private set; }
        static DbContext()
        {
            Instance = new DbContext();
        }
        private DbContext() { }

        private static string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=pbv";
        private NpgsqlConnection _connection = new NpgsqlConnection(connectionString);
        private string _query = "";

        private void OpenConnection()
        {
            _connection.Open();
        }

        public void AddToTable(string table, params string[] data)
        {
            OpenConnection();
            _query = table switch
            {
                "firm" => $"INSERT INTO firm(name, address) VALUES('{data[0]}', '{data[1]}')",
                _ => throw new Exception("Table does not exist.")
            };
            using var cmd = new NpgsqlCommand(_query, _connection);

            cmd.ExecuteNonQuery();

            Console.WriteLine($"Data to table {table} has been inserted!");
        }
    }
}