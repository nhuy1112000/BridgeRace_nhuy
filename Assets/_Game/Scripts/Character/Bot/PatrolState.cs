using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    private float targetBricks;
    
    public void OnEnter(Bot t)
    {     
        t.ChangeAnim(Constants.ANIM_RUN);
        targetBricks = Random.Range(2, 6);
       
        SeekTarget(t);
        
    }

    public void OnExcute(Bot t)
    {
        if (t.IsDestionation)
        {
            if (t.BrickCount >= targetBricks)
            {
               
                t.ChangeState(new ActtackState());
            }
            else
            {
                
                SeekTarget(t);
            }
        }
    }

    public void OnExit(Bot t)
    {
        
    }

    public void SeekTarget(Bot t)
    {

        Brick brick = t.stage.SeekBrickOnStage(t.colorType);
        if (brick != null)
        {
            t.SetDestination(brick.transform.position);
           

        }
        else
        {
            Debug.LogWarning("No bricks found for color type: " + t.colorType);
        }
    }
}
