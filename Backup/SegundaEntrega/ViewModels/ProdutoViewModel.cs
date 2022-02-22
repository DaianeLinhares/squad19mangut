using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SegundaEntrega.ViewModels
{
    public class ProdutoViewModel
    {
        [Required(ErrorMessage = "Por favor preencha o nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor preencha o tipo")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }        

        [Required(ErrorMessage = "Por favor escolha a imagem")]
        [Display(Name = "Imagem produto")]
        public IFormFile ImagemProduto { get; set; }
    }
}
