using System.Data;
using System.Data.SqlClient;
using POC.ASKBLUE.SOLID.CONSOLE._5_DIP.Violacao.Entities;

namespace POC.ASKBLUE.SOLID.CONSOLE._5_DIP.Violacao
{
    public class ClienteRepository
    {
        public void AdicionarCliente(Cliente cliente)
        {
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "MinhaConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL NIF, DATACRIACAO) VALUES (@nome, @email, @nif, @dataCriacao))";

                cmd.Parameters.AddWithValue("nome", cliente.Nome);
                cmd.Parameters.AddWithValue("email", cliente.Email);
                cmd.Parameters.AddWithValue("nif", cliente.Nif);
                cmd.Parameters.AddWithValue("dataCriacao", cliente.DataCriacao);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
