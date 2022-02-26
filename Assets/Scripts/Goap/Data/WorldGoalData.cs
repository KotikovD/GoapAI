using System;
using UnityEngine;

[Serializable]
public class WorldGoalData
{
    [Tooltip("Use unique name for world state")]
    [SerializeField] 
    private GoalName _goalName;
    
    [SerializeField] 
    private AgentType _agentType = AgentType.Any;
    
    [Tooltip("When this goal will use")] 
    [SerializeField] 
    private WorldState _state;
    
    [Tooltip("The lower, the more important in current world state")]
    [Range(0, 25)]
    [SerializeField] 
    private int _importance;

    private int _count;
    
    public WorldState State => _state;
    public AgentType AgentType => _agentType;

    public Goal GetGoal()
    {
        return new Goal(_goalName, _state, _importance, _agentType, _count);
    }
}