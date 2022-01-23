using System;
using UnityEngine;

[Serializable]
public class GoalData
{
    [Tooltip("Use unique name for world state")]
    [SerializeField] 
    private GoalName _goalName;
    
    [Tooltip("When this goal will use")] 
    [SerializeField] 
    private WorldState _state;
    
    [Tooltip("The lower, the more important in current world state")]
    [Range(0, 25)]
    [SerializeField] 
    private int _importance;

    
    public WorldState State => _state;

    public Goal GetGoal()
    {
        return new Goal(_goalName, _state, _importance);
    }
}