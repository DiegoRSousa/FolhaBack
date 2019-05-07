using FolhaBack.Models;
using FolhaBack.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FolhaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorController : ControllerBase
    {
        private TrabalhadorRepository trabalhadorRepository;

        public TrabalhadorController(IConfiguration configuration)
        {
            trabalhadorRepository = new TrabalhadorRepository(configuration);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(trabalhadorRepository.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id) 
        {
            var trabalhador = trabalhadorRepository.PorId(id);
            if(trabalhador != null)
                return Ok(trabalhador);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Trabalhador trabalhador) 
        {  
            if(ModelState.IsValid) 
            {
                trabalhadorRepository.Salvar(trabalhador);
                var uri = Url.Action("Get", new {id = trabalhador.Id});
                return Created(uri, trabalhador);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Trabalhador trabalhador)
        {
            if(ModelState.IsValid)
            {
                trabalhadorRepository.Alterar(trabalhador);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var trabalhador = trabalhadorRepository.PorId(id);
            if (trabalhador != null)
            {
                trabalhadorRepository.Excluir(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}