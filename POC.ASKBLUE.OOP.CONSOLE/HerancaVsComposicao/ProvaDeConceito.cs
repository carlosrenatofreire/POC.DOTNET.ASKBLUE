using POC.ASKBLUE.OOP.CONSOLE.Entities;

namespace POC.ASKBLUE.OOP.CONSOLE.HerancaVsComposicao;

#region Estrutura de Testes (Herança Vs Composicao)

public class PessoaSingular : Pessoa
{
    public string Nif { get; set; }
}

public class PessoaSingular2
{
    public Pessoa Pessoa { get; set; }
    public string Nif { get; set; }
}

#endregion

#region Area de Testes (Herança Vs Composicao)

public class TesteHeranca
{
    public TesteHeranca()
    {
        var pessoaHeranca = new PessoaSingular
        {
            Nome = "Joao",
            DataNascimento = DateTime.Now,
            Nif = "999999999"
        };

        var nomeHeranca = pessoaHeranca.Nome;
    }
}

public class TesteComposicao
{
    public TesteComposicao()
    {
        var pessoaComposicao = new PessoaSingular2
        {
            Pessoa = new Pessoa
            {
                Nome = "Joao",
                DataNascimento = DateTime.Now,
            },
            Nif = "999999999"
        };

        var nomeComposicao = pessoaComposicao.Pessoa.Nome;
    }
}

#endregion

