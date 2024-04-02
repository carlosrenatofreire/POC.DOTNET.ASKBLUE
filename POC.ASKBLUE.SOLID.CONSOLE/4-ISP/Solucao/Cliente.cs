using POC.ASKBLUE.SOLID.CONSOLE._4_ISP.Solucao.Interfaces;

namespace POC.ASKBLUE.SOLID.CONSOLE._4_ISP.Solucao
{
    public class Cliente : ICliente
    {
        public void ValidarDados()
        {
            // Validar CPF, Email
        }

        public void SalvarBanco()
        {
            // Insert na tabela Cliente
        }

        public void EnviarEmail()
        {
            // Enviar e-mail para o cliente
        }
    }
}
