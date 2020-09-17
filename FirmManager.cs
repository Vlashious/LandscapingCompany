namespace LandscapingCompany
{
    class FirmManager : IManager
    {
        public static FirmManager Manager { get; private set; }
        static FirmManager()
        {
            Manager = new FirmManager();
        }
        private FirmManager() { }



        public void Add()
        {

        }

        public void Edit()
        {

        }

        public void Remove()
        {

        }
    }
}