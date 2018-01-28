namespace customers.management.impl.EF.Repo
{
    public class BaseRepository
    {
        protected CustomersContext Context { get; private set; }

        protected BaseRepository(CustomersContext context)
        {
            Context = context;
        }
    }
}
