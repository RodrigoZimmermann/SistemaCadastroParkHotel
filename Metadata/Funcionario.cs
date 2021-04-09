using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool EhAdmin { get; set; }
        public bool Ativo { get; set; }

        public Funcionario(int ID, string Nome, string CPF, string RG, Endereco Endereco,
            string Telefone, string Email, string Senha, bool EhAdmin, bool Ativo)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.CPF = CPF;
            this.RG = RG;
            this.Endereco = Endereco;
            this.Telefone = Telefone;
            this.Email = Email;
            this.Senha = Senha;
            this.EhAdmin = EhAdmin;
            this.Ativo = Ativo;
        }
    }
}
