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
            Console.WriteLine("5 - Registrar Manutenção");
            Console.WriteLine("6 - Visualizar Manutenções");
            Console.WriteLine("7 - Editar Manutenção");
            Console.WriteLine("8 - Excluir Manutenção");
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

        public ChamadoManutencao[] manutencao = new ChamadoManutencao[10];
        public int contadorManutencao = 0;
        public void RegistrarManutencao()
        {
            Console.Clear();
            Console.WriteLine("   Cadastro de Manutenções   ");
            Console.WriteLine("----------------------------\n");

            Console.Write("Título do chamado: ");
            string titulo = Console.ReadLine()!;

            Console.Write("Descrição do chamado: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Informe o ID do equipamento: ");
            string equipamento = Console.ReadLine()!;

            Console.Write("Abertura do chamado (dd/MM/yyyy): ");
            DateTime dataChamado = Convert.ToDateTime(Console.ReadLine());

            ChamadoManutencao novaManutencao = new ChamadoManutencao(titulo, descricao, equipamento, dataChamado);
            novaManutencao.IdManutencao = GeradorIds.GerarIdManutencao();

            manutencao[contadorManutencao++] = novaManutencao;
        }
        public void ListarManutencao(bool exibirTitulo)
        {
            Console.Clear();
            if (exibirTitulo)
            {
                Console.WriteLine("   Listagem de Manutenções   ");
                Console.WriteLine("------------------------------\n");
            }
            Console.WriteLine();

            for (int i = 0; i < contadorManutencao; i++)
            {
                ChamadoManutencao cM = manutencao[i];

                if (cM == null) continue;

                Console.WriteLine($"Id manutenção: {cM.IdManutencao}\n" +
                    $"Titulo: {cM.Titulo}\n" +
                    $"Descrição: {cM.Descricao}\n" +
                    $"Equipamento: {cM.equipamento}\n" +
                    $"Data de abertura: {cM.DataDeAbertura.ToShortDateString()}\n\n");
            }
        }
        public void EditarManutencao()
        {
            Console.Clear();

            Console.WriteLine("------------------------------");
            Console.WriteLine("     Edição de Manutenção     ");
            Console.WriteLine("------------------------------");

            ListarManutencao(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Título do chamado: ");
            string titulo = Console.ReadLine()!;

            Console.Write("Descrição do chamado: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Informe o ID do equipamento: ");
            string equipamento = Console.ReadLine()!;

            Console.Write("Abertura do chamado (dd/MM/yyyy): ");
            DateTime dataChamado = Convert.ToDateTime(Console.ReadLine());

            ChamadoManutencao novaManutencao = new ChamadoManutencao(titulo, descricao, equipamento, dataChamado);

            bool conseguiuEditar = false;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (manutencao[i] == null) continue;

                else if (manutencao[i].IdManutencao == idSelecionado)
                {
                    manutencao[i].Titulo = novaManutencao.Titulo;
                    manutencao[i].Descricao = novaManutencao.Descricao;
                    manutencao[i].equipamento = novaManutencao.equipamento;
                    manutencao[i].DataDeAbertura = novaManutencao.DataDeAbertura;

                    conseguiuEditar = true;
                }
            }

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição da manutenção...");
                return;
            }

            Console.WriteLine("\nO registro de manutenção foi editado com sucesso!");
        }
        public void ExcluirManutencao()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("    Exclusão de Manutenção    ");
            Console.WriteLine("------------------------------");

            VisualizarEquipamentos(true);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = false;

            for (int i = 0; i < manutencao.Length; i++)
            {
                if (manutencao[i] == null) continue;

                else if (manutencao[i].IdManutencao == idSelecionado)
                {
                    manutencao[i] = null!;
                    conseguiuExcluir = true;
                }
            }
            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão de um registro... ");
                return;
            }

            Console.WriteLine("\nO registro de manutenção foi excluído com sucesso!");
        }
    }
}
