using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mvc_EFCore2.Models;

namespace Mvc_EFCore2.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AlunoContext _alunoContext;
        public AlunoController(AlunoContext alunoContext)
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _alunoContext.Alunos.SingleOrDefault(aluno => aluno.Id == id);

            if(aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("Id,Nome,Sexo,Email,Nascimento")] Aluno aluno)
        {
            if(id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _alunoContext.Update(aluno);
                    _alunoContext.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!AlunoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public bool AlunoExists(int id)
        {
            return _alunoContext.Alunos.Any(e => e.Id == id);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _alunoContext.Alunos.SingleOrDefault(a => a.Id == id);

            if(aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirma(int? id)
        {
            var aluno = _alunoContext.Alunos.SingleOrDefault(a => a.Id == id);
            _alunoContext.Alunos.Remove(aluno);
            _alunoContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var aluno = _alunoContext.Alunos.SingleOrDefault(a => a.Id == id);

            if(aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }
    }
}
