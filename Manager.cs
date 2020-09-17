using System;

namespace LandscapingCompany
{
    class Manager
    {
        private IManager _manager;
        internal void Switch(string input)
        {
            switch (input)
            {
                case "1":
                    _manager = FirmManager.Manager;
                    break;
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
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
        }

        private string GetInput()
        {
            Console.WriteLine("1 - add");
            Console.WriteLine("2 - edit");
            Console.WriteLine("3 - delete");
            Console.WriteLine("4 - return");

            return Console.ReadLine();
        }
    }
}