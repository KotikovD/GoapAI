using Entitas;


public sealed class InitializeProcessInputEventSystem : IInitializeSystem, IInputClickListener
{
   private readonly GameContext _gameContext;


   public InitializeProcessInputEventSystem(GameContext gameContext)
   {
       _gameContext = gameContext;
   }
   
   public void Initialize()
    {
        _gameContext.inputEntity.AddInputClickListener(this);
    }

    public void OnInputClick(GameEntity entity, GameEntity clickedGameEntity)
    {
        clickedGameEntity.isNeedUpdateGameUi = true;
    }

}