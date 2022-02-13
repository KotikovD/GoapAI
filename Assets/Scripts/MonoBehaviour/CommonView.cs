using UnityEngine;

public sealed class CommonView : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;

    public Vector3 InteractionPoint
    {
        get
        {
            if (_interactionPoint == null)
                _interactionPoint = transform;

            return _interactionPoint.position;
        }
    }
    
    public Vector3 GetPosition => transform.position;
}