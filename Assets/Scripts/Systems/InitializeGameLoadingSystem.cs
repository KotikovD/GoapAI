using System;
using Entitas;

public class InitializeGameLoadingSystem : IInitializeSystem
{
    private readonly IGameLoader _gameLoader;
    
    public InitializeGameLoadingSystem(Contexts context, LoadType loadBy)
    {

        switch (loadBy)
        {
            case LoadType.Testing:
                // Find objects on the scene and set by default params
                _gameLoader = new TestGameLoader(context);
                break;
            
            case LoadType.Json:
                // Instantiate objects from resources and set by json params
                throw new NotImplementedException();
            
            default:
                throw new ArgumentOutOfRangeException(nameof(loadBy), loadBy, null);
        }
        
    }

    public void Initialize()
    {
        _gameLoader.Load();
    }
}