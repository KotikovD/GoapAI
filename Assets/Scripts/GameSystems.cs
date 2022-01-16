public class GameSystems : Feature
{
    public GameSystems(GameContext contexts)
    {
        // Init
        //Add(new GameEventSystems(contexts));
        Add(new InitializeDataServiceSystem(contexts));
        Add(new InitializeGameLoadingSystem(contexts));
        Add(new InitializeGameUiSystem(contexts));
    
        
        //Reactive
        Add(new ReactiveUpdateWorldInventorySystem(contexts));
        Add(new ReactiveUpdateAgentsInventorySystem(contexts));
        Add(new ReactiveUpdateGameUiSystem(contexts));
        
    }
}