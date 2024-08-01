using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActtackState : IState<Bot>
{
    private Transform randomDestination;
    public void OnEnter(Bot t)
    {

        randomDestination = Stage.Instance.GetRandomDestination();
        if (t.stage != null)
        {
            t.SetDestination(randomDestination.position);
        }
        if (t.transform.position == randomDestination.position)
        {
            t.SetDestination(LevelManager.Instance.FinishPoint());
        }
       
            

    }

    public void OnExcute(Bot t)
    {
        if (t.BrickCount == 0 )
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot t)
    {
       
    }
}
