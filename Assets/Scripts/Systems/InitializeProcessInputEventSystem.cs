using Entitas;
using UnityEngine;

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

    public void OnInputClick(GameEntity entity, Vector3 clickPoint)
    {
        var agents = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.CommonView));
        var isObjectFound = FindClosestObject(clickPoint, agents, out var closestObject);
			
        if(!isObjectFound)
            return;

        closestObject.isNeedUpdateGameUi = true;
    }
    
    private bool FindClosestObject(Vector3 sourceTarget, IGroup<GameEntity> entities, out GameEntity closestEntity)
    {
        var closestDistance = float.MaxValue;
        closestEntity = null;
			
        foreach (var one in entities)
        {
            var currentDistance = Vector3.Distance(sourceTarget, one.commonView.CommonView.GetPosition);

            if (currentDistance < _gameContext.dataService.value.Constants.ClickAreaErrorTolerance && currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestEntity = one;
            }
        }

        return closestEntity != null;
    }
}