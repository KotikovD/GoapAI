using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class WorldInventoryComponent : IComponent
{
  public WorldInventoryFacade Inventory;
}