namespace POC.ASKBLUE.SOLID.CONSOLE._2_OCP.Solucao
{
    public class DebitoContaPoupanca : DebitarEmConta
    {
        public override string Debitar(decimal valor, string conta)
        {
            // Valida Aniversário da Conta
            // Debita Conta Corrente
            return GerarNumeroDeTransacao();
        }
    }
}
