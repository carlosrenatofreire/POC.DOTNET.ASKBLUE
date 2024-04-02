using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ASKBLUE.SOLID.CONSOLE._3_LSP.Solucao
{
    public class CalculoArea
    {
        private static void ObterAreaParalelogramo(Paralelogramo ret)
        {
            Console.Clear();
            Console.WriteLine("Calculo da área do Retangulo");
            Console.WriteLine();
            Console.WriteLine(ret.Altura + " * " + ret.Largura);
            Console.WriteLine();
            Console.WriteLine(ret.Area);
            Console.WriteLine("");
            Console.WriteLine("Pressione <ENTER> para continuar ou concluir...");
            Console.ReadKey();
        }

        public static void Calcular()
        {
            var quad = new Quadrado(5, 5);
            var ret = new Retangulo(10, 5);

            ObterAreaParalelogramo(quad);
            ObterAreaParalelogramo(ret);
        }
    }
}
