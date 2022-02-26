using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class AgentActionData
{
    [Tooltip("Use unique name")]
    [SerializeField] private string _actionName;
    [SerializeField] private List<GoalPair> _preconditionGoals;
    [SerializeField] private List<GoalPair> _effectsGoals;
    [SerializeField] private int _difficultCost;

    public List<GoalPair> PreconditionGoals => _preconditionGoals;
    public List<GoalPair> EffectsGoals => _effectsGoals;
    public int DifficultCost => _difficultCost;
    public string ActionName => _actionName;
    
}
