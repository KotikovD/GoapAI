using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class PlayerBaseComponent : IComponent
{
    public PlayerBaseView PlayerBaseView;
}