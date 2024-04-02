namespace POC.ASKBLUE.SOLID.CONSOLE._5_DIP.Solucao.Entities
{
    public class Email
    {
        public string Endereco { get; set; }

        public bool Validar()
        {
            return Endereco.Contains("@");
        }
    }
}
