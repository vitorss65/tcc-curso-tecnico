using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechReciclyingAlpha.Models
{
    [Table("Ecoponto")]
    public class Ecoponto
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Column("WebSite")]
        [Display(Name = "Link do site")]
        public string WebSite { get; set; }

        [Column("Endereco")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        [Column("Latitude")]
        [Display(Name = "Latitude")]
        public string? Latitude { get; set; }

        [Column("Longitude")]
        [Display(Name = "Longitude")]
        public string? Longitude { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Column("Foto")]
        [Display(Name = "Foto")]
        public string? Foto { get; set; }
    }
}
