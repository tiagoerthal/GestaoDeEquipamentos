


using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricantes
{
    public class TelaFabricante
    {
        public RepositorioEquipamento repositorioEquipamento;
        public RepositorioFabricante repositorioFabricante;
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

            repositorioFabricante.CadastrarFabricante(fabricantes);

            Console.WriteLine($"\nRepresentante \"{fabricantes.nomeRepresentante}\" cadastrado com sucesso!");
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

            Fabricantes fabricanteAtualizado = ObterDados();

            bool conseguiuEditar = repositorioFabricante.EditarFabricantes(idSelecionado, fabricanteAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nRepresentante \"{fabricanteAtualizado.nomeRepresentante}\" editado com sucesso!");
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

            bool conseguiuExcluir = repositorioFabricante.ExcluirFabricantes(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nRepresentante excluído com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Fabricantes");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -20}",
                "Id", "Nome do Representante", "E-mail", "Número de Telefone", "Equipamento"
            );

            Fabricantes[] fabricantes = repositorioFabricante.SelecionarFabricantes();

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricantes f = fabricantes[i];

                if (f == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -20}",
                    f.id, f.nomeRepresentante, f.emailFabricante, f.telefoneFabricante, f.equipamento.nome
                );
            }

            Console.ReadLine();
        }

        public Fabricantes ObterDados()
        {
            Console.Write("Digite o nome do Representante: ");
            string nomeRepresentante = Console.ReadLine();

            Console.Write("Digite o email do Fabricante: ");
            string emailFabricante = Console.ReadLine();

            Console.Write("Digite o número de telefone do Fabricante: ");
            string telefoneFabricante = Console.ReadLine();

            VisualizarEquipamentos();

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);
            
            Fabricantes fabricantes = new Fabricantes();
            fabricantes.nomeRepresentante = nomeRepresentante;
            fabricantes.emailFabricante = emailFabricante;
            fabricantes.telefoneFabricante = telefoneFabricante;
            fabricantes.equipamento = equipamentoSelecionado;

            return fabricantes;
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
