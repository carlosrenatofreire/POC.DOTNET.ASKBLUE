namespace POC.ASKBLUE.SOLID.CONSOLE._1_SRP.Solucao.Entities
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
