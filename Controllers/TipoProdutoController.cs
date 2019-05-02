using System.Collections.Generic;
using ApiCompras.Models;
using ApiCompras.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly TipoProdutoRepository tipoProdutoRepository;

        public TipoProdutoController(IConfiguration configuration)
        {
            tipoProdutoRepository = new TipoProdutoRepository(configuration);
        }

        [HttpGet]
        public IEnumerable<TipoProduto> Get()
        {
            return tipoProdutoRepository.FindAll();
        }

        [HttpGet("{id}")]
        public TipoProduto GetById(int id)
        {
            return tipoProdutoRepository.FindByID(id);
        }
    }

}