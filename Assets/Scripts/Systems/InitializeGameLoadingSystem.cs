using System;
using Entitas;

public class InitializeGameLoadingSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitializeGameLoadingSystem(GameContext context)
    {
        _context = context;
    }

    private IGameLoader InitializeLoadType( )
    {
        IGameLoader gameLoader;
        var loadBy = _context.dataService.value.Constants.LoadType;
        switch (loadBy)
        {
            case LoadType.Testing:
                // Find objects on the scene and set by default params
                gameLoader = new TestGameLoader(_context);
                break;

            case LoadType.Json:
                // Instantiate objects from resources and set by json params
                throw new NotImplementedException();

            default:
                throw new ArgumentOutOfRangeException(nameof(loadBy), loadBy, null);
        }

        return gameLoader;
    }

    public void Initialize()
    {
        var gameLoader = InitializeLoadType();
        gameLoader.Load();
    }
}