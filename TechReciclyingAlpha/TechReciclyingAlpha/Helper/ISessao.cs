using TechReciclyingAlpha.Models;

namespace TechReciclyingAlpha.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoDoUsuario();

        Usuario BuscarSessaoDoUsuario();
    }
}
