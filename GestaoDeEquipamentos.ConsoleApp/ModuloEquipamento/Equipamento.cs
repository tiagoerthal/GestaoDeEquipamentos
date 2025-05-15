using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public Fabricante fabricante;
    public DateTime dataFabricacao;

    public Equipamento(string nome, decimal precoAquisicao, string numeroSerie, Fabricante fabricante, DateTime dataFabricacao)
    {
        this.nome = nome;
        this.precoAquisicao = precoAquisicao;
        this.numeroSerie = numeroSerie;
        this.fabricante = fabricante;
        this.dataFabricacao = dataFabricacao;
    }
}