﻿namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    private RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioF)
    {
        repositorioFabricante = repositorioF;
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Fabricante");
        Console.WriteLine("2 - Visualizar Fabricantes");
        Console.WriteLine("3 - Editar Fabricante");
        Console.WriteLine("4 - Excluir Fabricante");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro de Fabricantes");

        Console.WriteLine();

        Fabricante novoFabricante = ObterDados();

        string erros = novoFabricante.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nDigite ENTER para continuar...");
            Console.ReadLine();

            CadastrarRegistro();

            return;
        }

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Console.WriteLine($"\nFabricante \"{novoFabricante.nome}\" cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Fabricantes");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Fabricante fabricanteAtualizado = ObterDados();

        repositorioFabricante.EditarFabricante(idSelecionado, fabricanteAtualizado);

        Console.WriteLine($"\nFabricante \"{fabricanteAtualizado.nome}\" editado com sucesso!");
        Console.ReadLine();
    }

    public void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Fabricantes");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        repositorioFabricante.ExcluirFabricante(idSelecionado);

        Console.WriteLine($"\nFabricante excluído com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Fabricantes");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Nome", "Email", "Telefone"
        );

        Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.ReadLine();
    }

    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine();
    }

    private Fabricante ObterDados()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o endereço de email do fabricante: ");
        string email = Console.ReadLine();

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        return fabricante;
    }
}