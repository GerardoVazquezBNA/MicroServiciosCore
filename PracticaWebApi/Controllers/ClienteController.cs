using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaWebApi.Entidades;

namespace PracticaWebApi.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>{
            new Cliente { Id = 1, Nombre = "Gerardo", Apellido= "Vazquez", NroDocumento=38869662, TipoDocumento ="DU" , Cuil= "20388696622", EsEmpleadoBNA = true, PaisOrigen= "ARGENTINA"},
            new Cliente { Id = 2, Nombre = "Ezequiel", Apellido= "Goncalvez", NroDocumento=12345678, TipoDocumento ="DU" , Cuil= "204444442", EsEmpleadoBNA = true, PaisOrigen= "ARGENTINA"},
            new Cliente { Id = 3, Nombre = "Diego", Apellido= "Yasil", NroDocumento=12345678, TipoDocumento ="DU" , Cuil= "2033333332", EsEmpleadoBNA = true, PaisOrigen= "ARGENTINA"},
            new Cliente { Id = 4, Nombre = "Leonardo", Apellido= "Etchegoyen", NroDocumento=12345678, TipoDocumento ="DU" , Cuil= "2033333332", EsEmpleadoBNA = true, PaisOrigen= "ARGENTINA"}
        };


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
            //clienteNuevo = new Cliente();
            //clienteNuevo.Id = cliente.Id;
            //clienteNuevo.Nombre = cliente.Nombre;
            //clienteNuevo.Apellido = cliente.Apellido;
            //clienteNuevo.Cuil = cliente.Cuil;
            //clienteNuevo.TipoDocumento = cliente.TipoDocumento;
            //clienteNuevo.NroDocumento = cliente.NroDocumento;
            //clienteNuevo.EsEmpleadoBNA = cliente.EsEmpleadoBNA;
            //clienteNuevo.PaisOrigen = cliente.PaisOrigen;
            //clientes.Add(clienteNuevo);
            clientes.Add(cliente);
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


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            Cliente clienteElimnar = clientes.FirstOrDefault(c => c.Id == id);
            if (clienteElimnar == null)
            {
                return ValidationProblem();
            }
         
            clientes.Remove(clienteElimnar);
            return Ok();
        }


    }
}
