﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangut.Models
{
    public class Produto
    {
        
        [Key]
        public int IdProduto { get; set; }
        [ForeignKey("Vendedor")]
        public int IdVendedor { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int Quantidade { get; set; }
        public virtual List<Compra> Compras { get; set; }
    }
}