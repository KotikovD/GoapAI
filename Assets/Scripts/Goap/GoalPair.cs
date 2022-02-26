using System;
using UnityEngine;


[Serializable]
public sealed class GoalPair
{
    [SerializeField] 
    private GoalName _goalName;
    [SerializeField] 
    private int _count;
    
    
    public GoalPair(GoalName goalName, int count)
    {
        _goalName = goalName;
        _count = count;
    }
    
    public GoalName GoalName => _goalName;

    public int Count => _count;
}