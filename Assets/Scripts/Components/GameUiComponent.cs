using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class GameUiComponent : IComponent
{
    public GameUiView View;
}