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

    public Goal GetGoal(GoalName goalName)
    {
        var goal = _currentGoals.Find(x => x.GoalName == goalName);
        return goal;
    }
    
    public List<Goal> GetActualGoals()
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