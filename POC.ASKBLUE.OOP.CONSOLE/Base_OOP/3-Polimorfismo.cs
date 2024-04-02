namespace POC.ASKBLUE.OOP.CONSOLE.Base_OOP;

//==================================================================================================
// Nota 1: O conceito de poli-morfismo é ter (muitos ou multiplos) - (comportamentos ou formas)
// Nota 2: A classe concreta pode proporcionar formas de ser instanciada em multi formas conforme
//         formado em seu construtor.
// Nota 3: A classe concreta tera os metodos genericos herdados e atraves do modificador "override"
//         poderá definir o comportamento desse metodos genericos (é obrigatorio fazer o override)
// Nota 4: A classe concreta podera ter os metodos especializados atraves do modificador "static"
//==================================================================================================

public class CafeteiraEspressa : Eletrodomestico
{
    public CafeteiraEspressa(string nome, int voltagem)
        : base(nome, voltagem) { }

    public CafeteiraEspressa()
        : base("Padrao", 220) { }

    public void PrepararCafe()
    {
        Testar();
        AquecerAgua();
        MoerGraos();
        // ETC...
    }
    public override void Ligar()
    {
        // Verificar recipiente de agua
    }

    public override void Testar()
    {
        // teste de cafeteira
    }

    public override void Desligar()
    {
        // Resfriar aquecedor
    }

    private void AquecerAgua() 
    { 
        // Aquecer a agua
    }

    private static void MoerGraos() 
    { 
        // Moer os graos
    }


}
