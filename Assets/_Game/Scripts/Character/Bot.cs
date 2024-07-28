using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] protected Transform tf;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float slowSpeed;

    private Vector3 destination;
    private bool IsMoving = false;


    IState<Bot> currentState;


    public bool IsDestionation => Vector3.Distance(tf.position, destination + (tf.position.y - destination.y) * Vector3.up) < 0.1f;


    public override void OnInit()
    {
        base.OnInit();
        ChangeAnim(Constants.ANIM_IDLE);
        ChangeState(null);
        agent.speed = normalSpeed;
    }


    public void ChangeState(IState<Bot> state)
    {
        
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }

    }

    void FixedUpdate()
    {
        if (GameManager.Instance.IsState(GameState.Gameplay) && currentState != null)
        {
            Debug.Log("Executing state: " + currentState.GetType().Name);
            currentState.OnExcute(this);

            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.forward * 0.5f, Vector3.down, out hit, 3f, stairLayer))
            {
                if (SameColor(hit))
                {
                    ChangeAnim(Constants.ANIM_RUN);
                    agent.speed = normalSpeed; // Bot di chuyển với tốc độ bình thường
                }
                else
                {
                    if (DifferentColor(hit))
                    {
                        if (HaveBrick(hit))
                        {
                            ChangeAnim(Constants.ANIM_RUN);
                            agent.speed = normalSpeed; // Bot di chuyển với tốc độ bình thường
                        }
                        else if (DifferentColorDown())
                        {
                            ChangeAnim(Constants.ANIM_RUN);
                            agent.speed = normalSpeed; // Bot di chuyển với tốc độ bình thường
                        }
                        else if (DifferentColorUp())
                        {
                            ChangeAnim(Constants.ANIM_IDLE);
                            agent.speed = slowSpeed; // Bot di chuyển đứng yên
                        }
                    }
                }
            }
            else
            {
                agent.speed = normalSpeed; // Bot di chuyển với tốc độ bình thường
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        agent.enabled = true;
        this.destination = destination;
        agent.SetDestination(destination);
        // Debug.Log("destination" + destination);
    }
}
   

