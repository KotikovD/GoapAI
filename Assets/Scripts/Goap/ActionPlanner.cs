using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public sealed class ActionPlanner
{
    private readonly GoalsManager _goalsManager;

    public ActionPlanner(GoalsManager goalsManager)
    {
        _goalsManager = goalsManager;
    }

    public bool GetActionsPlan(List<AgentAction> achievableActions, Goal agentGoal, out Queue<AgentAction> actionsQueue)
    {
        actionsQueue = new Queue<AgentAction>();

        if (BuildGraphRecursively(achievableActions, agentGoal, out var nodesChain))
        {
            actionsQueue = GetCheapestAgentActionsQueue(nodesChain);
            LogActions(actionsQueue, agentGoal);
            return true;
        }
       
        return false;
    }

    private void LogActions(Queue<AgentAction> actionsQueue, Goal agentGoal)
    {
        var log = "Goal is " + agentGoal.GoalName;
        foreach (var action in actionsQueue)
            log += "\n" + action.ActionName + " - " + action.DifficultCost;
        
        Debug.Log(log);
    }
    
    private Queue<AgentAction> GetCheapestAgentActionsQueue(List<ActionGraphNode> nodesChain)
    {
        var cheapestNode = nodesChain.OrderBy(x => x.DifficultCost).First();
        var result = new Queue<AgentAction>();
        
        while (cheapestNode != null)
        {
            if (cheapestNode.Action != null)
                result.Enqueue(cheapestNode.Action);

            cheapestNode = cheapestNode.Parent;
        }

        return result;
    }

    private bool BuildGraphRecursively(List<AgentAction> achievableActions, Goal agentGoal, out List<ActionGraphNode> nodesChain)
    {
        nodesChain = new List<ActionGraphNode>();
        var actualGoals = _goalsManager.GetAllActualGoals();
        var firstGraphNode = ActionGraphNode.GetFirstNode(actualGoals);
        var isGraphBuild = BuildGraph(firstGraphNode, nodesChain, achievableActions, agentGoal);
        return isGraphBuild;
    }

    private bool BuildGraph(ActionGraphNode parent, List<ActionGraphNode> nodesChain, List<AgentAction> achievableActions, Goal agentGoal)
    {
        var foundPath = false;
        foreach (var action in achievableActions)
        {
            if (action.IsAchieved(parent.Goals))
            {
                var actionEffectsGoals = _goalsManager.GetGoals(action.EffectsGoalsNames);
                var currentGoals = parent.Goals.Union(actionEffectsGoals).ToList();
                var sumDifficultCost = parent.DifficultCost + action.DifficultCost;
                var newGraphNode = new ActionGraphNode(parent, sumDifficultCost, currentGoals, action);
                
                if (currentGoals.Any(x => x.GoalName == agentGoal.GoalName)) 
                {
                    nodesChain.Add(newGraphNode);
                    foundPath = true;
                } 
                else
                {
                    var reducedAvailableActions =
                        achievableActions.Where(x => x.ActionName != action.ActionName).ToList();
                    
                    foundPath = BuildGraph(newGraphNode, nodesChain, reducedAvailableActions, agentGoal);
                }
            }
        }
        
        return foundPath;
    }
    
}