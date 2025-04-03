using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp
{
    class TelaEquipamento
    {
        public Equipamento[] equipamentos = new Equipamento[10];
        public int contadorEquipamentos = 0;
        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("   Gestão de Equipamentos   ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("\nEscolha a opção desejada: ");
            Console.WriteLine("1 - Cadastrar Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("3 - Excluir Equipamento");
            Console.WriteLine("4 - Visualizar Equipamentos");
            Console.WriteLine("----------------------------");

            Console.Write("Digite uma opção válida: ");
            string opcaoEscolhida = Console.ReadLine()!;

            return opcaoEscolhida;
        }
        public void CadastrarEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("   Cadastro de Equipamento   ");
            Console.WriteLine("-----------------------------\n");

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine()!;

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);
            novoEquipamento.Id = GeradorIds.GerarIdEquipamento();

            equipamentos[contadorEquipamentos++] = novoEquipamento; 
        }
        public void EditarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("    Edição de Equipamento    ");
            Console.WriteLine("-----------------------------");

            VisualizarEquipamentos(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine()!;

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

            bool conseguiuEditar = false;
            
            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null) continue;

                else if (equipamentos[i].Id == idSelecionado)
                {
                    equipamentos[i].Nome = novoEquipamento.Nome;
                    equipamentos[i].Fabricante = novoEquipamento.Fabricante;
                    equipamentos[i].PrecoAquisicao = novoEquipamento.PrecoAquisicao;
                    equipamentos[i].DataFabricacao = novoEquipamento.DataFabricacao;

                    conseguiuEditar = true;
                }
            }

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição de um registro...");
                return;
            }

            Console.WriteLine("\nO equipamento foi editado com sucesso!");

        }
        public void ExcluirEquipamento()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("    Exclusão de Equipamento    ");
            Console.WriteLine("-------------------------------");

            VisualizarEquipamentos(true);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = false;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null) continue;

                else if (equipamentos[i].Id == idSelecionado)
                {
                    equipamentos[i] = null;
                    conseguiuExcluir = true;
                }

            }

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão de um registro... ");
                return;
            }

            Console.WriteLine("\nO equipamento foi excluído com sucesso!");
        }
        public void VisualizarEquipamentos(bool exibirTitulo)
        {
            Console.Clear();
            if (exibirTitulo)
            {
                Console.WriteLine("   Listagem de Equipamentos   ");
                Console.WriteLine("------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
                );

            for (int i = 0; i < contadorEquipamentos; i++)
            {
                Equipamento eS = equipamentos[i];

                if (eS == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                    eS.Id, eS.Nome, eS.ObterNumeroSerie(), eS.Fabricante, eS.PrecoAquisicao.ToString("C2"), eS.DataFabricacao.ToShortDateString()
                );
            }

            Console.WriteLine();

        }
    }
}
