using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ApiCompras.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Repositories
{

    public class ProdutoRepository : AbstractRepository<Produto>
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration) { }

        public override int Add(Produto item)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Produto> FindAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Produto, TipoProduto, Produto>(
                    "SELECT * FROM Produto " +
                    "LEFT JOIN TipoProduto ON Produto.TipoProdutoId = TipoProduto.TipoProdutoId",
                    map: (produto, tipoProduto) =>
                    {
                        produto.tipoProduto = tipoProduto;
                        return produto;
                    },
                    splitOn: "produtoId, tipoProdutoId");
            }
        }

        public override Produto FindByID(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                return dbConnection.Query<Produto, TipoProduto, Produto>(
                    "SELECT * FROM Produto " +
                    "LEFT JOIN TipoProduto ON Produto.TipoProdutoId = TipoProduto.TipoProdutoId " +
                    "WHERE ProdutoId=@produtoId",
                    map: (produto, tipoProduto) =>
                    {
                        produto.tipoProduto = tipoProduto;
                        return produto;
                    },
                    splitOn: "produtoId, tipoProdutoId",
                    param: new { @produtoId = id }).FirstOrDefault();
            }
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