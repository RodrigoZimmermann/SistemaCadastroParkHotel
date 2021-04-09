using Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    internal class EnderecoBLL : IEntityCRUD<Endereco>
    {
        public string Atualizar(Endereco item)
        {
            throw new NotImplementedException();
        }

        public string Excluir(Endereco item)
        {
            throw new NotImplementedException();
        }

        public string Inserir(Endereco item)
        {
            throw new NotImplementedException();
        }

        public Endereco LerPorID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Endereco> LerTodos()
        {
            throw new NotImplementedException();
        }

        public string Validar(Endereco endereco) 
            {
                List<string> erros = new List<string>();

                #region CEP
                if (string.IsNullOrWhiteSpace(endereco.CEP))
                {
                    erros.Add("CEP deve ser informado");
                }
                else
                {
                    endereco.CEP =
                    endereco.CEP.Replace(" ", "").Replace("-", "").Replace(".", "");

                    //endereco.CEP.EnsuranceLength(8);

                    if (endereco.CEP.Length != 8)
                    {
                        erros.Add("CEP deve conter 8 digitos");
                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (!char.IsNumber(endereco.CEP[i]))
                            {
                                erros.Add("CEP deve conter apenas numeros");
                                break;
                            }
                        }

                    }
                }
                #endregion

                #region Estado
                if (string.IsNullOrWhiteSpace(endereco.Estado))
                {
                    erros.Add("Estado deve ser informado");
                }
                    endereco.Estado = endereco.Estado.Trim();
                #endregion

                #region Cidade
                if (string.IsNullOrWhiteSpace(endereco.Cidade))
                {
                    erros.Add("Cidade deve ser informada");
                }
                    endereco.Cidade = endereco.Cidade.Trim();
                #endregion

                #region Bairro
            if (string.IsNullOrWhiteSpace(endereco.Bairro))
                {
                    erros.Add("Bairro deve ser informado");
                }
                else
                {
                    endereco.Bairro = endereco.Bairro.Trim();

                if (endereco.Bairro.Length < 3 || endereco.Bairro.Length > 50)
                    {
                        erros.Add("Bairro deve conter entre 3 e 50 caracteres");
                    }

                }
                #endregion

                #region Rua
                if (string.IsNullOrWhiteSpace(endereco.Rua))
                {
                    erros.Add("Rua deve ser informada");
                }
                else
                {
                    endereco.Rua = endereco.Rua.Trim();

                if (endereco.Rua.Length < 3 || endereco.Rua.Length > 70)
                    {
                        erros.Add("Rua deve conter entre 3 e 70 caracteres");
                    }

                }
                #endregion

                #region Numero
                if (string.IsNullOrWhiteSpace(endereco.Numero))
                {
                    erros.Add("Número deve ser informado");
                }
                else
                {
                    for (int i = 0; i < endereco.CEP.Length; i++)
                    {
                        if (!char.IsNumber(endereco.CEP[i]))
                        {
                            erros.Add("Número de residência inválido");
                        }
                    }
                }
                #endregion

                StringBuilder builder = new StringBuilder();
                if (erros.Count != 0)
                {
                    for (int i = 0; i < erros.Count; i++)
                    {
                        builder.AppendLine(erros[i]);
                    }
                }

                return builder.ToString();
            }
        }
    }

