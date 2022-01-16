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
        var agents = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Agent));
        var isAgentFound = FindClosestAgent(clickPoint, agents, out var closestAgent);
			
        if(!isAgentFound)
            return;

        closestAgent.isNeedUpdateGameUi = true;
    }
    
    private bool FindClosestAgent(Vector3 sourceTarget, IGroup<GameEntity> entities, out GameEntity closestEntity)
    {
        var closestDistance = float.MaxValue;
        closestEntity = null;
			
        foreach (var one in entities)
        {
            var currentDistance = Vector3.Distance(sourceTarget, one.agent.AgentView.GetPosition);

            if (currentDistance < _gameContext.dataService.value.Constants.ClickAreaErrorTolerance && currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestEntity = one;
            }
        }

        return closestEntity != null;
    }
}