using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundaEntrega.Models
{
       public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome do produto")]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o tipo do produto")]
        [Display(Name = "Tipo")]
        [StringLength(100)]
        public string Tipo { get; set; }

        [Display(Name = "Nome Tipo")]
        public string NomeTipo { get; set; }

        [Required(ErrorMessage = "Por favor escolha a imagem")]
        public string ImagemProduto { get; set; }

        public Produto()
        {
            NomeTipo = Nome + " " + Tipo;
        }
    }
}
