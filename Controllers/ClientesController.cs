using L01_2022PD651_2022VZ650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L01_2022PD651_2022VZ650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly restauranteContext _context;
        public ClientesController(restauranteContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Clientes> clientes = _context.Clientes.ToList();
            if (clientes.Count == 0)
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        [HttpGet]
        [Route("GetByAdress/{direccion}")]
        public IActionResult GetByAdress(string direccion)
        {
            List<Clientes> clientes = (from c in _context.Clientes
                                       where c.direccion.Contains(direccion)
                                       select c).ToList();
            if (clientes.Count == 0)
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CrearCliente(Clientes cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
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
        public IActionResult UpdateCliente(int id, [FromBody] Clientes cliente)
        {
            try
            {
                Clientes clienteUpdate = (from c in _context.Clientes
                                          where c.clienteId == id
                                          select c).FirstOrDefault();
                if (clienteUpdate != null)
                {
                    clienteUpdate.nombreCliente = cliente.nombreCliente;
                    clienteUpdate.direccion = cliente.direccion;
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

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            //try
            //{
            //    Clientes cliente = (from c in _context.Clientes
            //                        where c.clienteId == id
            //                        select c).FirstOrDefault();
            //    if (cliente != null)
            //    {
            //        List<Pedidos> pedidos = (from p in _context.Pedidos
            //                                 where p.pedidoId == id
            //                                 select p).ToList();
            //        if (pedidos != null)
            //        {
            //            return Conflict("Este cliente tiene pedidos asociados. ¿Está seguro de que desea eliminarlos?");
            //            _context.Pedidos.RemoveRange(pedidos);
            //        }
            //        _context.Clientes.Remove(cliente);
            //        _context.SaveChanges();
            //        return Ok();
            //    }
            //    return NotFound();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            try
            {
                Clientes cliente = (from c in _context.Clientes
                                    where c.clienteId == id
                                    select c).FirstOrDefault();
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
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
