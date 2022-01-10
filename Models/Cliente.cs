using System.ComponentModel.DataAnnotations;

namespace Mangut.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
       
        public string Telefone { get; set; }
        
        public string Email { get; set; }
        
        public string Senha { get; set; }
        public virtual List<Compra> Compras { get; set; }
    }
}
