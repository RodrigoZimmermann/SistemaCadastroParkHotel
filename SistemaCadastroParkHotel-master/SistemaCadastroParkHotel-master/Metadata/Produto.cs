using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Estoque { get; set; }

        public Produto(int ID, string Nome, string Descricao, int Preco, int Estoque)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Preco = Preco;
            this.Estoque = Estoque;
        }
    }
}
