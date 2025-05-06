namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
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
                    Console.WriteLine();
                    break;
            }

        }


    }
}

public class TelaEquipamento
{
    public char ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("Gestão De Equipamentos");

        Console.WriteLine();

        Console.WriteLine("1- Cadastro de Equipamento");
        Console.WriteLine("S- Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }
}

public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public string fabricante;
    public DateTime dataFabricacao;

}