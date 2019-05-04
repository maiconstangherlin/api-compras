using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Repositories
{
    public abstract class AbstractRepository<T>
    {
        private string _connectionString;
        protected string connectionString => _connectionString;
        public AbstractRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:MaterDei");
        }
        public abstract int Add(T item);
        public abstract void Remove(int id);
        public abstract void Update(T item);
        public abstract T FindByID(int id);
        public abstract IEnumerable<T> FindAll();
    }
}