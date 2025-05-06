﻿namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();
       while (true)
        {
            char opcaoEscolhida = telaEquipamento.ApresentarMenu();

            if (opcaoEscolhida == 'S')
                break;

            switch (opcaoEscolhida)
            {
                case '1':
                    telaEquipamento.CadastrarRegistro();
                    break;

                case '2':
                    telaEquipamento.VisualizarRegistros();
                    break;
            }
        }
    }
}
 // Apresentação
public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão De Equipamentos");
        Console.WriteLine();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1- Cadastro de Equipamento");
        Console.WriteLine("2- Visualizar Equipamento");
        Console.WriteLine("S- Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro De Equipamentos");
        Console.WriteLine();

        Console.WriteLine("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o preço de aquisição do equipamento: ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o número de série do equipamento: ");
        string numeroSerie = Console.ReadLine();

        Console.WriteLine("Digite o nome do fabricante do equipamento: ");
        string fabricante = Console.ReadLine();

        Console.WriteLine("Digite a data de fabricação do equipamento: ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisicao = precoAquisicao;
        equipamento.numeroSerie = numeroSerie;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = dataFabricacao;

        repositorioEquipamento.equipamentos[0] = equipamento;

        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Visualização De Equipamentos");
        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} | ",
            "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
        );

        Equipamento[] equipamentos = repositorioEquipamento.equipamentos;

        for ( int i = 0; i < equipamentos.Length; i++ )
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} | ",
                e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortTimeString()
            );
        }

        Console.ReadLine();
    }
}

// Dados
public class RepositorioEquipamento
{
    public Equipamento[] equipamentos = new Equipamento[100];
}

// Regra de negócio
public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public string fabricante;
    public DateTime dataFabricacao;

}