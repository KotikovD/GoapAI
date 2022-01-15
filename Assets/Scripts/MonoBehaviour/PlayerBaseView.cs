using UnityEngine;

public sealed class PlayerBaseView : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;

    public Vector3 InteractionPoint => _interactionPoint.position;
}