using System.Collections.Generic;
using Entitas;


public sealed class ReactiveRemoveResourceCommonInventoriesSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReactiveRemoveResourceCommonInventoriesSystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceGetter.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.hasWorldInventory;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var res in entity.resourceGetter.Items)
            {
                entity.commonInventory.Inventory.RemoveResource(res.Key, res.Value);
            }

            entity.RemoveResourceGetter();
        }
    }
}