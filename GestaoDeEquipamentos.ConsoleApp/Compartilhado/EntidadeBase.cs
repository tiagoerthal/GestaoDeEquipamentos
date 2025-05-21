﻿using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class EntidadeBase
{
    public int id;

    public abstract void AtualizarRegistro(EntidadeBase registroAtualizado);
}