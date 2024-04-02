namespace POC.ASKBLUE.SOLID.CONSOLE._2_OCP.Solucao
{
    public class DebitoContaCorrente : DebitarEmConta
    {
        public override string Debitar(decimal valor, string conta)
        {
            // Debita Conta Corrente
            return GerarNumeroDeTransacao();
        }
    }
}