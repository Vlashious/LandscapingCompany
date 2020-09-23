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

        private void OpenConnection()
        {
            _connection.Open();
        }

        private void CloseConnection()
        {
            _connection.Close();
        }

        public void ExecuteQuery(string query)
        {
            OpenConnection();
            using var cmd = new NpgsqlCommand(query, _connection);

            cmd.ExecuteNonQuery();
            CloseConnection();

            Console.WriteLine("Query executed!");
        }

        public void PrintTable(string table)
        {
            var query = $"SELECT * FROM {table}";
            OpenConnection();

            using var cmd = new NpgsqlCommand(query, _connection);
            using var reader = cmd.ExecuteReader();
            var data = GetColumnNames(reader);

            Console.WriteLine(data.formatting, data.columns);
            while (reader.Read())
            {
                Console.WriteLine(data.formatting, GetRowData(reader));
            }

            CloseConnection();
        }

        public void PrintTableFromQuery(string query)
        {
            OpenConnection();

            using var cmd = new NpgsqlCommand(query, _connection);
            using var reader = cmd.ExecuteReader();
            var data = GetColumnNames(reader);

            Console.WriteLine(data.formatting, data.columns);
            while (reader.Read())
            {
                Console.WriteLine(data.formatting, GetRowData(reader));
            }

            CloseConnection();
        }

        private (string[] columns, string formatting) GetColumnNames(NpgsqlDataReader reader)
        {
            string[] columns = new string[reader.VisibleFieldCount];
            string formatting = "";
            for (int i = 0; i < reader.VisibleFieldCount; i++)
            {
                columns[i] = reader.GetName(i);
                formatting += "{" + i + ", -15}";
            }

            return (columns, formatting);
        }

        private string[] GetRowData(NpgsqlDataReader reader)
        {
            string[] data = new string[reader.VisibleFieldCount];
            for (int i = 0; i < reader.VisibleFieldCount; i++)
            {
                data[i] = reader.GetValue(i).ToString();
            }

            return data;
        }
    }
}