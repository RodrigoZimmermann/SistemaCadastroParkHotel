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
    public class FuncionarioBLL
    {
        #region CPF
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

        public string Cadastrar(Funcionario cadFun)
        {
            List<string> erros = new List<string>();

            #region Nome
            if (string.IsNullOrWhiteSpace(cadFun.Nome))
            {
                erros.Add("Nome deve ser informado.");
            }
            else
            {
                cadFun.Nome = cadFun.Nome.Trim();
                if (cadFun.Nome.Length < 3 || cadFun.Nome.Length > 60)
                {
                    erros.Add("Nome deve conter entre 3 e 60 caracteres.");
                }
                else
                {
                    for (int i = 0; i < cadFun.Nome.Length; i++)
                    {
                        if (!char.IsLetter(cadFun.Nome[i]) && cadFun.Nome[i] != ' ')
                        {
                            erros.Add("Nome inválido");
                            break;
                        }
                    }
                }
            }
            #endregion

            #region CPF
            if (string.IsNullOrWhiteSpace(cadFun.CPF))
            {
                erros.Add("CPF deve ser informado.");
            }
            else
            {
                cadFun.CPF = cadFun.CPF.Trim();
                cadFun.CPF = cadFun.CPF.Replace(".", "").Replace("-", "");
                if (!this.ValidarCPF(cadFun.CPF))
                {
                    erros.Add("CPF inválido");
                }
            }
            #endregion

            #region RG
            if (string.IsNullOrWhiteSpace(cadFun.RG))
            {
                erros.Add("RG deve ser informado.");
            }
            else
            {
                cadFun.RG = cadFun.RG.Trim();
                cadFun.RG = cadFun.RG.Replace(".", "").Replace("/", "").Replace("-", "");
                if (cadFun.RG.Length < 5 || cadFun.RG.Length > 9)
                {
                    erros.Add("RG deve conter entre 5 e 9 caracteres.");
                }
            }
            #endregion

            #region Telefone
            if (string.IsNullOrWhiteSpace(cadFun.Telefone))
            {
                erros.Add("Telefone deve ser informado.");
            }
            else
            {
                cadFun.Telefone =
                    cadFun.Telefone.Replace(" ", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("-", "");

                if (cadFun.Telefone.Length < 8 || cadFun.Telefone.Length > 15)
                {
                    erros.Add("Telefone deve conter entre 8 e 15 caracteres.");
                }
            }
            #endregion

            #region Email
            bool isEmail = Regex.IsMatch(cadFun.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                erros.Add("Email deve ser informado.");
            }
            #endregion

            #region Endereco
            EnderecoBLL eBLL = new EnderecoBLL();
            string errosEndereco = eBLL.Validar(cadFun.Endereco);

            if (!string.IsNullOrWhiteSpace(errosEndereco))
            {
                erros.Add(errosEndereco);
            }

            new FuncionarioDAL().Inserir(cadFun);
            return "Funcionário cadastrado com sucesso";
            #endregion
        }
    }
}
