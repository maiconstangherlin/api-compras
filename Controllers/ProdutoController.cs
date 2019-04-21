using System.Collections.Generic;
using ApiCompras.Models;
using ApiCompras.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController(IConfiguration configuration)
        {
            produtoRepository = new ProdutoRepository(configuration);
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            //return new string[] { "value1", "value2" };
            return produtoRepository.FindAll();
        }
    }

}