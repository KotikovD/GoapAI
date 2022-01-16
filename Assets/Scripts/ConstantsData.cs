using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/ConstantsData")]
public sealed class ConstantsData : ScriptableObject
{
    [Header("Constants")]
    [SerializeField] private LoadType _loadType = LoadType.Testing;
    [SerializeField] private float _clickAreaErrorTolerance = 0.5f;
    
    public LoadType LoadType => _loadType;
    public float ClickAreaErrorTolerance => _clickAreaErrorTolerance;
}