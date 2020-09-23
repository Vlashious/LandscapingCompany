using System;

namespace LandscapingCompany
{
    class ParkDecoratorManager : ManagerAbstract
    {
        public static ParkDecoratorManager Instance { get; private set; } = new ParkDecoratorManager();
        private ParkDecoratorManager() { }
        public override void Add()
        {
            Console.WriteLine("Enter the first name, last name, phone, address, education, education facility name, catrgory through comma: ");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($@"INSERT INTO park_decorators VALUES(
                first_name='{data[0]}', last_name='{data[1]}', phone='{data[2]}', address='{data[3]}', education='{data[4]}',
                education_facility_name='{data[5]}', category='{data[6]}'
                )");
        }

        public override void Edit()
        {
            _dbContext.PrintTable("park_decorators");
            Console.WriteLine("Enter the id of the decorator to edit: ");
            var id = Console.ReadLine();

            Console.WriteLine("Enter the new first name, last name, phone, address, education, education facility name, catrgory through comma:");
            var data = Console.ReadLine();

            _dbContext.ExecuteQuery($@"UPDATE park_decorators SET
                first_name='{data[0]}', last_name='{data[1]}', phone='{data[2]}', address='{data[3]}', education='{data[4]}',
                education_facility_name='{data[5]}', category='{data[6]}
                WHERE id={id}");
        }

        public override void PrintTable()
        {
            Console.Clear();
            _dbContext.PrintTable("park_decorators");
            Console.ReadKey();
        }

        public override void Remove()
        {
            _dbContext.PrintTable("park_decorators");
            Console.WriteLine("Enter the id of the decorator to remove: ");
            var id = Console.ReadLine();

            _dbContext.ExecuteQuery($"DELETE FROM park_decoratos WHERE id={id}");
        }
    }
}