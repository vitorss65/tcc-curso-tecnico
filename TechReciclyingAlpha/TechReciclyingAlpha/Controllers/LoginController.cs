using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TechReciclyingAlpha.Helper;
using TechReciclyingAlpha.Models;

namespace TechReciclyingAlpha.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _context;
        private readonly ISessao _sessao; 

        public LoginController(Contexto context,
                                ISessao sessao)
        {
            _context = context; 
            _sessao = sessao;  
        }

        public IActionResult Index()
        {
            //Se o usuário estiver logado retornar para a home

            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();   
            return RedirectToAction("Index", "Login");   
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Usuario usuario = BuscarPorLogin(loginModel.Login); 


                    if(usuario != null) 
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválida. Por favor, tente novamente";

                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente";
                }

                return View("Index");    

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos logar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");    
            }
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper()); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("Id,Nome,Login,Senha,Email,Descricao,Foto,Perfil,DataCadastro,DataAtualizacao")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
