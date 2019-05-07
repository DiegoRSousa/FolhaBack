using FolhaBack.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FolhaBack.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SumarioController : ControllerBase
    {
        private SumarioRepository sumarioRepository;

        public SumarioController(IConfiguration configuration)
        {
            this.sumarioRepository = new SumarioRepository(configuration);
        }

        [HttpGet]
        public ActionResult Get() 
        {
            return Ok(sumarioRepository.Get());
        } 
    }
}