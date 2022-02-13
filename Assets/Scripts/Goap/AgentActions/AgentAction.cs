using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitas;
using RSG;
using UnityEngine;

public abstract class AgentAction
{
    private readonly string _actionName;
    private readonly List<GoalName> _preconditionGoalsNames;
    private readonly List<GoalName> _effectsGoalsNames;
    private readonly int _difficultCost;

    
    protected AgentAction(AgentActionData actionsData)
    {
        _actionName = actionsData.ActionName;
        _preconditionGoalsNames = actionsData.PreconditionGoals;
        _effectsGoalsNames = actionsData.EffectsGoals;
        _difficultCost = actionsData.DifficultCost;
    }

    public string ActionName => _actionName;

    public List<GoalName> PreconditionGoalsNames => _preconditionGoalsNames;

    public List<GoalName> EffectsGoalsNames => _effectsGoalsNames;

    public int DifficultCost => _difficultCost;

    public bool IsRunning { get; set; }

    public bool IsAchieved(List<Goal> conditions)
    {
        if (!_preconditionGoalsNames.Any() || _preconditionGoalsNames.Count == 1 && _preconditionGoalsNames.First() == GoalName.None)
            return true;
        
        foreach (var preconditionGoal in _preconditionGoalsNames)
        {
            if (conditions.Any(x => x.GoalName == preconditionGoal))
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

    public abstract bool PrePerform(List<GameEntity> gameEntities, GameEntity agent);
    public abstract void CompletePerform(GameEntity agent);

    public virtual bool IsAchievable()
    {
        return true;
    }
    
}