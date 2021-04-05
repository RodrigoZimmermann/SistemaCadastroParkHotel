using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL : IEntityCRUD<Cliente>
    {
        public string Atualizar(Cliente item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE CLIENTES SET (NOME =@NOME, CPF =@CPF, RG =@RG,TELEFONE =@TELEFONE," +
                " CELULAR =@CELULAR, EMAIL =@EMAIL,ATIVO =@ATIVO) WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@CPF", item.CPF);
            command.Parameters.AddWithValue("@RG", item.RG);
            command.Parameters.AddWithValue("@TELEFONE", item.Telefone);
            command.Parameters.AddWithValue("@CELULAR", item.Celular);
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
            return "Cliente atualizado com sucesso!";
        }

        public string Excluir(Cliente item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM CLIENTES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", item.ID);
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return "Erro no banco de dados, contate o admin";
            }
            finally
            {
                //Código executado SEMPRE
                connection.Dispose();
            }
            return "Cliente removido com sucesso!";
        }

        public string Inserir(Cliente item)
        {
            string stringDeConexao = Parametros.GetConnectionString();

            //onde
            SqlConnection connection = new SqlConnection(stringDeConexao);

            //o que
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO CLIENTES (NOME,CPF,RG,TELEFONE,CELULAR,EMAIL,ATIVO) " +
                "VALUES (@NOME,@CPF,@RG,@TELEFONE,@CELULAR,@EMAIL,@ATIVO)";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@CPF", item.CPF);
            command.Parameters.AddWithValue("@RG", item.RG);
            command.Parameters.AddWithValue("@TELEFONE", item.Telefone);
            command.Parameters.AddWithValue("@CELULAR", item.Celular);
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
                //Código executado SEMPRE
                connection.Dispose();
            }
            return "Cliente cadastrada com sucesso!";
        }

        public Cliente LerPorID(int id)
        {
            {
                string stringDeConexao = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\moc\Documents\SistemaParkHotel.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlConnection connection = new SqlConnection(stringDeConexao);
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM CLIENTES WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string Nome = Convert.ToString(reader["NOME"]);
                        string CPF = Convert.ToString(reader["CPF"]);
                        string RG = Convert.ToString(reader["RG"]);
                        string Telefone = Convert.ToString(reader["TELEFONE"]);
                        string Celular = Convert.ToString(reader["CELULAR"]);
                        string Email = Convert.ToString(reader["EMAIL"]);
                        bool Ativo = Convert.ToBoolean(reader["ATIVO"]);
                        Cliente clientes = new Cliente(id, Nome, CPF, RG, Telefone, Celular, Email, Ativo);
                        return clientes;
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

        public List<Cliente> LerTodos()
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = stringDeConexao;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES";

            command.Connection = connection;
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string Nome = Convert.ToString(reader["NOME"]);
                    string CPF = Convert.ToString(reader["CPF"]);
                    string RG = Convert.ToString(reader["RG"]);
                    string Telefone = Convert.ToString(reader["TELEFONE"]);
                    string Celular = Convert.ToString(reader["CELULAR"]);
                    string Email = Convert.ToString(reader["EMAIL"]);
                    bool Ativo = Convert.ToBoolean(reader["ATIVO"]);
                    Cliente cliente = new Cliente(id, Nome, CPF, RG, Telefone, Celular, Email, Ativo);
                    clientes.Add(cliente);
                }
                return clientes;
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
