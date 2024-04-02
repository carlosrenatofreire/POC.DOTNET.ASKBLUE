namespace POC.ASKBLUE.OOP.CONSOLE.InterfaceVsImplementacao;

//==================================================================================================
// Nota 1: O conceito de interface é um pouco diferente de classe abstrata, sao metodos ou contratos 
//         que devem ser implementados mas nao possuem comportamento definido.
// Nota 2: 
//         
//==================================================================================================


#region Estrutura de Repositorio (Classe e Interface)

public interface IRepositorio
{
    void Adicionar();
}


public class Repositorio : IRepositorio
{
    //public Repositorio(int a)
    //{

    //}

    public void Adicionar()
    {
        // Adiciona item
    }
}

#endregion

#region Classes por Implementacao Vs por Interface (contrato)

public class UsoImplementacao
{
    public void Processo()
    {
        var repositorio = new Repositorio();
        repositorio.Adicionar();
    }
}

public class UsoAbstracao
{
    private readonly IRepositorio _repositorio;

    public UsoAbstracao(IRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public void Processo()
    {
        _repositorio.Adicionar();
    }
}

#endregion

#region Area de Testes (Implementacao Vs Interface)

public class TestePorImplementacao
{
    public TestePorImplementacao()
    {
        var repoImp = new UsoImplementacao();
        repoImp.Processo();
    }
}

public class TestePorInterface
{
    public TestePorInterface()
    {
        var repoAbs = new UsoAbstracao(new Repositorio());
        repoAbs.Processo();
    }
}

#endregion