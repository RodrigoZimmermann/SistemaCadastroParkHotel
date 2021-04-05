using Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EstadoDAL : IEntityCRUD<Estado>
    {
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
            string stringDeConexao = Parametros.GetConnectionString();

            //onde
            SqlConnection connection = new SqlConnection(stringDeConexao);

            //o que
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO ESTADOS (SIGLA,NOME) VALUES (@SIGLA,@NOME);";
            command.Parameters.AddWithValue("@SIGLA", estado.Sigla);
            command.Parameters.AddWithValue("@NOME", estado.Nome);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return "Estado já cadastrado.";
                }
                return "Erro no banco de dados, contate o admin";
            }
            finally
            {
                //Código executado SEMPRE
                connection.Dispose();
            }
            return "Estado cadastrado com sucesso!";


        }

        public Estado LerPorID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Estado> LerTodos()
        {
            string stringDeConexao = Parametros.GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = stringDeConexao;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM ESTADOS";

            command.Connection = connection;
            List<Estado> estados = new List<Estado>();
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Em cada loop, o objeto reader aponta
                    //para um registro do banco de dados
                    int id = Convert.ToInt32(reader["ID"]);
                    string sigla = Convert.ToString(reader["SIGLA"]);
                    string nome = Convert.ToString(reader["NOME"]);
                    Estado estado = new Estado(id, sigla, nome);
                    estados.Add(estado);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Dispose();
            }
            return estados;
        }


    }
}
