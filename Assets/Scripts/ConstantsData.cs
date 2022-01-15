using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/ConstantsData")]
public sealed class ConstantsData : ScriptableObject
{
    [Header("Constants")]
    [SerializeField] private float test = 0.15f;
    
    public float Test => test;
}