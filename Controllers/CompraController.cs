using System.Collections.Generic;
using ApiCompras.Models;
using ApiCompras.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiCompras.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompraController
    {

        private readonly CompraRepository compraRepository;

        public CompraController(IConfiguration configuration)
        {
            compraRepository = new CompraRepository(configuration);
        }

        [HttpGet]
        public IEnumerable<Compra> Get()
        {
            return compraRepository.FindAll();
        }

        [HttpGet("{id}")]
        public Compra GetById(int id)
        {
            return compraRepository.FindByID(id);
        }

        [HttpPost]
        public int Add([FromBody] Compra compra)
        {
            return compraRepository.Add(compra);            
        }

    }

}