using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ApiCompras.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Repositories
{

    public class CompraRepository : AbstractRepository<Compra>
    {
        public CompraRepository(IConfiguration configuration) : base(configuration) { }

        public override void Add(Compra item)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Compra> FindAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();

                var compraDictionary = new Dictionary<int, Compra>();

                return dbConnection.Query<Compra, CompraItem, Produto, Compra>(
                    @"SELECT * FROM Compra 
                    LEFT JOIN CompraItem ON Compra.CompraId = CompraItem.CompraId
                    LEFT JOIN Produto ON CompraItem.ProdutoId = Produto.ProdutoId",
                    map: (compra, compraItem, produto) =>
                    {
                        if (!compraDictionary.TryGetValue(compra.compraId, out var compraEntry))
                        {
                            compraEntry = compra;
                            compraEntry.compraItens = new List<CompraItem>();
                            compraDictionary.Add(compraEntry.compraId, compraEntry);
                        }
                        if (compraItem != null)
                        {
                            if(produto != null) 
                                compraItem.produto = produto;
                            
                            compraEntry.compraItens.Add(compraItem);
                        }
                        return compraEntry;
                    },
                    splitOn: "compraId, compraItemId, produtoId")
                    .Distinct().ToList();
            }
        }

        public override Compra FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Compra item)
        {
            throw new System.NotImplementedException();
        }
    }
}