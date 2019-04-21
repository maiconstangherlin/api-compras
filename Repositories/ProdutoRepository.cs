using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ApiCompras.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Repositories
{

    public class ProdutoRepository : AbstractRepository<Produto>
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration) { }

        public override void Add(Produto item)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Produto> FindAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Produto>("SELECT * FROM Produtos");
            }
        }

        public override Produto FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Produto item)
        {
            throw new System.NotImplementedException();
        }
    }
}