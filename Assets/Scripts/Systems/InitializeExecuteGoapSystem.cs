using Entitas;

public sealed class InitializeExecuteGoapSystem : IExecuteSystem, IInitializeSystem
{
    private GoapAgentsController _goapAgentsController;
    private GameContext _context;

    public InitializeExecuteGoapSystem(GameContext context)
    {
        _context = context;
    }
		
    public void Initialize()
    {
        _goapAgentsController = new GoapAgentsController(_context);
    }
    
    public void Execute()
    {
        _goapAgentsController.UpdateAgentPlan();
    }

}