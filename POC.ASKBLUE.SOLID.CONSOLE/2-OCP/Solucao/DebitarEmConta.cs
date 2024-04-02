using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ASKBLUE.SOLID.CONSOLE._2_OCP.Solucao
{
    public abstract class DebitarEmConta
    {
        public string NumeroTransacao { get; set; }
        public abstract string Debitar(decimal valor, string conta);

        public string GerarNumeroDeTransacao()
        {
            // Gera Guid de retorno da transacao 
            NumeroTransacao = Guid.NewGuid().ToString();

            // Numero de transacao formatado
            return NumeroTransacao;
        }

    }
}
