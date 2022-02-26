using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ReactiveAddResourceCommonInventoriesSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReactiveAddResourceCommonInventoriesSystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceSetter.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.hasWorldInventory;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var res in entity.resourceSetter.Items)
            {
                if(entity.commonInventory.Inventory.HasAnyCapacity(out int freeCapacity))
                {
                    var resource = new RepositoryItem(res.Value, () => _context.playerBase.PlayerBaseView.GetPosition);

                    if(resource.Count > freeCapacity)
                    {
                        Debug.LogError($"Resource count bigger than free space in inventory. Put {freeCapacity} instead of {resource.Count}");
                        resource.Count = freeCapacity;
                    }
                    
                    entity.commonInventory.Inventory.AddResource(res.Key, resource);
                }
                else
                {
                    entity.isCantCarryMore = true;
                    break;
                }
            }

            entity.RemoveResourceSetter();
        }
    }
}