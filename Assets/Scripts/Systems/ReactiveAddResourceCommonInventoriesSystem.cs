using System.Collections.Generic;
using Entitas;

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
                if(entity.commonInventory.Inventory.CanGetMoreResources(res.Value))
                {
                    var resource = new RepositoryItem(res.Value, () => _context.playerBase.PlayerBaseView.GetPosition);
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