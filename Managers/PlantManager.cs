using System;

namespace LandscapingCompany
{
    class PlantManager : ManagerAbstract
    {
        public static PlantManager Instance { get; private set; }
        static PlantManager()
        {
            Instance = new PlantManager();
        }
        private PlantManager() { }
        public override void Add()
        {
            _dbContext.PrintTable("park_zones");
            Console.WriteLine("Enter plant id, zone id, planting date (yyyy-mm-dd), age, plant type through comma: ");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($@"
            INSERT INTO plants VALUES(
                {data[0]},{data[1]},'{data[2]}',{data[3]},'{data[4]}')");
        }

        public override void Edit()
        {
            _dbContext.PrintTable("plants");
            Console.WriteLine("Enter the plant id and zone id of the plant to edit through comma: ");
            var ids = Console.ReadLine().Split(",");

            Console.WriteLine("Enter new plant id, zone id, planting date (yyyy-mm-dd), age, plant type through comma: ");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($@"
            UPDATE plants SET plants id={data[0]}, park_zone={data[1]}, planting_date='{data[2]}', age={data[3]}, plant_type='{data[4]}'
            WHERE id={ids[0]} AND park_zone={ids[1]}");

        }

        public override void PrintTable()
        {
            Console.Clear();
            _dbContext.PrintTable("plants");
            Console.ReadKey();
        }

        public override void Remove()
        {
            _dbContext.PrintTable("plants");
            Console.WriteLine("Enter the plant id and zone id of the plant to delete through comma: ");
            var ids = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($"DELETE FROM plants WHERE id={ids[0]} AND park_zone={ids[1]}");
        }
    }
}