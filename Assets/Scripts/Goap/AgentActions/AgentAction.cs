using System.Collections.Generic;
using System.Linq;

public abstract class AgentAction
{
    private readonly string _actionName;
    private readonly List<GoalName> _preconditionGoals;
    private readonly List<GoalName> _effectsGoals;
    private readonly int _difficultCost;


    protected AgentAction(AgentActionData actionsData)
    {
        _actionName = actionsData.ActionName;
        _preconditionGoals = actionsData.PreconditionGoals;
        _effectsGoals = actionsData.EffectsGoals;
        _difficultCost = actionsData.DifficultCost;
    }

    public string ActionName => _actionName;

    public List<GoalName> PreconditionGoals => _preconditionGoals;

    public List<GoalName> EffectsGoals => _effectsGoals;

    public int DifficultCost => _difficultCost;

    public bool IsRunning { get; set; }

    public bool IsAchieved(List<GoalName> conditions)
    {
        foreach (var preconditionGoal in _preconditionGoals)
        {
            if (conditions.Any(x => x == preconditionGoal))
                return true;
        }
        return false;
    }
    
    public abstract bool PrePerform();
    public abstract bool PostPerform();
}