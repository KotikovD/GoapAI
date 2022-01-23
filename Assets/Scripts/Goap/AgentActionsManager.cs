using System.Collections.Generic;
using Goap.Actions;

public sealed class AgentActionsManager
{
    private readonly List<AgentAction> _agentActions;

    public List<AgentAction> AgentActions => _agentActions;

    public AgentActionsManager(GameContext context)
    {
        _agentActions = new List<AgentAction>();
        var actionsData = context.dataService.value.AgentsActions;

        var colectWoodData = actionsData.GetData(nameof(CollectWood));
        var collectWood = new CollectWood(colectWoodData);
        
        _agentActions.Add(collectWood);
    }
}