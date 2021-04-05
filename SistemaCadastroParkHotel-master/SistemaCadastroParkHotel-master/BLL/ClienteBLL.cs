using DAL;
using Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL : IEntityCRUD<Cliente>
    {
        private ClienteDAL cdal = new ClienteDAL();

        #region ValidarCPF
        private bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        #endregion

        public string Inserir(Cliente cadCli)
        {
            List<string> erros = new List<string>();


            #region Nome
            if (string.IsNullOrWhiteSpace(cadCli.Nome))
            {
                erros.Add("Nome deve ser informado.");
            }
            else
            {
                cadCli.Nome = cadCli.Nome.Trim();
                if (cadCli.Nome.Length < 3 || cadCli.Nome.Length > 60)
                {
                    erros.Add("Nome deve conter entre 3 e 60 caracteres.");
                }
                else
                {
                    for (int i = 0; i < cadCli.Nome.Length; i++)
                    {
                        if (!char.IsLetter(cadCli.Nome[i]) && cadCli.Nome[i] != ' ')
                        {
                            erros.Add("Nome inválido");
                            break;
                        }
                    }
                }
            }
            #endregion

            #region CPF
            if (string.IsNullOrWhiteSpace(cadCli.CPF))
            {
                erros.Add("CPF deve ser informado.");
            }
            else
            {
                cadCli.CPF = cadCli.CPF.Trim();
                cadCli.CPF = cadCli.CPF.Replace(".", "").Replace("-", "");
                if (!this.ValidarCPF(cadCli.CPF))
                {
                    erros.Add("CPF inválido");
                }
            }
            #endregion

            #region RG
            if (string.IsNullOrWhiteSpace(cadCli.RG))
            {
                erros.Add("RG deve ser informado.");
            }
            else
            {
                cadCli.RG = cadCli.RG.Trim();
                cadCli.RG = cadCli.RG.Replace(".", "").Replace("/", "").Replace("-", "");
                if (cadCli.RG.Length < 5 || cadCli.RG.Length > 9)
                {
                    erros.Add("RG deve conter entre 5 e 9 caracteres.");
                }
            }
            #endregion

            #region Telefone
            if (string.IsNullOrWhiteSpace(cadCli.Telefone))
            {
                erros.Add("Telefone deve ser informado.");
            }
            else
            {
                cadCli.Telefone =
                    cadCli.Telefone.Replace(" ", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("-", "");

                if (cadCli.Telefone.Length < 8 || cadCli.Telefone.Length > 15)
                {
                    erros.Add("Telefone deve conter entre 8 e 15 caracteres.");
                }
            }
            #endregion

            #region Celular
            if (string.IsNullOrWhiteSpace(cadCli.Celular))
            {
                erros.Add("Celular deve ser informado.");
            }
            else
            {
                cadCli.Celular =
                    cadCli.Celular.Replace(" ", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("-", "");

                if (cadCli.Celular.Length < 8 || cadCli.Celular.Length > 15)
                {
                    erros.Add("Celular deve conter entre 8 e 15 caracteres.");
                }
            }
            #endregion

            #region Email
            bool isEmail = Regex.IsMatch(cadCli.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                erros.Add("Email deve ser informado.");
            }
            #endregion


            StringBuilder builder = new StringBuilder();
            if (erros.Count != 0)
            {
                for (int i = 0; i < erros.Count; i++)
                {
                    builder.AppendLine(erros[i]);
                }
                return builder.ToString();
            }

            //Chamar o DAL para cadastrar
            cdal.Inserir(cadCli);
            return "Cliente cadastrado com sucesso";
        }

        public List<Cliente> LerTodos()
        {
            return cdal.LerTodos();
        }

        public string Atualizar(Cliente cadCli)
        {
            List<string> erros = new List<string>();

            if(cadCli.ID <= 0)
            {
                erros.Add("ID não encontrado");
            }

            #region Nome
            if (string.IsNullOrWhiteSpace(cadCli.Nome))
            {
                erros.Add("Nome deve ser informado.");
            }
            else
            {
                cadCli.Nome = cadCli.Nome.Trim();
                if (cadCli.Nome.Length < 3 || cadCli.Nome.Length > 60)
                {
                    erros.Add("Nome deve conter entre 3 e 60 caracteres.");
                }
                else
                {
                    for (int i = 0; i < cadCli.Nome.Length; i++)
                    {
                        if (!char.IsLetter(cadCli.Nome[i]) && cadCli.Nome[i] != ' ')
                        {
                            erros.Add("Nome inválido");
                            break;
                        }
                    }
                }
            }
            #endregion

            #region CPF
            if (string.IsNullOrWhiteSpace(cadCli.CPF))
            {
                erros.Add("CPF deve ser informado.");
            }
            else
            {
                cadCli.CPF = cadCli.CPF.Trim();
                cadCli.CPF = cadCli.CPF.Replace(".", "").Replace("-", "");
                if (!this.ValidarCPF(cadCli.CPF))
                {
                    erros.Add("CPF inválido");
                }
            }
            #endregion

            #region RG
            if (string.IsNullOrWhiteSpace(cadCli.RG))
            {
                erros.Add("RG deve ser informado.");
            }
            else
            {
                cadCli.RG = cadCli.RG.Trim();
                cadCli.RG = cadCli.RG.Replace(".", "").Replace("/", "").Replace("-", "");
                if (cadCli.RG.Length < 5 || cadCli.RG.Length > 9)
                {
                    erros.Add("RG deve conter entre 5 e 9 caracteres.");
                }
            }
            #endregion

            #region Telefone
            if (string.IsNullOrWhiteSpace(cadCli.Telefone))
            {
                erros.Add("Telefone deve ser informado.");
            }
            else
            {
                cadCli.Telefone =
                    cadCli.Telefone.Replace(" ", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("-", "");

                if (cadCli.Telefone.Length < 8 || cadCli.Telefone.Length > 15)
                {
                    erros.Add("Telefone deve conter entre 8 e 15 caracteres.");
                }
            }
            #endregion

            #region Celular
            if (string.IsNullOrWhiteSpace(cadCli.Celular))
            {
                erros.Add("Celular deve ser informado.");
            }
            else
            {
                cadCli.Celular =
                    cadCli.Celular.Replace(" ", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("-", "");

                if (cadCli.Celular.Length < 8 || cadCli.Celular.Length > 15)
                {
                    erros.Add("Celular deve conter entre 8 e 15 caracteres.");
                }
            }
            #endregion

            #region Email
            bool isEmail = Regex.IsMatch(cadCli.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                erros.Add("Email deve ser informado.");
            }
            #endregion


            StringBuilder builder = new StringBuilder();
            if (erros.Count != 0)
            {
                for (int i = 0; i < erros.Count; i++)
                {
                    builder.AppendLine(erros[i]);
                }
                return builder.ToString();
            }

            //Chamar o DAL para cadastrar
            cdal.Atualizar(cadCli);
            return "Cliente atualizado com sucesso";
        }

        public string Excluir(Cliente item)
        {
            return cdal.Excluir(item);
        }

        public Cliente LerPorID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
