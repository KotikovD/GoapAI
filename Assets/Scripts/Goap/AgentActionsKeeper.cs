

using System;
using System.Collections.Generic;
using System.Linq;

public class AgentActionsKeeper
{
    public List<AgentAction> AgentActions { get; }

    protected AgentActionsKeeper()
    {
        AgentActions = new List<AgentAction>();
    }

    internal void Add(AgentAction agentAction)
    {
        AgentActions.Add(agentAction);
    }
    
    public List<AgentAction> GetAchievableActions()
    {
        var usableActions = AgentActions.Where(x => x.IsAchievable()).ToList();
        return usableActions;
    }
    
    internal AgentActionData GetData(string actionName, AgentsActionsData actionsData)
    {
        var actionData = actionsData.AgentsActions.Find(x => String.Equals(x.ActionName, actionName, StringComparison.CurrentCultureIgnoreCase));

        if (actionData == null)
            throw new Exception("Didn't found actionName = " + actionName + " in AgentsActionsData SO");
        
        return actionData;
    }
}