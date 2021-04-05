using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class Estado
    {
        public Estado(int id, string sigla, string nome)
        {
            this.ID = id;
            this.Sigla = sigla;
            this.Nome = nome;
        }

        public int ID { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}
