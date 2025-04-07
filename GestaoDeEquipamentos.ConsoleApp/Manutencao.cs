namespace GestaoDeEquipamentos.ConsoleApp;
public class ChamadoManutencao
{
    public int IdManutencao = 0;
    public string Titulo = " ";
    public string Descricao = " ";
    public string equipamento = " ";
    public DateTime DataDeAbertura;

    public ChamadoManutencao(string titulo, string descricao, string equipamento, DateTime dataDeAbertura)
    {
        Titulo = titulo;
        Descricao = descricao;
        this.equipamento = equipamento;
        DataDeAbertura = dataDeAbertura;
    }


}
