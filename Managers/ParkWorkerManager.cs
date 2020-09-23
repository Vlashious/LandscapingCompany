using System;

namespace LandscapingCompany
{
    class ParkWorkerManager : ManagerAbstract
    {
        public static ParkWorkerManager Instance { get; private set; } = new ParkWorkerManager();
        private ParkWorkerManager() { }
        public override void Add()
        {
            Console.WriteLine("Enter the first name, last name, phone, address of the worker through commas:");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($@"INSERT INTO workers VALUES(
                '{data[0]}', '{data[1]}', '{data[2]}', '{data[3]}'
                )");
        }

        public override void Edit()
        {
            _dbContext.PrintTable("workers");
            Console.WriteLine("Enter the id of the worker to edit: ");
            var id = Console.ReadLine();

            Console.WriteLine("Enter the new first name, last name, phone, address of the worker through commas:");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($@"UPDATE workers SET
                last_name='{data[0]}', first_name='{data[1]}', phone='{data[2]}', address='{data[3]}'
                WHERE id={id}");
        }

        public override void PrintTable()
        {
            Console.Clear();
            _dbContext.PrintTable("workers");
            Console.ReadKey();
        }

        public override void Remove()
        {
            _dbContext.PrintTable("workers");
            Console.WriteLine("Enter the id of the worker to remove: ");
            var id = Console.ReadLine();

            _dbContext.ExecuteQuery($"DELETE FROM workers WHERE id={id}");
        }
    }
}