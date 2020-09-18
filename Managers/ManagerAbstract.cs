namespace LandscapingCompany
{
    abstract class ManagerAbstract
    {
        protected DbContext _dbContext = DbContext.Instance;
        abstract public void Add();
        abstract public void Edit();
        abstract public void Remove();
        abstract public void PrintTable();
    }
}