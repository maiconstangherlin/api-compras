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

        public override int Add(Compra compra)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                compra.compraId = (int)dbConnection.Query<int>(
                    @"INSERT Compra (DataHora, Atendente, TipoPagamento)
                             VALUES (@DataHora, @Atendente, @TipoPagamento); 
                     SELECT SCOPE_IDENTITY() ", compra).FirstOrDefault();

                if (compra.compraId > 0)
                {
                    dbConnection.Execute(
                        @"INSERT CompraItem (CompraId, ProdutoId, Quantidade)
                                      VALUES (@CompraId, @ProdutoId, @Quantidade)",
                                    compra.compraItens.Select(item =>
                                    {
                                        return new
                                        {
                                            CompraId = compra.compraId,
                                            ProdutoId = item.produto.produtoId,
                                            Quantidade = item.quantidade
                                        };
                                    })
                        );
                }

                return compra.compraId;
            }

        }

        public override IEnumerable<Compra> FindAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
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
                            if (produto != null)
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
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                var compraDictionary = new Dictionary<int, Compra>();

                return dbConnection.Query<Compra, CompraItem, Produto, Compra>(
                    @"SELECT * FROM Compra 
                    LEFT JOIN CompraItem ON Compra.CompraId = CompraItem.CompraId
                    LEFT JOIN Produto ON CompraItem.ProdutoId = Produto.ProdutoId
                    WHERE Compra.compraId = @compraId",
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
                            if (produto != null)
                                compraItem.produto = produto;

                            compraEntry.compraItens.Add(compraItem);
                        }
                        return compraEntry;
                    },
                    splitOn: "compraId, compraItemId, produtoId",
                    param: new { @compraId = id }).FirstOrDefault();
            }
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