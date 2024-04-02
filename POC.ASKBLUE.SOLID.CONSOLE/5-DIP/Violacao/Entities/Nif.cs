namespace POC.ASKBLUE.SOLID.CONSOLE._5_DIP.Violacao.Entities
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
