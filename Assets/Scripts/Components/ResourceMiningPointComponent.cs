using Entitas;

[Game]
public sealed class ResourceMiningComponent : IComponent
{
    public float ActionIntervalDelay;
    public int ResourceCountPerInterval;
    public ResourceType RequirementsForInteraction;
}