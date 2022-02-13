using System;
using System.Collections.Generic;
using System.Linq;

public sealed class GoalsManager
{
    private readonly GoalsData _goalsData;
    private readonly ConstantsData _constants;
    private List<Goal> _currentGoals;

    public GoalsManager(GameContext context)
    {
        _goalsData = context.dataService.value.Goals;
        _constants = context.dataService.value.Constants;
    }
    
    public List<Goal> GetGoals(List<GoalName> goalName)
    {
        var goals = goalName.Select(GetGoal).ToList();
        return goals;
    }
    
    public Goal GetGoal(GoalName goalName)
    {
        var goal = _currentGoals.Find(x => x.GoalName == goalName);
        return goal;
    }

    public Goal GetGoalForAgent(AgentType agentType)
    {
        switch (agentType)
        {
            case AgentType.Worker:
                return GetAllActualGoals()
                    .Where(x => x.AgentType == AgentType.Any || x.AgentType == agentType)
                    .OrderBy(x => x.Importance)
                    .First();

            default:
                throw new ArgumentOutOfRangeException(nameof(agentType), agentType, null);
        }
    }
    
    public List<Goal> GetAllActualGoals()
    {
        var currentWorldState = DetermineWorldState();
        _currentGoals = _goalsData.GetGoalsData(currentWorldState).Select(x => x.GetGoal()).ToList();
        return _currentGoals;
    }

    private WorldState DetermineWorldState()
    {
        //TODO method have to determine state use global data 
        return _constants.WorldState;
    }
    
}