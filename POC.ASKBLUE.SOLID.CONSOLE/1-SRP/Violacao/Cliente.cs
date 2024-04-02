using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace POC.ASKBLUE.SOLID.CONSOLE._1_SRP.Violacao
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Nif { get; set; }
        public DateTime DataCriacao { get; set; }

        public string AdicionarCliente()
        {
            if (!Email.Contains("@"))
                return "Cliente com e-mail inválido";

            if (Nif.Length != 9)
                return "Cliente com NIF inválido";


            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "MinhaConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL NIF, DATACRIACAO) VALUES (@nome, @email, @nif, @dataCriacao))";

                cmd.Parameters.AddWithValue("nome", Nome);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("nif", Nif);
                cmd.Parameters.AddWithValue("dataCriacao", DataCriacao);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            var mail = new MailMessage("empresa@empresa.pt", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Bem Vindo.";
            mail.Body = "Parabéns! Você está incluido.";
            client.Send(mail);

            return "Cliente incluido com sucesso!";
        }
    }
}
