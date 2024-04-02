using POC.ASKBLUE.OOP.CONSOLE.Base_OOP;
using POC.ASKBLUE.OOP.CONSOLE.HerancaVsComposicao;
using POC.ASKBLUE.OOP.CONSOLE.InterfaceVsImplementacao;

namespace POC.ASKBLUE.OOP.CONSOLE;

class Program
{
    static void Main()
    {
        Console.WriteLine("Escolha a forma de uso da OOP:");
        Console.WriteLine("");
        Console.WriteLine("1 - Uso de Encapsulamento");
        Console.WriteLine("2 - Uso de Heranca");
        Console.WriteLine("3 - Uso de Composicao ");
        Console.WriteLine("4 - Uso de Implementacao");
        Console.WriteLine("5 - Uso de Interface");
        Console.WriteLine("");

        var opcao = Console.ReadKey();

        switch (opcao.KeyChar)
        {
            case '1':
                new AutomacaoCafe().ServirCafe();
                break;
            case '2':
                new TesteHeranca();
                break;
            case '3':
                new TesteComposicao();
                break;
            case '4':
                new TestePorImplementacao();
                break;
            case '5':
                new TestePorInterface();
                break;
        }

        Main();
    }
}
