using System;

namespace LandscapingCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            Manager manager = new Manager();
            while (loop)
            {
                var inputRes = GetInput();
                loop = inputRes.loop;
                if (loop)
                {
                    manager.Switch(inputRes.input);
                }
                else break;
            }
        }

        private static (string input, bool loop) GetInput()
        {
            Console.Clear();
            Console.WriteLine("1 - add/edit/delete firm info");
            Console.WriteLine("2 - add/edit/delete parks info");
            Console.WriteLine("3 - add/edit/delete park zones info");
            Console.WriteLine("4 - add/edit/delete plants info");
            Console.WriteLine("5 - add/edit/delete workers info");
            Console.WriteLine("6 - add/edit/delete park decorators info");
            Console.WriteLine("7 - get info about specific type of plant");
            Console.WriteLine("8 - get worker lsit for specific time");
            Console.WriteLine("9 - get all specific plants on time and the watering regime for them");
            Console.WriteLine("0 - exit");
            var input = Console.ReadLine();
            return (input, input != "0");
        }
    }
}
