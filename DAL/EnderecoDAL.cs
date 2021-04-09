using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class EnderecoDAL : IEntityCRUD<Endereco>
        {
        public string Atualizar(Endereco item)
        {
            string stringDeConexao = Parametros.GetConnectionString();

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
       
        command.CommandText =
                "UPDATE Enderecos SET (CEP =@CEP,ESTADO =@ESTADO, CIDADE =@CIDADE, BAIRRO=@BAIRRO,RUA =@RUA," +
                " NUMERO =@NUMERO, COMPLEMENTO =@COMPLEMENTO) WHERE ID = @ID";
            command.Parameters.AddWithValue("@CEP", item.CEP);
            command.Parameters.AddWithValue("@ESTADO", item.Estado);
            command.Parameters.AddWithValue("@CIDADE", item.Cidade);
            command.Parameters.AddWithValue("@BAIRRO", item.Bairro);
            command.Parameters.AddWithValue("@RUA", item.Rua);
            command.Parameters.AddWithValue("@NUMERO", item.Numero);
            command.Parameters.AddWithValue("@COMPLEMENTO", item.Complemento);

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
            return "Endereco atualizado com sucesso!";
        }

        public string Excluir(Endereco item)
        {
            string stringDeConexao = Parametros.GetConnectionString();

            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM Enderecos WHERE ID = @ID";
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
            return "Endereco removido com sucesso!";
        }

        public string Inserir(Endereco item)
        {
            string stringDeConexao = Parametros.GetConnectionString();
            
            SqlConnection connection = new SqlConnection(stringDeConexao);

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO Enderecos (CEP,ESTADO,CIDADE,BAIRRO,RUA,NUMERO,COMPLEMENTO) " +
                "VALUES (@CEP,@ESTADO,@CIDADE,@BAIRRO,@RUA,@NUMERO,@COMPLEMENTO)";
            command.Parameters.AddWithValue("@CEP", item.CEP);
            command.Parameters.AddWithValue("@ESTADO", item.Estado);
            command.Parameters.AddWithValue("@CIDADE", item.Cidade);
            command.Parameters.AddWithValue("@BAIRRO", item.Bairro);
            command.Parameters.AddWithValue("@RUA", item.Rua);
            command.Parameters.AddWithValue("@NUMERO", item.Numero);
            command.Parameters.AddWithValue("@COMPLEMENTO", item.Complemento);

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
            return "Endereco cadastrado com sucesso!";
        }

        public Endereco LerPorID(int id)
        {
            {
                string stringDeConexao = Parametros.GetConnectionString();

                SqlConnection connection = new SqlConnection(stringDeConexao);
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM Enderecos WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string CEP = Convert.ToString(reader["CEP"]);
                        string Estado = Convert.ToString(reader["ESTADO"]);
                        string Cidade = Convert.ToString(reader["CIDADE"]);
                        string Bairro = Convert.ToString(reader["BAIRRO"]);
                        string Rua = Convert.ToString(reader["RUA"]);
                        string Numero = Convert.ToString(reader["NUMERO"]);
                        string Complemento = Convert.ToString(reader["COMPLEMENTO"]);
                        Endereco Enderecos = new Endereco(id, CEP, Estado, Cidade, Bairro, Rua, Numero, Complemento);
                        return Enderecos;
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

        public List<Endereco> LerTodos()
        {
            string stringDeConexao = Parametros.GetConnectionString();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = stringDeConexao;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Enderecos";

            command.Connection = connection;
            List<Endereco> Endereco = new List<Endereco>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string CEP = Convert.ToString(reader["CEP"]);
                    string Estado = Convert.ToString(reader["ESTADO"]);
                    string Cidade = Convert.ToString(reader["CIDADE"]);
                    string Bairro = Convert.ToString(reader["BAIRRO"]);
                    string Rua = Convert.ToString(reader["RUA"]);
                    string Numero = Convert.ToString(reader["NUMERO"]);
                    string Complemento = Convert.ToString(reader["COMPLEMENTO"]);
                    Endereco Enderecos = new Endereco(ID, CEP, Estado, Cidade, Bairro, Rua, Numero, Complemento);
                    return Endereco;
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
