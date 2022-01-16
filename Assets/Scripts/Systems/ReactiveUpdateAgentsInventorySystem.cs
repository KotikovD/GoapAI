using System.Collections.Generic;
using Entitas;

public sealed class ReactiveUpdateAgentsInventorySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReactiveUpdateAgentsInventorySystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceItem.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResourceItem && entity.hasAgent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var res in entity.resourceItem.Items)
            {
                var resource = new RepositoryItem(res.Value, () => _context.playerBase.PlayerBaseView.InteractionPoint);
                entity.agentInventory.Inventory.AddItem(res.Key, resource);
            }

            entity.RemoveResourceItem();
            entity.isNeedUpdateGameUi = true; 
        }
    }
}