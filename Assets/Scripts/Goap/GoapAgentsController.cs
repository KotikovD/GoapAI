using System.Numerics;

public sealed class GoapAgentsController //TODO embed in systems
{
    private readonly AgentActionsManager _agentActionsManager;
    private readonly GoalsManager _goalsManager;
    private readonly ActionPlanner _actionPlanner;
    //agents in context;
    
    public GoapAgentsController(GameContext context)
    {
        
        _goalsManager = new GoalsManager(context);
        _actionPlanner = new ActionPlanner(); //TODO logic
        _agentActionsManager = new AgentActionsManager(context); //TODO add more actions
    }

    void Update()
    {
        _goalsManager.GetActualGoals();
    }
}