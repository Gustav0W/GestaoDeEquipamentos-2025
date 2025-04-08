namespace GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class RepositorioFuncionario
{
    public Funcionario[] funcionarios = new Funcionario[100];
    public int contadorFuncionarios = 0;

    public void CadastrarFuncionario(Funcionario novoFuncionario)
    {
        novoFuncionario.Id = GeradorIds.GerarIdFuncionario();

        funcionarios[contadorFuncionarios++] = novoFuncionario;
    }
    public bool EditarFuncionario(int idFuncionario, Funcionario funcionarioEditado)
    {
        for (int i = 0; i < funcionarios.Length; i++)
        {
            if (funcionarios[i] == null) continue;

            else if (funcionarios[i].Id == idFuncionario)
            {
                funcionarios[i].Nome = funcionarioEditado.Nome;
                funcionarios[i].Email = funcionarioEditado.Email;
                funcionarios[i].Telefone = funcionarioEditado.Telefone;
                funcionarios[i].QtdItensFabricados = funcionarioEditado.QtdItensFabricados;

                return true;
            }
        }
        return false;
    }
    public bool ExcluirFuncionario(int idFuncionario)
    {
        for (int i = 0; i < funcionarios.Length; i++)
        {
            if (funcionarios[i] == null) continue;

            else if (funcionarios[i].Id == idFuncionario)
            {
                funcionarios[i] = null;

                return true;
            }
        }

        return false;
    }

    public Funcionario[] SelecionarFuncionarios()
    {
        return funcionarios;
    }

    public Funcionario SelecionarFuncionarioPorId(int idFuncionario)
    {
        for (int i = 0; i < funcionarios.Length; i++)
        {
            Funcionario f = funcionarios[i];

            if (f == null)
                continue;

            else if (f.Id == idFuncionario)
                return f;
        }

        return null;
    }
}
    