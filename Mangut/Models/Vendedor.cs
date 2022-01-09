using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangut.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
       
       public virtual List<Produto> Produtos { get; set; }
    }
}