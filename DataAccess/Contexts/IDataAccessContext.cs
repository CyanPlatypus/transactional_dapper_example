namespace DataAccess.Contexts
{
    public interface IDataAccessContext
    {
        public Task Commit();
        //public Task Rollback();
    }
}