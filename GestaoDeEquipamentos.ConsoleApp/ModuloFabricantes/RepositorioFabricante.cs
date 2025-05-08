
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricantes
{
    public class RepositorioFabricante
    {
        public Fabricantes[] Fabricantes = new Fabricantes[100];
        public int contadorFabricantes = 0;

        public void CadastrarFabricante(Fabricantes fabricantes)
        {
            Fabricantes[contadorFabricantes] = fabricantes;

            contadorFabricantes++;
     
        }
        public bool EditarFabricantes(int idSelecionado, Fabricantes fabricanteAtualizado)
        {
            Fabricantes fabricanteSelecionado = SelecionarFabricantePorId(idSelecionado);

            if (fabricanteSelecionado == null)
                return false;

            fabricanteSelecionado.nomeRepresentante = fabricanteAtualizado.nomeRepresentante;
            fabricanteSelecionado.emailFabricante = fabricanteAtualizado.emailFabricante;
            fabricanteSelecionado.telefoneFabricante = fabricanteAtualizado.telefoneFabricante;
            fabricanteSelecionado.equipamento = fabricanteAtualizado.equipamento;

            return true;
        }

        public bool ExcluirFabricantes(int idSelecionado)
        {
            for (int i = 0; i < Fabricantes.Length; i++)
            {
                if (Fabricantes[i] == null)
                    continue;

                if (Fabricantes[i].id == idSelecionado)
                {
                    Fabricantes[i] = null;

                    return true;
                }
            }

            return false;
        }

        public Fabricantes[] SelecionarFabricantes()
        {
            return Fabricantes;
        }

        public Fabricantes SelecionarFabricantePorId(int idSelecionado)
        {
            for (int i = 0; i < Fabricantes.Length; i++)
            {
                Fabricantes f = Fabricantes[i];

                if (f == null)
                    continue;

                if (f.id == idSelecionado)
                    return f;
            }

            return null;
        }
    }
}