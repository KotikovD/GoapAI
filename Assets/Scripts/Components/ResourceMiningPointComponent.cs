using Entitas;

[Game]
public sealed class ResourceMiningComponent : IComponent
{
    public ResourceType MiningResourceType;
    public float ActionIntervalDelay;
    public int ResourceCountPerInterval;
    public ResourceType RequirementsForInteraction;
}