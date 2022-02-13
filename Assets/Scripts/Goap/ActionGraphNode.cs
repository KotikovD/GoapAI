using System;
using System.Collections.Generic;

public sealed class ActionGraphNode 
{
    public ActionGraphNode Parent;
    public int DifficultCost;
    public List<Goal> Goals;
    public AgentAction Action;
    
    public ActionGraphNode(ActionGraphNode parent, int difficultCost, List<Goal> allGoals, AgentAction action)
    {
        Parent = parent;
        DifficultCost = difficultCost;
        Goals = allGoals;
        Action = action;
    }

    public static ActionGraphNode GetFirstNode(List<Goal> goals)
    {
        return new ActionGraphNode(null, 0, goals, null);
    }
    
}