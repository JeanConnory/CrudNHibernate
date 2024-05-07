using Microsoft.AspNetCore.Mvc;
using MvcNHibernate.Models;
using MvcNHibernate.Repositories;

namespace MvcNHibernate.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioRepository funcionarioRepository;

        public FuncionarioController(NHibernate.ISession session)
        {
            funcionarioRepository = new FuncionarioRepository(session);
        }

        public IActionResult Index()
        {
            return View(funcionarioRepository.FindAll().ToList());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if(id == null)
                return StatusCode(StatusCodes.Status404NotFound);

            Funcionario funcionario = await funcionarioRepository.FindById(id.Value);

            if(funcionario == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return View(funcionario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Nome,Idade,Salario")] Funcionario funcionario)
        {
            if(ModelState.IsValid) 
            { 
                await funcionarioRepository.Add(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
                return StatusCode(StatusCodes.Status404NotFound);

            Funcionario funcionario = await funcionarioRepository.FindById(id.Value);

            if (funcionario == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Nome,Idade,Salario")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                await funcionarioRepository.Update(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return StatusCode(StatusCodes.Status404NotFound);

            Funcionario funcionario = await funcionarioRepository.FindById(id.Value);

            if (funcionario == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {            
                await funcionarioRepository.Remove(id);
                return RedirectToAction("Index");
        }
    }
}
