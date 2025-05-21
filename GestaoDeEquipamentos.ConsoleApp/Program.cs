﻿using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Fabricante fabricante = new Fabricante("", "", "");

        RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante);

        TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioEquipamento);
        telaEquipamento.repositorioEquipamento = repositorioEquipamento;
        telaEquipamento.repositorioFabricante = repositorioFabricante;

        TelaChamado telaChamado = new TelaChamado(repositorioChamado);
        telaChamado.repositorioChamado = repositorioChamado;
        telaChamado.repositorioEquipamento = repositorioEquipamento;

        while (true)
        {
            char telaEscolhida = ApresentarMenuPrincipal();

            if (telaEscolhida == 'S' || telaEscolhida == 's')
                break;

            if (telaEscolhida == '1')
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
                        telaEquipamento.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaEquipamento.EditarRegistro();
                        break;

                    case '4':
                        telaEquipamento.ExcluirRegistro();
                        break;
                }
            }

            else if (telaEscolhida == '2')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaChamado.CadastrarRegistro();
                        break;

                    case '2':
                        telaChamado.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaChamado.EditarRegistro();
                        break;

                    case '4':
                        telaChamado.ExcluirRegistro();
                        break;
                }
            }

            else if (telaEscolhida == '3')
            {
                char opcaoEscolhida = telaFabricante.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaFabricante.CadastrarRegistro();
                        break;

                    case '2':
                        telaFabricante.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaFabricante.EditarRegistro();
                        break;

                    case '4':
                        telaFabricante.ExcluirRegistro();
                        break;
                }
            }

        }
    }

    public static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Equipamentos");
        Console.WriteLine("2 - Controle de Chamados");
        Console.WriteLine("3 - Controle de Fabricantes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }
}