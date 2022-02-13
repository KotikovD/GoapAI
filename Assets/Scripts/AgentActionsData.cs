using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/AgentsActionsData")]
public sealed class AgentsActionsData : ScriptableObject
{
    [SerializeField] private List<AgentActionData> _agentsActions;

    
    public List<AgentActionData> AgentsActions
    {
        get
        {
            var result = new List<AgentActionData>();
            _agentsActions.ForEach(x => result.Add(x.Clone()));
            return result;
        }
    }


   
}