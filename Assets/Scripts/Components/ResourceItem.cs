using System.Collections.Generic;
using Entitas;

[Game]
public sealed class ResourceItem : IComponent
{
    public Dictionary<ResourceType, int> Items;
}