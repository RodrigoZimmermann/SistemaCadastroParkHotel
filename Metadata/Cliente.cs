using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public Cliente(int ID, string Nome, string CPF, string RG,
            string Telefone, string Celular, string Email, bool Ativo)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.CPF = CPF;
            this.RG = RG;
            this.Telefone = Telefone;
            this.Celular = Celular;
            this.Email = Email;
            this.Ativo = Ativo;
        }
    }
}
