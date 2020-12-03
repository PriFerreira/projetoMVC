using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Fabricante
    {
        public long FabricanteID { get; set; }
        public string Nome { get; set; }

        /* "Definir como virtual possibilita a sua sobrescrita, para o EF,
         * é necessário para q ele possa fazer o Lazy	Load (carregamento tardio)" */
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}