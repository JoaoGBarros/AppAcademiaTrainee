using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPWebAcademiaTrainee.Data;
using APPWebAcademiaTrainee.Models;
using AcademiaTrainee.Aplicacao;

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

            // variavel booleana para verificar a data
            bool error = false;

            //Pega no banco de dados pessoa com o mesmo email colocado no formulario
            var pessoaModel_email = _context.PessoaModel.Where(m => m.Email == pessoaModel.Email);

        
            if (!PessoaBusiness.ChecaEmailCadastrado(pessoaModel_email.Count()))
            {
                error = true;
                ModelState.AddModelError("", "Email já cadastrado!");
            }


            if (!PessoaBusiness.ValidaDataDeNascimento(pessoaModel.Date))
            {
                error = true;
                ModelState.AddModelError("", "Data de Nascimento fora da data limite! (01/01/1990)");
            }

            if (!PessoaBusiness.ValidaQuantidadeDeFilhos(pessoaModel.ChildrenAmount))
            {
                error = true;
                ModelState.AddModelError("", "A quantidade mínima de filhos é 0");
            }

            if (!PessoaBusiness.ValidaSalario(pessoaModel.Salary))
            {
                error = true;
                ModelState.AddModelError("", "Salário não pode ser inferior à 1.200 e superior à 13.000");
            }

            if (error)
            {
                return View(pessoaModel);
            }

            // Salva a pessoa como ativo
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

            bool error = false;


            // Recupera os dados do usuario no banco de dados para comparacoes futuras
            var pessoaModelBD = GetPessoaBD(id);
            var pessoaModel_email = _context.PessoaModel.Where(m => m.Email == pessoaModel.Email && m.PersonCode != pessoaModel.PersonCode);



            if (id != pessoaModel.PersonCode)
            {
                return NotFound();
            }


            if (!PessoaBusiness.ValidaSituacao(pessoaModel.Status, pessoaModelBD.Status))
            {
                error = true;
                ModelState.AddModelError("", "Usuário inativo! Altere a situação do usuário para edita-lo ");
            }

            if (!PessoaBusiness.ChecaEmailCadastrado(pessoaModel_email.Count()))
            {

                error = true;
                ModelState.AddModelError("", "Email ja cadastrado!");


            }

            if (!PessoaBusiness.ValidaDataDeNascimento(pessoaModel.Date))
            {
                error = true;
                ModelState.AddModelError("", "Data de Nascimento fora da data limite! (01/01/1990)");
            }

            if (!PessoaBusiness.ValidaQuantidadeDeFilhos(pessoaModel.ChildrenAmount))
            {
                error = true;
                ModelState.AddModelError("", "A quantidade minima de filhos eh 0");
            }

            if (!PessoaBusiness.ValidaSalario(pessoaModel.Salary))
            {
                error = true;
                ModelState.AddModelError("", "Salario nao pode ser inferior a 1200");
            }

            if (!PessoaBusiness.ValidaSalario(pessoaModel.Salary))
            {
                error = true;
                ModelState.AddModelError("", "Salario nao pode ser superior a 13000");
            }


            if (!error)
            {
                try
                {
                    _context.Update(pessoaModel);
                    await _context.SaveChangesAsync();

                    // Caso nao tenha nenhum erro a ser mostrado, a pagina retorna ao index
                    return RedirectToAction(nameof(Index));
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
            }

            // Caso tenha algum erro a ser mostrado, a pagina recarrega a view com as mensagens de erro
            return View(pessoaModel);



        }


        // Funcao para retornar os dados do usuario no banco de dados
        public PessoaModel GetPessoaBD(int id)
        {
            PessoaModel pessoaModel = _context.PessoaModel.AsNoTracking().Where(x => x.PersonCode == id).Single();
            return pessoaModel;
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

            // Se a pessoa estiver ativa
            if (!PessoaBusiness.ValidaExclusao(pessoaModel.Status))
            {
                ModelState.AddModelError("", "Usuario ativo! Nao foi possivel deletar!");
                return View(pessoaModel);
            }
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
