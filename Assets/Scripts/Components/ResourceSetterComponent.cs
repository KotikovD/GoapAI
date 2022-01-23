using System.Collections.Generic;
using Entitas;

[Game]
public sealed class ResourceSetterComponent : IComponent
{
    public Dictionary<ResourceType, int> Items;
}