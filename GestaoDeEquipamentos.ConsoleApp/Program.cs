
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();

        RepositorioEquipamento repositorioEquipamento = telaEquipamento.repositorioEquipamento;

        TelaChamado telaChamado = new TelaChamado(repositorioEquipamento);

        TelaPrincipal telaPrincipal = new TelaPrincipal();

        TelaFuncionario telaFuncionario = new TelaFuncionario();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.ApresentarMenuPrincipal();

            if (opcaoPrincipal == '1')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaEquipamento.CadastrarEquipamento(); break;

                    case '2': telaEquipamento.EditarEquipamento(); break;

                    case '3': telaEquipamento.ExcluirEquipamento(); break;

                    case '4': telaEquipamento.VisualizarEquipamentos(true); break;

                    default: break;
                }
            }

            else if (opcaoPrincipal == '2')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaChamado.CadastrarChamado(); break;

                    case '2': telaChamado.EditarChamado(); break;

                    case '3': telaChamado.ExcluirChamado(); break;

                    case '4': telaChamado.VisualizarChamados(true); break;

                    default: break;
                }
            }
            else if (opcaoPrincipal == '3')
            {
                char opcaoEscolhida = telaFuncionario.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaFuncionario.CadastrarFuncionario(); break;

                    case '2': telaFuncionario.EditarFuncionario(); break;

                    case '3': telaFuncionario.ExcluirFuncionario(); break;

                    case '4': telaFuncionario.VisualizarFuncionarios(true); break;

                    default: break;
                }
            }
            else if (opcaoPrincipal == 'S' || opcaoPrincipal == 's')
            {
                break;
            }

                Console.ReadLine();
        }

    }
}