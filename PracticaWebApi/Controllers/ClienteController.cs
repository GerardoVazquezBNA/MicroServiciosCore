using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaWebApi.Entidades;

namespace PracticaWebApi.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();


        [HttpGet]
        public IEnumerable<Cliente> ListarClietnes()
        {
            return clientes;
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = 1;
            cliente.Nombre = "Gerardo";
            cliente.Apellido = "Vazquez";
            cliente.Cuil = "132245";
            cliente.TipoDocumento = "DU";
            cliente.NroDocumento = 38869662;
            cliente.EsEmpleadoBNA = true;
            cliente.PaisOrigen = "ARGENTINA";

            clientes.Add(cliente);

            return clientes.FirstOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public IActionResult AgregarCliente([FromBody] Cliente cliente)
        {
            var clienteExistente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteExistente == null)
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

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            clientes.Add(cliente);
            return Ok();

        }

        //// GET: ClienteController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ClienteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ClienteController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ClienteController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ClienteController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ClienteController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
