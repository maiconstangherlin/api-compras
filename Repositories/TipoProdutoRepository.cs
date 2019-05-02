using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ApiCompras.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Repositories
{

    public class TipoProdutoRepository : AbstractRepository<TipoProduto>
    {
        public TipoProdutoRepository(IConfiguration configuration) : base(configuration) { }

        public override void Add(TipoProduto item)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<TipoProduto> FindAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<TipoProduto>("SELECT * FROM TipoProduto");
            }
        }

        public override TipoProduto FindByID(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<TipoProduto>(
                    "SELECT * FROM TipoProduto " +
                    "WHERE TipoProdutoId = @tipoProdutoId",
                    new {@tipoProdutoId = id});                   
            }
        }

        public override void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(TipoProduto item)
        {
            throw new System.NotImplementedException();
        }
    }
}