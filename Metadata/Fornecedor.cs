using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class Fornecedor
    {
        public int ID { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor(int ID, string RazaoSocial,string CNPJ, string NomeContato, string Telefone, string Email, bool Ativo)
        {
            this.ID = ID;
            this.RazaoSocial = RazaoSocial;
            this.CNPJ = CNPJ;
            this.NomeContato = NomeContato;
            this.Telefone = Telefone;
            this.Email = Email;
            this.Ativo = Ativo;
        }
    }
}
