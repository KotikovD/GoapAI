using System;
using System.Collections.Generic;


public class AgentActionsCollectionBase
{
    private readonly AgentsActionsData _actionsData;
    private readonly List<AgentAction> _agentActions;
    
    internal AgentActionsCollectionBase(GameContext context)
    {
        _actionsData = context.dataService.value.AgentsActions;
        _agentActions = new List<AgentAction>();
    }

    public List<AgentAction> GetActions => _agentActions;
    
    internal void Add(AgentAction agentAction)
    {
        _agentActions.Add(agentAction);
    }

    internal T GetData<T>() where T : AgentAction, new()
    {
        var actionData = _actionsData.AgentsActions.Find(x =>
            String.Equals(x.ActionName, typeof(T).Name, StringComparison.CurrentCultureIgnoreCase));

        if (actionData == null)
            throw new Exception("Didn't found actionName = " + typeof(T).Name + " in AgentsActionsData SO");

        var agentAction = new T();
        agentAction.Init(actionData.ActionName,
            actionData.PreconditionGoals,
            actionData.EffectsGoals,
            actionData.DifficultCost);

        return agentAction;
    }
}