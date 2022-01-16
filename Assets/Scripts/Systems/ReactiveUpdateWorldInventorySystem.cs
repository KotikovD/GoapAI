using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class ReactiveUpdateWorldInventorySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReactiveUpdateWorldInventorySystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceItem.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResourceItem && entity.hasWorldInventory;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var inventoryEnity = entities.First();
        foreach (var entity in inventoryEnity.resourceItem.Items)
        {
            var resource = new RepositoryItem(entity.Value, () => _context.playerBase.PlayerBaseView.InteractionPoint);
            _context.worldInventory.Inventory.AddItem(entity.Key, resource);
        }
        
        inventoryEnity.RemoveResourceItem();
        _context.gameUiEntity.isNeedUpdateGameUi = true;
    }
}