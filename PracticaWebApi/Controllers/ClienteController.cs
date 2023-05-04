using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaWebApi.Entidades;

namespace PracticaWebApi.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();

        


        [HttpGet]
        public IEnumerable<Cliente> ListarClientes()
        {
            return clientes;
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return clientes.FirstOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public IActionResult AgregarCliente([FromBody] Cliente cliente)
        {
            var clienteNuevo = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteNuevo != null)
            {
                return ValidationProblem();
            }
            clienteNuevo = new Cliente();
            clienteNuevo.Id = cliente.Id;
            clienteNuevo.Nombre = cliente.Nombre;
            clienteNuevo.Apellido = cliente.Apellido;
            clienteNuevo.Cuil = cliente.Cuil;
            clienteNuevo.TipoDocumento = cliente.TipoDocumento;
            clienteNuevo.NroDocumento = cliente.NroDocumento;
            clienteNuevo.EsEmpleadoBNA = cliente.EsEmpleadoBNA;
            clienteNuevo.PaisOrigen = cliente.PaisOrigen;
            clientes.Add(clienteNuevo);
            return Ok();
        }

        [HttpPut]
        public IActionResult ActualizarCliente([FromBody] Cliente cliente)
        {
            var clienteExistente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if(clienteExistente == null)
            {
                return NotFound();
            }
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellido = cliente.Apellido;
            clienteExistente.Cuil = cliente.Cuil;
            clienteExistente.TipoDocumento = cliente.TipoDocumento;
            clienteExistente.NroDocumento = cliente.NroDocumento;
            clienteExistente.EsEmpleadoBNA = cliente.EsEmpleadoBNA;
            clienteExistente.PaisOrigen = cliente.PaisOrigen;


            return Ok();
        }

        
    }
}
