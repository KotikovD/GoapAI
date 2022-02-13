using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class ReactiveProduceTransactionsSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReactiveProduceTransactionsSystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Transaction.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCommonInventory;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var transaction = entity.transaction;
            var inventory = entity.commonInventory.Inventory;
            
            var resourceCount = entity.commonInventory.Inventory.GetResourceCount(transaction.ResourceType);
            var transactionCount = resourceCount < transaction.ResourceCount ? resourceCount : transaction.ResourceCount;
            
            inventory.GetResource(transaction.ResourceType, transactionCount, out var item);
            transaction.To.commonInventory.Inventory.AddResource(transaction.ResourceType, item);
            entity.RemoveTransaction();
            
            UpdateDisplayedEntityUi();
        }
    }

    private void UpdateDisplayedEntityUi()
    {
        var displayed = _context.GetGroup(GameMatcher.DisplayedGameUi).GetEntities();
        if (displayed.Any())
            displayed.First().isNeedUpdateGameUi = true;
    }
}