using Alunos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alunos.Controllers
{
    public class ClienteController : Controller
    {
        private List<ClienteModel> _clientes;
        public static List<ClienteModel> clientes = new List<ClienteModel>();

        public ClienteController() { // Quando a Controller for chamada será gerado a lista de clientes
            _clientes = ListarClientes();
        }

        public static List<ClienteModel> ListarClientes() //Método de listar clientes
        {
            return clientes;
        }

        //Pages
        [Route("")]
        public IActionResult Index()
        {
            return View(_clientes); //Passando a lista de clientes para a View Index()
        }
        

        [Route("novo")]
        public IActionResult PageCreateCliente()
        {
            return View();
        }

        [Route("editar/{id}")]
        public IActionResult PageUpdateCliente(int id)
        {
            ClienteModel? clienteOptional = clientes.Find(c => c.ClienteId == id);
            return View(clienteOptional);
        }

        [Route("consultar/{id}")]
        public IActionResult PageConsultCliente(int id)
        {
            ClienteModel? clienteOptional = clientes.Find(c => c.ClienteId == id);
            return View(clienteOptional);
        }

        //Metódos para manipular a lista
        [HttpPost]
        public IActionResult AddCliente(ClienteModel cliente)
        {
            clientes.Add(cliente);
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult UpdateCliente(ClienteModel cliente)
        {
            ClienteModel? clienteOptional = clientes.Find(c => c.ClienteId == cliente.ClienteId);
            if (clienteOptional != null)
            {
                clientes.Remove(clienteOptional);
                clientes.Add(cliente);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCliente(int id) 
        {
            ClienteModel? cliente = clientes.Find(c => c.ClienteId == id);
            if (cliente != null) {
                clientes.Remove(cliente);
            }
            return RedirectToAction("Index");
        }
    }
}
