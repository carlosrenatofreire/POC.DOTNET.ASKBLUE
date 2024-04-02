namespace POC.ASKBLUE.OOP.CONSOLE.Base_OOP;

//==================================================================================================
// Nota 1: O conceito de abstracao é oferecer um conjunto de estados e comportamentos que abstrae
//         uma certa especializacao. (Classe generica)
// Nota 2: Quando uma classe torna-se abstrata (via modificador "abstract") ela por regra nao pode
//         ser mais instanciada apenas herdada.
// Nota 3: Sendo uma classe abstrata uma super classe, servira de base para polimorfismo e
//         encapsulamento.
// Nota 4: Para uma classe abstrata o modificador do contrutor deve ser "protected" para permitir
//         seu uso apenas para classe que herda-lo.
// Nota 5: Nesta classe é possivel ter um metodo com comportamento padrao definido atraves do
//         modificador "virtual" que permite sofrer override na mesma
//==================================================================================================
public abstract class Eletrodomestico
{
    private readonly string _nome;
    private readonly int _voltagem;
    protected Eletrodomestico(string nome, int voltagem)
    {
        _nome = nome;
        _voltagem = voltagem;
    }

    public abstract void Ligar();
    public abstract void Desligar();

    public virtual void Testar() // Metodo com modificador "virtual" deve possui um comportamento default
    {
        // teste do equipamento
    }
}
