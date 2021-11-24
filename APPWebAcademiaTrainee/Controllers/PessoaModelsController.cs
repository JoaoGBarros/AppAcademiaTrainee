using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPWebAcademiaTrainee.Data;
using APPWebAcademiaTrainee.Models;

namespace APPWebAcademiaTrainee.Controllers
{
    public class PessoaModelsController : Controller
    {
        private readonly APPWebAcademiaTraineeContext _context;

        public PessoaModelsController(APPWebAcademiaTraineeContext context)
        {
            _context = context;
        }

        // GET: PessoaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaModel.ToListAsync());
        }

        // GET: PessoaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel
                .FirstOrDefaultAsync(m => m.PersonCode == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return View(pessoaModel);
        }

        // GET: PessoaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonCode,Name,Email,Date,ChildrenAmount,Salary")] PessoaModel pessoaModel)
        {

            pessoaModel.Status = true;
            _context.Add(pessoaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            if (pessoaModel == null)
            {
                return NotFound();
            }
            return View(pessoaModel);
        }

        // POST: PessoaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonCode,Name,Email,Date,ChildrenAmount,Salary, Status")] PessoaModel pessoaModel)
        {
            if (id != pessoaModel.PersonCode)
            {
                return NotFound();
            }


            try
            {
                _context.Update(pessoaModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaModelExists(pessoaModel.PersonCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return View(pessoaModel);
        }

        // GET: PessoaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel
                .FirstOrDefaultAsync(m => m.PersonCode == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return View(pessoaModel);
        }

        // POST: PessoaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            _context.PessoaModel.Remove(pessoaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaModelExists(int id)
        {
            return _context.PessoaModel.Any(e => e.PersonCode == id);
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> AlterarStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return await AlterarValor(id, pessoaModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarValor(int? id, PessoaModel pessoaModel)
        {
            if (id != pessoaModel.PersonCode)
            {
                return NotFound();
            }

            if (pessoaModel.Status == true)
            {
                pessoaModel.Status = false;
            }
            else
            {
                pessoaModel.Status = true;
            }

            try
            {
                _context.Update(pessoaModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaModelExists(pessoaModel.PersonCode))
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


    }

}
