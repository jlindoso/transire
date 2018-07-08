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
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }
        [Display(Name = "Nome da Categoria")]
        public Categoria Categoria { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public Decimal Preco { get; set; }
        public byte[] Foto { get; set; }
        public String ImagemTipo { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}