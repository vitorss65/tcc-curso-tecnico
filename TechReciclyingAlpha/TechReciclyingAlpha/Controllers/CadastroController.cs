using Microsoft.AspNetCore.Mvc;
using TechReciclyingAlpha.Filters;
using TechReciclyingAlpha.Models;

namespace TechReciclyingAlpha.Controllers
{

    [PaginaParaUsuarioLogado] 

    public class CadastroController : Controller
    {
        private readonly Contexto _context;

        public CadastroController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Login,Senha,Email,Descricao,Foto,Perfil,DataCadastro,DataAtualizacao")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.SetSenhaHash(); 
                    _context.Add(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não consiguimos cadastrar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
