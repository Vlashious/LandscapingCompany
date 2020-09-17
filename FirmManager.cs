namespace LandscapingCompany
{
    class FirmManager : ManagerAbstract
    {
        public static FirmManager Manager { get; private set; }
        static FirmManager()
        {
            Manager = new FirmManager();
        }
        private FirmManager() { }

        public override void Add()
        {
            _dbContext.AddToTable("firm", "Francysk", "vul. Savieckaja 63");
        }

        public override void Edit()
        {

        }

        public override void Remove()
        {

        }
    }
}