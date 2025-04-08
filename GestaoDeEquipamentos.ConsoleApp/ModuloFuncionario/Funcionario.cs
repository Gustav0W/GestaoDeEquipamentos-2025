using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFuncionario;
public class Funcionario
{
    public int Id;
    public string Nome;
    public string Email;
    public string Telefone;
    public int QtdItensFabricados;
    public Funcionario(string nome, string email, string telefone, int qtdItensFabricados)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        QtdItensFabricados = qtdItensFabricados;
    }

}

