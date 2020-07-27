using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc_EFCore2.Models;

namespace Mvc_EFCore2.Controllers
{
    public class TesteController : Controller
    {
        private readonly AlunoContext _alunoContext;
        public TesteController(AlunoContext alunoContext)
        {
            _alunoContext = alunoContext;
        }
        public IActionResult Index()
        {
            var alunos = _alunoContext.Alunos.ToList();

            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Sexo,Email,Nascimento")]Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoContext.Add(aluno);
                _alunoContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
