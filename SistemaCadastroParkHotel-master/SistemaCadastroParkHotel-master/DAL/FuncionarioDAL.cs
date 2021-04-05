using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FuncionarioDAL
    {
        public string Atualizar(Funcionario item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();

            command.CommandText =
                "UPDATE FUNCIONARIOS SET (NOME =@NOME, CPF =@CPF, RG =@RG,ENDERECO =@ENDERECO," +
                " TELEFONE =@TELEFONE, EMAIL =@EMAIL,SENHA =@SENHA, EHADMIN =@EHADMIN, ATIVO =@ATIVO) WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@CPF", item.CPF);
            command.Parameters.AddWithValue("@RG", item.RG);
            command.Parameters.AddWithValue("@ENDERECO", item.Endereco);
            command.Parameters.AddWithValue("@TELEFONE", item.Telefone);
            command.Parameters.AddWithValue("@EMAIL", item.Email);
            command.Parameters.AddWithValue("@SENHA", item.Email);
            command.Parameters.AddWithValue("@EHADMIN", item.Email);
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
            return "Funcionário atualizado com sucesso!";
        }

        public string Excluir(Funcionario item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM FUNCIONARIOS WHERE ID = @ID";
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
                //Código executado SEMPRE
                connection.Dispose();
            }
            return "Funcionário removido com sucesso!";
        }

        public string Inserir(Funcionario item)
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";

            //onde
            SqlConnection connection = new SqlConnection(stringDeConexao);

            //o que
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO FUNCIONARIOS (NOME,CPF,RG,ENDERECO,TELEFONE,EMAIL,SENHA,EHADMIN,ATIVO) " +
                "VALUES (@NOME,@CPF,@RG,@ENDERECO,@TELEFONE,@EMAIL,@SENHA,@EHADMIN,@ATIVO)";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@CPF", item.CPF);
            command.Parameters.AddWithValue("@RG", item.RG);
            command.Parameters.AddWithValue("@ENDERECO", item.Endereco);
            command.Parameters.AddWithValue("@TELEFONE", item.Telefone);
            command.Parameters.AddWithValue("@EMAIL", item.Email);
            command.Parameters.AddWithValue("@SENHA", item.Email);
            command.Parameters.AddWithValue("@EHADMIN", item.Email);
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
            return "Funcionário cadastrado com sucesso!";
        }

        public Funcionario LerPorID(int id)
        {
            {
                string stringDeConexao = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\moc\Documents\SistemaParkHotel.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlConnection connection = new SqlConnection(stringDeConexao);
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM FUNCIONARIO WHERE ID = @ID";
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
                        Endereco Endereco = (Endereco)reader["ENDERECO"];
                        string Telefone = Convert.ToString(reader["TELEFONE"]);
                        string Email = Convert.ToString(reader["EMAIL"]);
                        string Senha = Convert.ToString(reader["SENHA"]);
                        bool EhAdmin = Convert.ToBoolean(reader["EHADMIN"]);
                        bool Ativo = Convert.ToBoolean(reader["ATIVO"]);
                        Funcionario funcionarios = new Funcionario(id, Nome, CPF, RG, Endereco, Telefone, Email, Senha, EhAdmin, Ativo);
                        return funcionarios;
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

        public List<Funcionario> LerTodos()
        {
            string stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\SistemaCadastro.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = stringDeConexao;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS";

            command.Connection = connection;
            List<Funcionario> funcionarios = new List<Funcionario>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Nome = Convert.ToString(reader["NOME"]);
                    string CPF = Convert.ToString(reader["CPF"]);
                    string RG = Convert.ToString(reader["RG"]);
                    Endereco Endereco = (Endereco)reader["ENDERECO"];
                    string Telefone = Convert.ToString(reader["TELEFONE"]);
                    string Email = Convert.ToString(reader["EMAIL"]);
                    string Senha = Convert.ToString(reader["SENHA"]);
                    bool EhAdmin = Convert.ToBoolean(reader["EHADMIN"]);
                    bool Ativo = Convert.ToBoolean(reader["ATIVO"]);
                    Funcionario funcionario= new Funcionario(ID,Nome, CPF, RG, Endereco, Telefone, Email, Senha, EhAdmin, Ativo);
                    funcionarios.Add(funcionario);
                    return funcionarios;
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
