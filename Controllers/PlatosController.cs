using Microsoft.AspNetCore.Mvc;
using L01_2022PD651_2022VZ650.Models;

namespace L01_2022PD651_2022VZ650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class platosController : ControllerBase
    {
        private readonly restauranteContext _context;
        public platosController(restauranteContext platosContexto)
        {
            _context = platosContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<platos> listadoPlatos = (from b in _context.platos
                                            select b).ToList();

            if (listadoPlatos.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoPlatos);
        }

        
    }
}
