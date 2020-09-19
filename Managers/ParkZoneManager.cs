using System;

namespace LandscapingCompany
{
    class ParkZoneManager : ManagerAbstract
    {
        public static ParkZoneManager Instance { get; private set; }
        static ParkZoneManager()
        {
            Instance = new ParkZoneManager();
        }
        private ParkZoneManager() { }
        public override void Add()
        {
            _dbContext.PrintTable("parks");
            Console.WriteLine("Enter the name of the zone and zone's park id through comma: ");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($"INSERT INTO park_zones(name, park_id) VALUES('{data[0]}', {data[1]})");
        }

        public override void Edit()
        {
            _dbContext.PrintTable("parks");
            _dbContext.PrintTable("zone_parks");

            Console.WriteLine("Enter the id of the zone to edit: ");
            var id = Console.ReadLine();

            Console.WriteLine("Enter new name and id for the selected zone: ");
            var data = Console.ReadLine().Split(",");

            _dbContext.ExecuteQuery($"UPDATE park_zones SET name='{data[0]}', park_id={data[1]} WHERE id={id}");
        }

        public override void PrintTable()
        {
            Console.Clear();
            _dbContext.PrintTable("park_zones");
            Console.ReadKey();
        }

        public override void Remove()
        {
            _dbContext.PrintTable("zone_parks");

            Console.WriteLine("Enter the id of the zone to delete: ");
            var id = Console.ReadLine();

            _dbContext.ExecuteQuery($"DELETE FROM park_zones WHERE id={id}");
        }
    }
}