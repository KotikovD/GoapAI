using UnityEngine;



public sealed class PlayerBaseView : MonoBehaviourExt
{
    [SerializeField] private Transform _interactionPoint;

    public Vector3 InteractionPoint => _interactionPoint.position;
}