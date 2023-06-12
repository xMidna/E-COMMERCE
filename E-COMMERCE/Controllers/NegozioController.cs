using E_COMMERCE.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCE.Controllers
{
    public class NegozioController : Controller
    {
        private readonly ECOMMERCEContext _context;

        public NegozioController(ECOMMERCEContext context)
        {
            _context = context;
        }

        #region ELENCO CLIENTE

        public IActionResult ElencoClienti()
        {
            return View(_context.Clientes.ToList());
        }

        #endregion

        #region NUOVOCLIENTE
        [HttpGet]
        public IActionResult NuovoCliente(int id)
        {
            var record = _context.Clientes.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);           
        }

        [HttpPost]
        public IActionResult NuovoCliente(int id, string nome, string cognome)
        {
            var record = _context.Clientes.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            record.IdCliente = id;
            record.Nome = nome;
            record.Cognome = cognome;
            _context.Clientes.Update(record);
            _context.SaveChanges();
            return RedirectToAction("ElencoClienti");
        }
        #endregion

        #region MODIFICACLIENTE
        [HttpGet]
        public IActionResult ModificaCliente(int id)
        {
            var record = _context.Clientes.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult ModificaCliente(int id, string nome, string cognome)
        {
            var record = _context.Clientes.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            record.IdCliente = id;
            record.Nome = nome;
            record.Cognome = cognome;
            _context.Clientes.Update(record);
            _context.SaveChanges();
            return RedirectToAction("ElencoClienti");
        }
        #endregion

        #region ELENCOPRODOTTI
        public IActionResult ElencoProdotti()
        {
            return View(_context.Prodottos.ToList());
        }

        #endregion

        #region NUOVOPRODOTTO
        [HttpGet]
        public IActionResult NuovoProdotto() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult NuovoProdotto(Prodotto nuovoRecord)
        {
            _context.Prodottos.Add(nuovoRecord);
            _context.SaveChanges();
            return RedirectToAction("ElencoProdotti");
        }


        #endregion

        #region MODIFICA PRODOTTO
        [HttpGet]
        public IActionResult ModificaProdotto(int id)
        {
            var record = _context.Prodottos.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult ModificaProdotto(int id, string nome, float prezzo)
        {
            var record = _context.Prodottos.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            record.IdProdotto = id;
            record.Nome = nome;
            record.Prezzo = prezzo ;
            _context.Prodottos.Update(record);
            _context.SaveChanges();
            return RedirectToAction("ElencoClienti");
        }
        #endregion
    }
}
