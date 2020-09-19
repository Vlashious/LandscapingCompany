using System;

namespace LandscapingCompany
{
    class ParkManager : ManagerAbstract
    {
        public static ParkManager Instance { get; private set; }
        static ParkManager()
        {
            Instance = new ParkManager();
        }
        private ParkManager() { }
        public override void Add()
        {
            Console.WriteLine("Enter the name of the park: ");
            var name = Console.ReadLine();

            _dbContext.ExecuteQuery($"INSERT INTO parks(name) VALUES('{name}')");
        }

        public override void Edit()
        {
            _dbContext.PrintTable("parks");
            Console.WriteLine("Enter the id of the park to edit: ");
            var id = Console.ReadLine();

            Console.WriteLine("Enter the new name of the park: ");
            var name = Console.ReadLine();

            _dbContext.ExecuteQuery($"UPDATE parks SET name='{name}' WHERE id={id}");
        }

        public override void PrintTable()
        {
            Console.Clear();
            _dbContext.PrintTable("parks");
            Console.ReadKey();
        }

        public override void Remove()
        {
            _dbContext.PrintTable("parks");
            Console.WriteLine("Enter the id of the park to delete: ");
            var id = Console.ReadLine();

            _dbContext.ExecuteQuery($"DELETE FROM parks WHERE id={id}");
        }
    }
}