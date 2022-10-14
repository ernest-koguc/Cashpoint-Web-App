namespace DAL.Repositories
{
    public interface IRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> GetAll();
    }
}