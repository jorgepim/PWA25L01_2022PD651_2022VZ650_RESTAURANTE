using Microsoft.AspNetCore.Mvc;
using L01_2022PD651_2022VZ650.Models;

namespace L01_2022PD651_2022VZ650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly restauranteContext _context;
        public PedidosController(restauranteContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Pedidos> pedidos = _context.Pedidos.ToList();
            if (pedidos.Count == 0)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("GetByCliente/{id}")]
        public IActionResult GetByCliente(int id)
        {
            var pedidos = (from p in _context.Pedidos
                           join c in _context.Clientes on p.clienteId equals c.clienteId
                           where p.clienteId == id
                           select new
                           {
                               p.pedidoId,
                               p.motoristaId,
                               p.clienteId,
                               c.nombreCliente,
                               p.platoId,
                               p.cantidad,
                               p.precio
                           });

            if (pedidos == null)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("GetByMotorista/{id}")]
        public IActionResult GetByMotorista(int id)
        {
            var pedidos = (from p in _context.Pedidos
                           join m in _context.Motoristas on p.motoristaId equals m.motoristaId
                           where p.motoristaId == id
                           select new
                           {
                               p.pedidoId,
                               p.motoristaId,
                               m.nombreMotorista,
                               p.clienteId,
                               p.platoId,
                               p.cantidad,
                               p.precio
                           });

            if (pedidos == null)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("GetTopClientes/{n}")]
        public IActionResult GetTopClientes(int n)
        {
            var pedidos = (from p in _context.Pedidos
                           join c in _context.Clientes on p.clienteId equals c.clienteId
                           group p by new { p.clienteId, c.nombreCliente } into g
                           select new
                           {
                               clienteId = g.Key.clienteId,
                               nombreCliente = g.Key.nombreCliente,
                               total = g.Sum(p => p.precio)
                           }).OrderByDescending(p => p.total).Take(n);
            if (pedidos == null)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult CrearPedido(Pedidos pedido)
        {
            try
            {
                _context.Pedidos.Add(pedido);
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
        public IActionResult UpdatePedido(int id, [FromBody] Pedidos pedido)
        {
            try
            {
                Pedidos pedidoUpdate = (from p in _context.Pedidos
                                        where p.pedidoId == id
                                        select p).FirstOrDefault();
                if (pedidoUpdate != null)
                {
                    pedidoUpdate.motoristaId = pedido.motoristaId;
                    pedidoUpdate.clienteId = pedido.clienteId;
                    pedidoUpdate.platoId = pedido.platoId;
                    pedidoUpdate.cantidad = pedido.cantidad;
                    pedidoUpdate.precio = pedido.precio;
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
        public IActionResult DeletePedido(int id)
        {
            try
            {
                Pedidos pedido = (from p in _context.Pedidos
                                  where p.pedidoId == id
                                  select p).FirstOrDefault();
                if (pedido != null)
                {
                    _context.Pedidos.Remove(pedido);
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
