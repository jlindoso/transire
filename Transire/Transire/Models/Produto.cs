using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Transire.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public Decimal Preco { get; set; }
        public byte[] Foto { get; set; }
        public String ImagemTipo { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}