using System.Collections.Generic;
using System.Linq;
using Entitas;

public class ReactiveUpdateGameUiSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReactiveUpdateGameUiSystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NeedUpdateGameUi);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        UpdateInventoryUi(entities);
        UpdateCommonInventory(entities);
    }

    private void UpdateCommonInventory(List<GameEntity> entities)
    {
        var agentToUpdate = entities.FirstOrDefault(x => x.hasCommonInventory && x.isNeedUpdateGameUi);
        if (agentToUpdate == null)
            return;

        agentToUpdate.isNeedUpdateGameUi = false;
        var newText = agentToUpdate.commonInventory.Inventory.GetTotalAmountString();
        _context.gameUi.View.SetAgentText(newText);
    }

    private void UpdateInventoryUi(List<GameEntity> entities)
    {
        var gameUi = entities.FirstOrDefault(x => x.hasGameUi && x.isNeedUpdateGameUi);
        if(gameUi == null)
            return;
        
        gameUi.isNeedUpdateGameUi = false;
        var newText = _context.worldInventory.Inventory.GetTotalAmountString();
        _context.gameUi.View.SetInventoryText(newText);
    }
}