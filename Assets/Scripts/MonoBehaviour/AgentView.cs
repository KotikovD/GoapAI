using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public sealed class AgentView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    

     public IEnumerator Move(Vector3 destinationPoint)
     {
         _navMeshAgent.SetDestination(destinationPoint);
         yield return new WaitUntil(() => Vector3.Distance(destinationPoint, _navMeshAgent.destination) < 0.1f);
     }
 }