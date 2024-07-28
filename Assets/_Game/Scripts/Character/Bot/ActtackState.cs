using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActtackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.SetDestination(LevelManager.Instance.FinishPoint());
        Debug.Log(" di den dich");
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
