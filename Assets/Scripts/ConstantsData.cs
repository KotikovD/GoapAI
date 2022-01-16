using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/ConstantsData")]
public sealed class ConstantsData : ScriptableObject
{
    [Header("Constants")]
    [SerializeField] private LoadType _loadType = LoadType.Testing;
    
    public LoadType LoadType => _loadType;
}