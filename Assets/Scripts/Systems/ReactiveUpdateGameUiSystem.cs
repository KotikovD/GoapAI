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
        UpdateWorldInventoryUi(entities);
        UpdateAnyUnit(entities);
    }

    /*private bool CanUpdateUiNow(GameEntity gameEntity)
    {
        var displayed = _context.GetGroup(GameMatcher.DisplayedGameUi).GetEntities();
        var canUpdate = !displayed.Any() || gameEntity.isDisplayedGameUi;
        return canUpdate;
     }*/
    
    private void UpdateAnyUnit(List<GameEntity> entities)
    {
        var entity = entities.FirstOrDefault(x => x.hasCommonInventory && x.isNeedUpdateGameUi && x.isDisplayedGameUi);
        if (entity == null)
        {
            entities.FindAll(x => x.hasCommonInventory && x.isNeedUpdateGameUi)
                .ForEach(x => x.isNeedUpdateGameUi = false);
            return;
        }

        entity.isNeedUpdateGameUi = false;
        /*if(!CanUpdateUiNow(entity))
            return;*/
        
        UpdateCommonInventoryUI(entity);
        UpdateAgentPlanUI(entity);
    }

    private void UpdateCommonInventoryUI(GameEntity agent)
    {
        var name = agent.commonView.CommonView.gameObject.name;
        var newText = agent.commonInventory.Inventory.GetTotalAmountString();
        _context.gameUi.View.SetAgentText("<b>" + name + "</b>\n" + newText);
    }

    private void UpdateAgentPlanUI(GameEntity agent)
    {
        if(!agent.hasAgentAction || !agent.hasAgentView)
        {
            _context.gameUi.View.ClearAgentPlanView();
            return;
        }
        
        var action = agent.agentAction;
        var actionPlanString = "<b>Action plan:</b>\n";
        actionPlanString += "<b>Goal:</b> " + (action.Goal == null ? "empty" : action.Goal.GoalName.ToString()) + "\n";
        actionPlanString += "<b>CurrentAction:</b> " + (action.CurrentAction == null ? "empty" : action.CurrentAction.ActionName) + "\n";
        actionPlanString += "<b>IsRunning:</b> " + (action.CurrentAction == null ? "false" : action.CurrentAction.IsRunning.ToString()) + "\n";
        actionPlanString += "<b>Actions queue:</b> \n";
        foreach (var a in action.ActionQueue)
            actionPlanString += a.ActionName + "\n";

        _context.gameUi.View.SetAgentPlanText(actionPlanString);
    }

    private void UpdateWorldInventoryUi(List<GameEntity> entities)
    {
        var gameUi = entities.FirstOrDefault(x => x.hasGameUi && x.isNeedUpdateGameUi);
        if(gameUi == null)
            return;
        
        gameUi.isNeedUpdateGameUi = false;
        var newText = _context.worldInventory.Inventory.GetTotalAmountString();
        _context.gameUi.View.SetInventoryText("<b>World inventory:</b>\n" + newText);
    }
}