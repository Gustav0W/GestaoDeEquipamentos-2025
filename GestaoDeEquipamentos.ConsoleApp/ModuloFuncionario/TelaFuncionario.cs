using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

public class TelaFuncionario
{
    public RepositorioFuncionario repositorioFuncionario;

    public TelaFuncionario()
    {
        repositorioFuncionario = new RepositorioFuncionario();
    }
    public char ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Funcionários");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("1 - Cadastro de Funcionário");
        Console.WriteLine("2 - Edição de Funcionário");
        Console.WriteLine("3 - Exclusão de Funcionário");
        Console.WriteLine("4 - Visualização de Funcionário");
        Console.WriteLine("--------------------------------------------");

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }
    public void CadastrarFuncionario()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Funcionários");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Cadastrando Funcionários...");
        Console.WriteLine("--------------------------------------------n");

        Console.Write("Digite o nome do funcionário: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o email do funcionário: ");
        string email = Console.ReadLine();

        Console.Write("Informe o telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Quantos itens fabricou: ");
        int qtdItensFabricados = Convert.ToInt32(Console.ReadLine());

        Funcionario novoFuncionario = new Funcionario(nome, email, telefone, qtdItensFabricados);

        repositorioFuncionario.CadastrarFuncionario(novoFuncionario);
    }
    public void EditarFuncionario()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Funcionários");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Editando Funcionario...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFuncionarios(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Digite o nome do funcionário: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o email do funcionário: ");
        string email = Console.ReadLine();

        Console.Write("Informe o telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Quantos itens fabricou: ");
        int qtdItensFabricados = Convert.ToInt32(Console.ReadLine());

        Funcionario novoFuncionario = new Funcionario(nome, email, telefone, qtdItensFabricados);

        bool conseguiuEditar = repositorioFuncionario.EditarFuncionario(idSelecionado, novoFuncionario);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O funcionário foi editado com sucesso!");
    }
    public void ExcluirFuncionario()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Funcionarios");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Excluindo Funcionario...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFuncionarios(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioFuncionario.ExcluirFuncionario(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O funcionário foi excluído com sucesso!");
    }

    public void VisualizarFuncionarios(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Funcionarios");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Visualizando Funcionarios...");
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15}",
            "Id", "Nome", "Email", "Telefone", "Quantidade de itens fabricados"
        );

        Funcionario[] funcionariosCadastrados = repositorioFuncionario.SelecionarFuncionarios();

        for (int i = 0; i < funcionariosCadastrados.Length; i++)
        {
            Funcionario f = funcionariosCadastrados[i];

            if (f == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15}",
                f.Id, f.Nome, f.Email, f.Telefone, f.QtdItensFabricados
            );
        }

        Console.WriteLine();
    }
}
