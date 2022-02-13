

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
}