using System;
using System.Collections.Generic;
using Data;
using UnityEngine;


[CreateAssetMenu(menuName = @"GameData/ConstantsData")]
public sealed class ConstantsData : ScriptableObject
{
    [Header("Constants")]
    [SerializeField] private LoadType _loadType = LoadType.Testing;
    [SerializeField] private float _clickAreaErrorTolerance = 0.5f;
    [SerializeField] private int _agentMaxResourceCapacity = 100;

    [Header("Resource configs")] 
    [SerializeField] private List<ResourceData> _configs;
    
    
    public LoadType LoadType => _loadType;
    public float ClickAreaErrorTolerance => _clickAreaErrorTolerance;
    public int AgentMaxResourceCapacity => _agentMaxResourceCapacity;
    
    
    public ResourceData GetResourceConfig(ResourceType resourceType)
    {
        var foundRes = _configs.Find(x => x.resourceType == resourceType);
        if (foundRes == null)
            throw new Exception(resourceType + " hasn't setuped");

        return foundRes;

    }
}