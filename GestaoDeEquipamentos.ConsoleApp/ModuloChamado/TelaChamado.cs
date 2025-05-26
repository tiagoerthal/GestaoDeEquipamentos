
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado : TelaBase
{
    private RepositorioChamado repositorioChamado;
    private RepositorioEquipamento repositorioEquipamento;

    public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
        : base("Chamado", repositorioChamado)
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Chamados");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20}",
            "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
        );

        EntidadeBase[] chamados = repositorioChamado.SelecionarRegistros();

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado c = (Chamado)chamados[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20}",
                c.id, c.titulo, c.descricao, c.dataAbertura.ToShortDateString(), c.equipamento.nome
            );
        }

        Console.ReadLine();
    }

    protected override Chamado ObterDados()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        DateTime dataAbertura = DateTime.Now;

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarRegistroPorId(idEquipamento);

        Chamado chamado = new Chamado(titulo, descricao, dataAbertura, equipamentoSelecionado);

        return chamado;
    }

    public void VisualizarEquipamentos()
    {
        Console.WriteLine();

        Console.WriteLine("Visualização de Equipamentos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
            "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
        );

        EntidadeBase[] equipamentos = repositorioEquipamento.SelecionarRegistros();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = (Equipamento)equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante.nome, e.dataFabricacao.ToShortDateString()
            );
        }

        Console.ReadLine();
    }
}