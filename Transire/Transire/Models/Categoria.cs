using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transire.Models
{
    public class Categoria
    {
        [Key] 
        public int Id { get; set; }
        [Display(Name ="Nome da Categoria")]
        public String Nome { get; set; }
      
    }
}