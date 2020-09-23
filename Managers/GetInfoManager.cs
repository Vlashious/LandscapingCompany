using System;

namespace LandscapingCompany
{
    class GetInfoManager
    {
        private static DbContext _dbContext = DbContext.Instance;
        public static void GetSpecificPlantInfo()
        {
            Console.WriteLine("Enter the type of plant: ");
            var type = Console.ReadLine();
            var query = $"SELECT * FROM plants WHERE plants.plant_type='{type}'";
            _dbContext.PrintTableFromQuery(query);
            Console.ReadKey();
        }

        public static void GetWorkerList()
        {
            Console.WriteLine("Enter the date (yyyy-mm-dd): ");
            var date = Console.ReadLine();
            var query = ($@"SELECT w.first_name, w.last_name, w.phone FROM workers w
                        JOIN schedule s ON s.worker_id = w.id
                        WHERE s.plant_watering_time='{date}'
                        ");

            _dbContext.PrintTableFromQuery(query);
            Console.ReadKey();
        }

        public static void GetPlantsOnSpecificDateAndTheirWateringRegime()
        {
            Console.WriteLine("Enter the plant type and date through comma:");
            var data = Console.ReadLine().Split(",");
            var query = ($@"SELECT p.*, pw.regularity, pw.watering_time, pw.litres FROM plants p, plant_watering pw
                        WHERE p.plant_type=pw.plant_type AND p.plant_type='{data[0]}' AND pw.watering_time='{data[1]}';"
                        );

            _dbContext.PrintTableFromQuery(query);
            Console.ReadKey();
        }
    }
}