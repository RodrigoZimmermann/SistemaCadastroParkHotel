using DAL;
using Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class EstadoBLL : IEntityCRUD<Estado>
    {
        EstadoDAL dal = new EstadoDAL();

        public string Atualizar(Estado item)
        {
            throw new NotImplementedException();
        }

        public string Excluir(Estado item)
        {
            throw new NotImplementedException();
        }

        public string Inserir(Estado estado)
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrWhiteSpace(estado.Sigla))
            {
                erros.Add("Sigla deve ser informada.");
            }
            else
            {
                estado.Sigla = estado.Sigla.Trim();
                if (estado.Sigla.Length != 2)
                {
                    erros.Add("Sigla deve conter 2 caracteres");
                }
            }

            if (string.IsNullOrWhiteSpace(estado.Nome))
            {
                erros.Add("Nome deve ser informado.");
            }
            else
            {
                estado.Nome = estado.Nome.Trim();
                if (estado.Nome.Length < 3 ||
                    estado.Nome.Length > 35)
                {
                    erros.Add("Nome deve conter entre 4 e 35 caracteres");
                }
            }
            if (erros.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < erros.Count; i++)
                {
                    //Environment.NewLine
                    builder.AppendLine(erros[i]);
                }
                return builder.ToString();
            }
            return dal.Inserir(estado);
        }

        public Estado LerPorID(int id)
        {
            return dal.LerPorID(id);
        }

        public List<Estado> LerTodos()
        {
            return dal.LerTodos();
        }
    }
}
