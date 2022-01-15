using System;
using UnityEngine;
using UnityEngine.AI;

public sealed class WorkerView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

//     public IPromise Move(Vector3 destinationPoint)
//     {
//         
//     }
 }