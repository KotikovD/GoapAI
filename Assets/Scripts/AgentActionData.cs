using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class AgentActionData
{
    [Tooltip("Use unique name")]
    [SerializeField] private string _actionName;
    [SerializeField] private List<GoalName> _preconditionGoals;
    [SerializeField] private List<GoalName> _effectsGoals;
    [SerializeField] private int _difficultCost;

    public List<GoalName> PreconditionGoals => _preconditionGoals;

    public List<GoalName> EffectsGoals => _effectsGoals;

    public int DifficultCost => _difficultCost;
    public string ActionName => _actionName;


    public AgentActionData Clone()
    {
        var reuslt = new AgentActionData()
        {
            _actionName = _actionName,
            _preconditionGoals = new List<GoalName>(_preconditionGoals),
            _effectsGoals = new List<GoalName>(_effectsGoals),
            _difficultCost = _difficultCost
        };

        return reuslt;
    }
}
