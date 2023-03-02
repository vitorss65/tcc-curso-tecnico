using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechReciclyingAlpha.Enums;
using TechReciclyingAlpha.Helper;


namespace TechReciclyingAlpha.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Column("Login")]
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Login { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }

        [Column("Foto")]
        [Display(Name = "Foto")]
        public string? Foto { get; set; }

        [Column("Perfil")]
        [Display(Name = "Perfil")]
        public PerfilEnum Perfil { get; set; }

        [Column("DataCadastro")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Column("DataAtualizacao")]
        [Display(Name = "Data de Atualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.CriarPasswordHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.CriarPasswordHash();
        }

    }
}
