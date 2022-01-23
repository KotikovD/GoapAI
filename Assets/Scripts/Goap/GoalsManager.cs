using System.Collections.Generic;
using System.Linq;


public sealed class GoalsManager
{
    private readonly GoalsData _goalsData;
    private readonly ConstantsData _constants;

    public GoalsManager(GameContext context)
    {
        _goalsData = context.dataService.value.Goals;
        _constants = context.dataService.value.Constants;
    }
    
    
    public List<Goal> GetActualGoals()
    {
        var state = DetermineWorldState();
        var goals = _goalsData.GetGoalsData(state).Select(x => x.GetGoal()).ToList();
        return goals;
    }

    private WorldState DetermineWorldState()
    {
        //TODO method have to determine state use global data 
        return _constants.WorldState;
    }
    
}