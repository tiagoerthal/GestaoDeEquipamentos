


using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricantes
{
    public class TelaFabricante
    {
        public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine();
        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastro de Fabricante");
            Console.WriteLine("2 - Visualizar Fabricantes");
            Console.WriteLine("3 - Editar Fabricantes");
            Console.WriteLine("4 - Excluir Fabricantes");
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

            Fabricantes fabricantes = ObterDados();


            Console.WriteLine($"\nFabricante \"{fabricantes.nomeFabricante}\" cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void VisualizarRegistros(bool exibirCabecalho)
        {
            throw new NotImplementedException();
        }

        public Fabricantes ObterDados()
        {
            Console.Write("Digite o nome do Fabricante: ");
            string nomeFabricante = Console.ReadLine();

            Console.Write("Digite o email do Fabricante: ");
            string emailFabricante = Console.ReadLine();

            Console.Write("Digite o número de telefone do Fabricante: ");
            string telefoneFabricante = Console.ReadLine();

            VisualizarEquipamentos();

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            return null;
        }

        public void VisualizarEquipamentos()
        {
            Console.WriteLine("Visualização de Equipamentos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamentos();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                    e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
                );
            }

            Console.ReadLine();
        }
    }
}
