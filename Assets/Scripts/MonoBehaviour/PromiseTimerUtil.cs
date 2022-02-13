using RSG;
using UnityEngine;


public sealed class PromiseTimerUtil : MonoBehaviourExt
{
    private static IPromiseTimer _promiseTimer;

    private static IPromiseTimer PromiseTimer
    {
       get
       {
           if (_promiseTimer == null)
               _promiseTimer = new PromiseTimer();

           return _promiseTimer;
       }
    }
    
    private void FixedUpdate()
    {
        PromiseTimer.Update(Time.deltaTime);
    }
    
    public static IPromise ResolveIn(float waitTimeSec)
    {
        return PromiseTimer.WaitFor(waitTimeSec);
    }
}