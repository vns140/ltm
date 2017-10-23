namespace LTM.Infra.Repository.Repositories.Core
{
    public class RepositoryBase
    {
        protected readonly ContextProduto Db;

        public RepositoryBase()
        {
            Db = new ContextProduto();
        }
    }
}
