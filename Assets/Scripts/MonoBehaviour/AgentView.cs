using System;
using RSG;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public sealed class AgentView : MonoBehaviourExt
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _stoppingTime = 1.5f;
    [SerializeField] private float _runSpeed = 0.5f;
    [SerializeField] private float _walkSpeed = 0.2f;
    [SerializeField] private float _minPathLengthForRun = 6f;
   
    private NavMeshPath _navMeshPath;
    private Sequence _moveTween;
    private Sequence _animationTween;
    private float _currentSpeed;
    private float _wholePathTime;

    private void Awake()
    {
        _navMeshPath = new NavMeshPath();
    }

    public IPromise Move(Vector3 destinationPoint)
     {
         var promise = new Promise();
         var corners = CalculatePathCorners(destinationPoint);
         
         if (corners.Length == 0)
             return Promise.Resolved();
			
         var length = CalculatePathLength(corners);
         SetMoveAcceleration(length);
			
         _moveTween?.Kill();
         var moveTween = DOTween.Sequence();
         moveTween.Append(transform.DOPath(corners, _wholePathTime, PathType.CatmullRom).SetLookAt(0.01f)).OnComplete(promise.Resolve);
         _moveTween = moveTween;
			
         return promise;
     }

     private void SetMoveAcceleration(float pathLenght)
     {
         var speed = pathLenght < _minPathLengthForRun ? _walkSpeed : _runSpeed;
         _wholePathTime = pathLenght / speed;
         _currentSpeed = speed;

         _animationTween?.Kill();
         var animationTween = DOTween.Sequence();
         animationTween.PrependInterval(_wholePathTime - _stoppingTime);
         animationTween.Append(DOTween.To(() => _currentSpeed, x => _currentSpeed = x, 0f, _stoppingTime));
         _animationTween = animationTween;
     }
     
     private Vector3[] CalculatePathCorners(Vector3 destination)
     {
         _navMeshAgent.CalculatePath(destination, _navMeshPath);
         var corners = _navMeshPath.corners;
         return corners;
     }
     
     private float CalculatePathLength(Vector3[] corners)
     {
         var length = 0f;
         for (var i = 0; i < corners.Length; i++)
         {
             if (i + 1 < corners.Length)
                 length += Vector3.Distance(corners[i], corners[i + 1]);
         }

         return length;
     }
 }