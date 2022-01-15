using Entitas;

public class InitializeDataServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitializeDataServiceSystem(Contexts context)
    {
        _context = context.game;
    }

    public void Initialize()
    {
        _context.SetDataService(new DataService(new DataLoader()));
    }
}