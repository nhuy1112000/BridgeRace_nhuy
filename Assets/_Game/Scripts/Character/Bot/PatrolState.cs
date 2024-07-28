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
        Debug.Log("bot" + t.colorType + "so gach can tim la" + targetBricks);
        SeekTarget(t);
        
    }

    public void OnExcute(Bot t)
    {
        if (t.IsDestionation)
        {
            if (t.BrickCount >= targetBricks)
            {
                Debug.Log("bot" + t.colorType + "doi sang state acttack");
                t.ChangeState(new ActtackState());
            }
            else
            {
                Debug.Log("tim them");
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
            Debug.Log("bot" + t.colorType + "set destination" + brick);

        }
        else
        {
            Debug.LogWarning("No bricks found for color type: " + t.colorType);
        }
    }
}
