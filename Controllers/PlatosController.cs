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

        [HttpGet]
        [Route("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            List<platos> platos = (from p in _context.platos
                                   where p.nombrePlato.Contains(name)
                                   select p).ToList();
            if (platos.Count == 0)
            {
                return NotFound();
            }
            return Ok(platos);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CrearPlato(platos plato)
        {
            try
            {
                _context.platos.Add(plato);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdatePlato(int id, [FromBody] platos plato)
        {
            try
            {
                platos platoExistente = (from p in _context.platos
                                      where p.platoId == id select p).FirstOrDefault();
                if (platoExistente != null)
                {
                    platoExistente.nombrePlato = plato.nombrePlato;
                    platoExistente.precio = plato.precio;
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeletePlato(int id)
        {
            try
            {
                platos plato = (from p in _context.platos
                                where p.platoId == id
                                select p).FirstOrDefault();
                if (plato != null)
                {
                    _context.platos.Remove(plato);
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
