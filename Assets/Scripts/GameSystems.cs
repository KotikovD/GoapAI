public class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        // Init
        //Add(new GameEventSystems(contexts));
        Add(new InitializeDataServiceSystem(contexts));
        Add(new InitializeGameLoadingSystem(contexts, LoadType.Testing));
    }
}