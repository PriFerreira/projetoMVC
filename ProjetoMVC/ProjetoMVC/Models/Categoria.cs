using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMVC.Models
{
    public class Categoria
    {
        public long CategoriaID { get; set; }
        /*Posso colocar esse campo como required [Required] e validar no controller*/
        public string Nome { get; set; }
    }
}