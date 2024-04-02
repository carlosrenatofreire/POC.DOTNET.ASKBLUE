namespace POC.ASKBLUE.OOP.CONSOLE.Base_OOP;

//==================================================================================================
// Nota 1: O conceito de encapsulamento é a arte de encapsular comportamentos publicos e privados
// Nota 2: Perceba que o metodo "PrepararCafe()" da classe "CafeteiraEspressa" possuem metodos 
//         encapsulados que sao publicos e privados. Portanto o metodo "ServirCafe" nao faz ideia
//         de como se prepara cafe efetivamente.
//==================================================================================================

public class AutomacaoCafe
{
    public void ServirCafe()
    {
        var espresso = new CafeteiraEspressa();
        espresso.Ligar();
        espresso.PrepararCafe();
        espresso.Desligar();
    }
}
