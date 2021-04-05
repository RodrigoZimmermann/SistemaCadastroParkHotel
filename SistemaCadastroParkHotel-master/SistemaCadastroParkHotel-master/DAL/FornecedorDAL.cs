using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FornecedorDAL
    {
        public string Atualizar(Fornecedor item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE FORNECEDORES SET (RAZAOSOCIAL =@RAZASOCIAL, CNPJ =@CNPJ, NOMECONTATO =@NOMECONTATO,TELEFONE =@TELEFONE," +
                " EMAIL =@EMAIL,ATIVO =@ATIVO) WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", item.RazaoSocial);
            command.Parameters.AddWithValue("@CPF", item.CNPJ);
            command.Parameters.AddWithValue("@RG", item.NomeContato);
            command.Parameters.AddWithValue("@TELEFONE", item.Telefone);
            command.Parameters.AddWithValue("@CELULAR", item.Email);
            command.Parameters.AddWithValue("@ATIVO", item.Ativo);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    return "Estado inválido.";
                }
                return "Erro no banco de dados, contate o admin";
            }
            finally
            {
                connection.Dispose();
            }
            return "Fornecedor atualizado com sucesso!";
        }

        public string Excluir(Fornecedor item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM FORNECEDORES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", item.ID);
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    return "Estado inválido.";
                }
                return "Erro no banco de dados, contate o admin";
            }
            finally
            {
                connection.Dispose();
            }
            return "Fornecedor removido com sucesso!";
        }

        public string Inserir(Fornecedor item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO FORNECEDORES (RAZAOSOCIAL,CNPJ,NOMECONTATO,TELEFONE,EMAIL,ATIVO) " +
                "VALUES (@RAZAOSOCIAL,@CNPJ,@NOMECONTATO,@TELEFONE,@EMAIL,@ATIVO)";
            command.Parameters.AddWithValue("@NOME", item.RazaoSocial);
            command.Parameters.AddWithValue("@CPF", item.CNPJ);
            command.Parameters.AddWithValue("@RG", item.NomeContato);
            command.Parameters.AddWithValue("@TELEFONE", item.Telefone);
            command.Parameters.AddWithValue("@EMAIL", item.Email);
            command.Parameters.AddWithValue("@ATIVO", item.Ativo);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    return "Estado inválido.";
                }
                return "Erro no banco de dados, contate o admin";
            }
            finally
            {
                connection.Dispose();
            }
            return "Fornecedor cadastrada com sucesso!";
        }

        public Fornecedor LerPorID(int id)
        {
            {
                string stringDeConexao = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\moc\Documents\SistemaParkHotel.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlConnection connection = new SqlConnection(stringDeConexao);
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM FornecedorS WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string RazaoSocial = Convert.ToString(reader["RAZAOSOCIAL"]);
                        string CNPJ = Convert.ToString(reader["CNPJ"]);
                        string NomeContato = Convert.ToString(reader["NOMECONTATO"]);
                        string Telefone = Convert.ToString(reader["TELEFONE"]);
                        string Email = Convert.ToString(reader["EMAIL"]);
                        bool Ativo = Convert.ToBoolean(reader["ATIVO"]);
                        Fornecedor Fornecedores = new Fornecedor(id,RazaoSocial, CNPJ, NomeContato, Telefone, Email, Ativo);
                        return Fornecedores;
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    connection.Dispose();
                }
                return null;
            }
        }

        public List<Fornecedor> LerTodos()
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = stringDeConexao;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FornecedorS";

            command.Connection = connection;
            List<Fornecedor> Fornecedores = new List<Fornecedor>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string RazaoSocial = Convert.ToString(reader["RAZAOSOCIAL"]);
                    string CNPJ = Convert.ToString(reader["CNPJ"]);
                    string NomeContato = Convert.ToString(reader["NOMECONTATO"]);
                    string Telefone = Convert.ToString(reader["TELEFONE"]);
                    string Email = Convert.ToString(reader["EMAIL"]);
                    bool Ativo = Convert.ToBoolean(reader["ATIVO"]);
                    Fornecedor Fornecedor = new Fornecedor(id, RazaoSocial, CNPJ, NomeContato, Telefone, Email, Ativo);
                    Fornecedores.Add(Fornecedor);
                    return Fornecedores;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Dispose();
            }
            return null;
        }
    }
}
