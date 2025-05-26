﻿using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase
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

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Equipamento equipamentoAtualizado = (Equipamento)registroAtualizado;

        this.nome = equipamentoAtualizado.nome;
        this.precoAquisicao = equipamentoAtualizado.precoAquisicao;
        this.numeroSerie = equipamentoAtualizado.numeroSerie;
        this.fabricante = equipamentoAtualizado.fabricante;
        this.dataFabricacao = equipamentoAtualizado.dataFabricacao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome))
            erros += "O campo \"Nome\" é obrigatório.\n";

        else if (nome.Length < 3)
            erros += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

        if (precoAquisicao <= 0)
            erros += "O campo \"Preço de Aquisição\" deve ser maior que zero.\n";

        if (dataFabricacao > DateTime.Now)
            erros += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

        return erros;
    }
}