﻿namespace GestaoDeEquipamentos.ConsoleApp;
internal class Program
{
    static void Main(string[] args)
    {

        TelaEquipamento telaEquipamento = new TelaEquipamento();
        bool prosseguir = true;
        while (prosseguir)
        {
            string opcaoEscolhida = telaEquipamento.ApresentarMenu();

            switch (opcaoEscolhida)
            {
                case "1":
                    telaEquipamento.CadastrarEquipamentos();
                    break;

                case "2":
                    telaEquipamento.EditarEquipamento();
                    break;

                case "3":
                    telaEquipamento.ExcluirEquipamento();
                    break;

                case "4":
                    telaEquipamento.VisualizarEquipamentos(true);
                    break;

                default:
                    Console.WriteLine("Saindo do programa... ");
                    prosseguir = false;
                    break;
            }
            Console.ReadLine();
        }
    }


}
