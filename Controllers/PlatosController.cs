using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022PD651_2022VZ650;
using L01_2022PD651_2022VZ650.Models;

namespace L01_2022PD651_2022VZ650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class platosController : ControllerBase
    {
        private readonly platosContext _platosContext;
        public platosController(platosContext platosContexto)
        {
            _platosContext = platosContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<platos> listadoPlatos = (from b in _platosContext.platos
                                            select b).ToList();

            if (listadoPlatos.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoPlatos);
        }

        
    }
}
