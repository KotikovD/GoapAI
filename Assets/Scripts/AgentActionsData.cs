using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/AgentsActionsData")]
public sealed class AgentsActionsData : ScriptableObject
{
    [SerializeField] private List<AgentActionData> _agentsActions;


    public AgentActionData GetData(string actionName)
    {
        var actionData = _agentsActions.Find(x => String.Equals(x.ActionName, actionName, StringComparison.CurrentCultureIgnoreCase));
        return actionData;
    }
}