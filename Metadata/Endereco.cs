using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class Endereco
    {
        public int ID { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Endereco(int ID, string cep)
        {
            this.ID = ID;
            this.CEP = cep;
        }

        public Endereco(int ID,string cep, string estado, string cidade, string bairro, string rua, string numero, string complemento)
        {
            this.ID = ID;
            this.CEP = cep;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
        }
    }
}
