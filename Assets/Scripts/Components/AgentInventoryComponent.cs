using Entitas;

[Game]
public sealed class AgentInventoryComponent : IComponent
{
    public IRepository<ResourceType> Inventory;
}