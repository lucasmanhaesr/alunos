using Alunos.Data.Contexts;
using Alunos.Models;
using Alunos.Services.Interface;
using Alunos.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alunos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly List<ClienteModel> _clientes;
        private readonly ClienteService _clienteService;
        
        public ClienteController(ClienteService clienteService) { 
            _clientes = ListarClientes(); // Quando a Controller for chamada será gerado a lista de clientes
            _clienteService = clienteService;
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
            {
                return View(_clienteService.GetById(id));
            }
        }

        [Route("consultar/{id}")]
        public IActionResult PageConsultCliente(int id)
        {
            {
                return View(_clienteService.GetById(id));
            }
        }

        //Metódos para manipular a lista
        [HttpPost]
        public IActionResult AddCliente(ClienteModel cliente)
        {
            _clienteService.Add(cliente);
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult UpdateCliente(ClienteModel cliente)
        {
            _clienteService.Update(cliente);
            return RedirectToAction("Index");
        }
        public List<ClienteModel> ListarClientes()
        {
            return (List<ClienteModel>)_clienteService.GetAll();
        }

        [HttpGet]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteService.GetById(id);
            _clienteService.Delete(cliente);
            return RedirectToAction("Index");
        }
    }
}
