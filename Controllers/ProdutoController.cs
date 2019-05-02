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
            return produtoRepository.FindAll();
        }

        [HttpGet("{id}")]
        public Produto GetById(int id)
        {
            return produtoRepository.FindByID(id);
        }
    }

}