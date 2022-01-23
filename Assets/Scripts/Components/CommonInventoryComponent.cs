using Entitas;

[Game]
public sealed class CommonInventoryComponent : IComponent
{
    public CommonInventoryFacade Inventory;
    public int MaxResourceCapacity;
}