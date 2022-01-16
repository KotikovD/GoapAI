using UnityEngine;

public sealed class TreeView : CommonView
{
    [SerializeField] private Transform _interactionPoint;

    public Vector3 InteractionPoint => _interactionPoint.position;
}