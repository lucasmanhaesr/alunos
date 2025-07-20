using Alunos.Data.Contexts;
using Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alunos.Controllers
{
    public class ClienteController : Controller
    {
        private List<ClienteModel> _clientes;
        public static List<ClienteModel> clientes = new List<ClienteModel>();
        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext context) { 
            _context = context;
            _clientes = ListarClientes(); // Quando a Controller for chamada será gerado a lista de clientes
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
            var cliente = _context.Cliente
                .Include(c => c.Representante)
                    .FirstOrDefault(c => c.ClienteId == id);
            if (cliente == null) 
            {
                throw new NullReferenceException();
            }
            else
            {
                return View(cliente);
            }
        }

        [Route("consultar/{id}")]
        public IActionResult PageConsultCliente(int id)
        {
            var cliente = _context.Cliente
                .Include(c => c.Representante) //Carrega a tabela relacionada junto com a tabela principal
                    .FirstOrDefault(c => c.ClienteId == id); //Encontra o cliente pelo id 
            if (cliente == null)
            {
                throw new NullReferenceException();
            }
            else 
            {
                return View(cliente);
            }
        }

        //Metódos para manipular a lista
        [HttpPost]
        public IActionResult AddCliente(ClienteModel cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult UpdateCliente(ClienteModel cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public List<ClienteModel> ListarClientes()
        {
            var clientes = _context.Cliente.Include(c => c.Representante).ToList();
            return clientes;
        }

        [HttpGet]
        public IActionResult DeleteCliente(int id) 
        {
           var cliente = _context.Cliente.Find(id);
            if (cliente != null) { 
                _context.Remove(cliente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
