using System.Collections.Generic;
using Entitas;

[Game]
public sealed class AgentActionComponent : IComponent
{
    public AgentType AgentType;
    public Queue<AgentAction> ActionQueue;
    public AgentAction CurrentAction;
    public Goal Goal;
    public GameEntity ActionEntity;
}