using System.Collections.Generic;
using Entitas;

[Game]
public sealed class ResourceGetterComponent : IComponent
{
    public Dictionary<ResourceType, int> Items;
}