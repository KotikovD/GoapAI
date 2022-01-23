using Entitas;

[Game]
public sealed class ResourceMiningComponent : IComponent
{
    public float ActionIntervalDelay;
    public ushort ResourceCountPerInterval;
    public ResourceType RequirementsForInteraction;
}