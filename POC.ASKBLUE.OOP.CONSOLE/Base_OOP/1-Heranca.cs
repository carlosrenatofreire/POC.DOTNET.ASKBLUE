using POC.ASKBLUE.OOP.CONSOLE.Entities;

namespace POC.ASKBLUE.OOP.CONSOLE.Base_OOP;

public class Funcionario : Pessoa
{
    public DateTime DataAdmissao { get; set; }
    public string Registro { get; set; }
}

public class Processo
{
    public void Execucao()
    {
        var funcionario = new Funcionario()
        {
            Nome = "Carlos Freire",
            DataNascimento = Convert.ToDateTime("1975/09/10"),
            DataAdmissao = DateTime.Now,
            Registro = "0123456",
        };

        funcionario.CalcularIdade();
    }
}
