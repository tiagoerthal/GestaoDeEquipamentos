
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class RepositorioBase
    {
        private Object[] registros = new Object[100];
        private int contadorRegistros = 0;

        public void CadastrarRegistro(Fabricante novoRegistro)
        {
            registros[contadorRegistros] = novoRegistro;

            contadorRegistros++;
        }

    }
}
