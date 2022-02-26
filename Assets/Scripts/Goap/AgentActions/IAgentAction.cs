using System.Collections.Generic;

public interface IAgentAction
{
    string ActionName { get; }
    List<GoalPair> PreconditionGoals { get; }
    List<GoalPair> EffectsGoalsNames { get; }
    int DifficultCost { get; }
    bool IsRunning { get; set; }
    bool CouldBeAchieved(List<Goal> conditions);
    bool CanPerform(List<GameEntity> gameEntities, GameEntity agent);
    bool CanPerform(List<GameEntity> gameEntities, GameEntity agent, out GameEntity actionEntity);
    void ProducePerform(GameEntity agent);
    bool IsAchievable();
}