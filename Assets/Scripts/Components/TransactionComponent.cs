using Entitas;

[Game]
public sealed class TransactionComponent : IComponent
{
    public GameEntity To;
    public ResourceType ResourceType;
    public int ResourceCount;
}