using System.Collections.Generic;
using System.Linq;
using RSG;
using UnityEngine;


public sealed class GoapAgentsController //TODO embed in systems
{
    private readonly AgentActionsKeeper _agentActionsKeeper;
    private readonly GoalsManager _goalsManager;
    private readonly ActionPlanner _actionPlanner;
    private readonly GameContext _context;
    
    private List<GameEntity> GameEntities => _context.GetGroup(GameMatcher.AllOf(GameMatcher.CommonView)).GetEntities().ToList();  //TODO create discovered game objects list and add to context
    private List<GameEntity> AgentEntities => _context.GetGroup(GameMatcher.AllOf(GameMatcher.AgentView)).GetEntities().ToList();  //TODO create discovered game objects list and add to context
    
    public GoapAgentsController(GameContext context)
    {
        _context = context;
        _goalsManager = new GoalsManager(context);
        _agentActionsKeeper = new AgentActionsCollection(context);
        _actionPlanner = new ActionPlanner(_goalsManager);
    }

    public void UpdateAgentPlan() 
    {
        foreach (var agentEntity in AgentEntities)
        {
            TryAddAgentAction(agentEntity);
            TrySetNewGoalForAgent(agentEntity);
            TryCreateActionsQueue(agentEntity);
            TryProduceActionsQueue(agentEntity);
        }
    }

    private void TryProduceActionsQueue(GameEntity agentEntity)
    {
        var agentAction = agentEntity.agentAction;
        var actionsQueue = agentAction.ActionQueue;

        if (agentAction.CurrentAction != null && agentAction.CurrentAction.IsRunning)
            return;

        if (actionsQueue == null)
            return;

        agentAction.CurrentAction = actionsQueue.Dequeue();
        if (agentAction.CurrentAction.PrePerform(GameEntities, agentEntity))
        {
            agentAction.CurrentAction.IsRunning = true;
            GoToActionInteractionPoint(agentEntity)
                .Then(TryCompletePerform)
                .Then(isComplete =>
                {
                    if (!isComplete)
                        DisposeCurrentAction(agentAction);
                });
        }
        else
        {
            DisposeCurrentAction(agentAction);
        }
    }

    private IPromise<bool> TryCompletePerform(GameEntity agent)
    {
        var promise = new Promise<bool>();

        if (CheckInteractionEntity(agent))
        {
            agent.agentAction.ActionEntity.isFreeInteractionPoint = false;
            CompletePerform(agent).Then(() =>
            {
                agent.agentAction.ActionEntity.isFreeInteractionPoint = true;
                promise.Resolve(true);
            });
        }
        else
        {
            promise.Resolve(false);
        }
      
        
        return promise;
    }
    
    private void DisposeCurrentAction(AgentActionComponent agentAction)
    {
        agentAction.ActionQueue.Clear();
        agentAction.Goal = null;
        agentAction.ActionEntity = null;
        agentAction.CurrentAction = null;
    }
    
    private IPromise<GameEntity> GoToActionInteractionPoint(GameEntity agentEntity)
    {
        var promise = new Promise<GameEntity>();
        var destination = agentEntity.agentAction.ActionEntity.commonView.CommonView.InteractionPoint;
        
        agentEntity.agentView.AgentView.Move(destination)
            .Then(() => promise.Resolve(agentEntity));

        return promise;
    }

    private bool CheckInteractionEntity(GameEntity agentEntity)
    {
        var isAchievable = agentEntity.agentAction.CurrentAction.IsAchievable();
        var canUse = agentEntity.agentAction.ActionEntity.isFreeInteractionPoint;
        return canUse && isAchievable;
    }

    private IPromise CompletePerform(GameEntity agentEntity)
    {
        var promise = new Promise();
        var agentAction = agentEntity.agentAction;
        Debug.Log("1 CompletePerform");
        
        PromiseTimerUtil.ResolveIn(agentEntity.agentAction.ActionEntity.resourceMining.ActionIntervalDelay)
            .Then(() =>
            {
                agentAction.CurrentAction.CompletePerform(agentEntity);
                agentAction.CurrentAction.IsRunning = false;
                Debug.Log("2 CompletePerform");
                promise.Resolve();
            });
        
        return promise;
    }
    
    private void TryCreateActionsQueue(GameEntity agentEntity)
    {
        if (agentEntity.agentAction.ActionQueue != null && agentEntity.agentAction.ActionQueue.Count > 0)
            return;
        
        var achievableActions = _agentActionsKeeper.GetAchievableActions();
        if (_actionPlanner.GetActionsPlan(achievableActions, agentEntity.agentAction.Goal, out var actionsQueue))
        {
            agentEntity.agentAction.ActionQueue = actionsQueue;
        }
        else
        {
            Debug.LogError("No plan for goal = " + agentEntity.agentAction.Goal);
        }
    }

    private void TrySetNewGoalForAgent(GameEntity agentEntity)
    {
        if (agentEntity.agentAction.Goal != null)
            return;

        var goalForAgent = _goalsManager.GetGoalForAgent(agentEntity.agentAction.AgentType);
        agentEntity.agentAction.Goal = goalForAgent;
    }

    private void TryAddAgentAction(GameEntity agentEntity)
    {
        if (agentEntity.hasAgentAction)
            return;
        
        agentEntity.AddAgentAction(AgentType.Worker, new Queue<AgentAction>(), null, null, null);
    }
    
    
    
    
}