using UnityEngine;


public abstract class MonoBehaviourExt : MonoBehaviour
{
    private CommonView _commonView;

    public CommonView CommonView
    {
        get
        {
            if (_commonView == null)
            {
                _commonView = gameObject.GetComponent<CommonView>();
                if (_commonView == null)
                    _commonView = gameObject.AddComponent<CommonView>();
            }

            return _commonView;
        }
    }
    
    public Vector3 GetPosition => CommonView.GetPosition;
    public Vector3 InteractionPoint => CommonView.InteractionPoint;
    
}