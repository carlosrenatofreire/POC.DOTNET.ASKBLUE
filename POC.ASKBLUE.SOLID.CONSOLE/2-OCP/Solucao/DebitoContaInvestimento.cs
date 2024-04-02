using POC.ASKBLUE.SOLID.CONSOLE._2_OCP.Violacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ASKBLUE.SOLID.CONSOLE._2_OCP.Solucao
{
    public class DebitoContaInvestimento : DebitarEmConta
    {
        public override string Debitar(decimal valor, string conta)
        {
            // Debita Conta Investimento
            // Isentar Taxas
            return GerarNumeroDeTransacao();
        }
    }
}
