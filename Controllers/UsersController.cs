using Microsoft.AspNetCore.Mvc;
using NetFullStack.Business.Abstract;
using NetFullStack.DAL.Entities.DTO_S;
using NetFullStack.DAL.Entities.Models;

namespace NETFullStack.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserAbstract _context;

        public UsersController(IUserAbstract context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        


        public async Task<ActionResult> Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(Usuarios userdto)
        {
            if (ModelState.IsValid)
            {
                _context.Registrar(userdto);
                await _context.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
            
        }
    }
}
