using POC.ASKBLUE.SOLID.CONSOLE._1_SRP.Solucao.Entities;

namespace POC.ASKBLUE.SOLID.CONSOLE._1_SRP.Solucao
{
    public class ClienteService
    {
        public string AdicionarCliente(Cliente cliente)
        {
            try
            {
                if (!cliente.Validar())
                    return "Dados inválidos";

                var repo = new ClienteRepository();
                repo.AdicionarCliente(cliente);

                EmailService.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

                return "Cliente incluido com sucesso";
            }
            catch (System.Exception ex)
            {
                return "Erro: " + ex.Message.ToString();
            }
        }
    }
}
