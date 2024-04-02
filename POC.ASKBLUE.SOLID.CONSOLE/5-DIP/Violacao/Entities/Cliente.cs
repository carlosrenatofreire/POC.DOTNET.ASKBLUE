using System;

namespace POC.ASKBLUE.SOLID.CONSOLE._5_DIP.Violacao.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Nif Nif { get; set; }
        public DateTime DataCriacao { get; set; }

        public bool Validar()
        {
            return Email.Validar() && Nif.Validar();
        }
    }
}
