using System;

namespace LandscapingCompany
{
    class FirmManager : ManagerAbstract
    {
        public static FirmManager Instance { get; private set; }
        static FirmManager()
        {
            Instance = new FirmManager();
        }
        private FirmManager() { }

        public override void Add()
        {
            Console.WriteLine("Enter the name and the address of the new firm in one line through comma: ");
            var data = Console.ReadLine().Split(",");
            _dbContext.ExecuteQuery($"INSERT INTO firm(name, address) VALUES('{data[0]}', '{data[1]}')");
        }

        public override void Edit()
        {
            PrintTable();
            Console.WriteLine("Enter the id of the firm to edit: ");
            var id = Console.ReadLine();

            Console.WriteLine("Enter new name and address in one line through comma: ");
            var data = Console.ReadLine().Split(",");
            _dbContext.ExecuteQuery($"UPDATE firm SET name='{data[0]}', address='{data[1]}' WHERE id={id}");
        }

        public override void Remove()
        {
            _dbContext.PrintTable("firm");
            Console.WriteLine("Enter the id of the firm to delete: ");
            var id = Console.ReadLine();

            _dbContext.ExecuteQuery($"DELETE FROM firm WHERE id={id}");
        }

        public override void PrintTable()
        {
            Console.Clear();
            _dbContext.PrintTable("firm");
            Console.ReadKey();
        }
    }
}