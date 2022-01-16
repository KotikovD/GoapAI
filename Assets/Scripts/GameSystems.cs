public class GameSystems : Feature
{
    public GameSystems(Contexts globalContext)
    {
        var gameContext = globalContext.game;
        
        // Init
        Add(new GameEventSystems(globalContext));
        Add(new InitializeDataServiceSystem(gameContext));
        Add(new InitializeGameLoadingSystem(gameContext));
        Add(new InitializeGameUiSystem(gameContext));
        Add(new InitializeInputSystem(gameContext));
        Add(new InitializeProcessInputEventSystem(gameContext));
    
        
        //Reactive
        Add(new ReactiveUpdateWorldInventorySystem(gameContext));
        Add(new ReactiveUpdateAgentsInventorySystem(gameContext));
        Add(new ReactiveUpdateGameUiSystem(gameContext));
        
    }
}