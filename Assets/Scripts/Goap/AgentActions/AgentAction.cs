using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AgentAction : IAgentAction
{
    private string _actionName;
    private List<GoalPair> _preconditionGoals;
    private List<GoalPair> _effectsGoalsNames;
    private int _difficultCost;

    
    public void Init(string actionName, 
        List<GoalPair> preconditionGoals, 
        List<GoalPair> effectsGoals, 
        int difficultCost)
    {
        _actionName = actionName;
        _preconditionGoals = preconditionGoals;
        _effectsGoalsNames = effectsGoals;
        _difficultCost = difficultCost;
    }

    public string ActionName => _actionName;

    public List<GoalPair> PreconditionGoals => _preconditionGoals;

    public List<GoalPair> EffectsGoalsNames => _effectsGoalsNames;

    public int DifficultCost => _difficultCost;

    public bool IsRunning { get; set; }

    public bool CouldBeAchieved(List<Goal> conditions)
    {
        if (!_preconditionGoals.Any() || _preconditionGoals.Count == 1 && _preconditionGoals.First().GoalName == GoalName.None)
            return true;
        
        foreach (var preconditionGoal in _preconditionGoals)
        {
            if (conditions.Any(x => x.GoalName == preconditionGoal.GoalName))
                return true;
        }
        
        return false;
    }

    
    internal bool FindClosestObject(Vector3 agentPosition, List<GameEntity> entities, out GameEntity closestEntity)
    {
        var closestDistance = float.MaxValue;
        closestEntity = null;
			
        foreach (var one in entities)
        {
            var currentDistance = Vector3.Distance(agentPosition, one.commonView.CommonView.GetPosition);

            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestEntity = one;
            }
        }

        return closestEntity != null;
    }

    public bool CanPerform(List<GameEntity> gameEntities, GameEntity agent)
    {
        return CanPerform(gameEntities, agent, out GameEntity actionEntity);
    }

    public abstract bool CanPerform(List<GameEntity> gameEntities, GameEntity agent, out GameEntity actionEntity);
    public abstract void ProducePerform(GameEntity agent);

    public virtual bool IsAchievable()
    {
        return true;
    }
    
}