namespace POC.ASKBLUE.SOLID.CONSOLE._1_SRP.Solucao.Entities
{
    public class Nif
    {
        public string Numero { get; set; }

        public bool Validar()
        {
            return Numero.Length == 9;
        }
    }
}
