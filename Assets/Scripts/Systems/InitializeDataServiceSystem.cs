using Entitas;

public class InitializeDataServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitializeDataServiceSystem(GameContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        _context.SetDataService(new DataService(new DataLoader()));
    }
}