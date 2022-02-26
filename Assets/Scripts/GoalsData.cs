using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = @"GameData/GoalsData")]
public sealed class GoalsData : ScriptableObject
{
    [SerializeField] private List<WorldGoalData> _goals;


    public List<WorldGoalData> GetGoalsData(WorldState state)
    {
        var goalsData = _goals.FindAll(x => x.State == state);

        if (goalsData.Count == 0)
            throw new Exception("Goals for state = " + state + " doesn't found");
            
        return goalsData;
    }
}