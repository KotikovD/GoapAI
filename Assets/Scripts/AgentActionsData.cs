using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/AgentsActionsData")]
public sealed class AgentsActionsData : ScriptableObject
{
    [SerializeField] private List<AgentActionData> _agentsActions;

    public List<AgentActionData> AgentsActions => _agentsActions;
    
}