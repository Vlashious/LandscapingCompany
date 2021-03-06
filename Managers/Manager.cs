using System;

namespace LandscapingCompany
{
    class Manager
    {
        private ManagerAbstract _manager;
        public void Switch(string input)
        {
            switch (input)
            {
                case "1":
                    _manager = FirmManager.Instance;
                    break;
                case "2":
                    _manager = ParkManager.Instance;
                    break;
                case "3":
                    _manager = ParkZoneManager.Instance;
                    break;
                case "4":
                    _manager = PlantManager.Instance;
                    break;
                case "5":
                    _manager = ParkWorkerManager.Instance;
                    break;
                case "6":
                    _manager = ParkDecoratorManager.Instance;
                    break;
                case "7":
                    GetInfoManager.GetSpecificPlantInfo();
                    return;
                case "8":
                    GetInfoManager.GetWorkerList();
                    return;
                case "9":
                    GetInfoManager.GetPlantsOnSpecificDateAndTheirWateringRegime();
                    return;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
            input = GetInput();
            SwitchAction(input);
        }

        private void SwitchAction(string input)
        {
            switch (input)
            {
                case "1":
                    _manager.Add();
                    break;
                case "2":
                    _manager.Edit();
                    break;
                case "3":
                    _manager.Remove();
                    break;
                case "4":
                    _manager.PrintTable();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
        }

        private string GetInput()
        {
            Console.Clear();
            Console.WriteLine("1 - add");
            Console.WriteLine("2 - edit");
            Console.WriteLine("3 - delete");
            Console.WriteLine("4 - print table");
            Console.WriteLine("0 - return");

            return Console.ReadLine();
        }
    }
}