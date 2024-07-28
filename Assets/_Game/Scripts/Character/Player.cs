using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick joyStick;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private float speed;
    private Vector3 moveVector;

    public void Start()
    {
        ChangeAnim(Constants.ANIM_IDLE);
       
        
            // Tìm đối tượng Joystick trong scene
            joyStick = FindObjectOfType<FloatingJoystick>();

            // Kiểm tra xem joystick có được tìm thấy không
            if (joyStick == null)
            {
                Debug.LogError("Joystick not found in the scene!");
            }
        
    }
     void FixedUpdate()
    {

        rb.drag = -500f;
        moveVector = Vector3.zero;
        moveVector.x = joyStick.Horizontal;
        moveVector.z = joyStick.Vertical;
     
        moveVector.Normalize();
        if (moveVector == Vector3.zero)
        {
            ChangeAnim("idle");
        }

        if (moveVector != Vector3.zero)
        {
            transform.forward = moveVector;
            
            rb.velocity = transform.forward * speed * Time.deltaTime;
           
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.forward * 0.5f, Vector3.down, out hit, 3f, stairLayer))
            {

                if (SameColor(hit))
                {

                    ChangeAnim(Constants.ANIM_RUN);
                    rb.velocity = transform.forward * speed * Time.deltaTime;
                }
                else 
                {
                    if (DifferentColor(hit))
                    {
                        if (HaveBrick(hit))
                        {
                            ChangeAnim(Constants.ANIM_RUN);
                            rb.velocity = transform.forward * speed * Time.deltaTime;
                        }
                        else if (DifferentColorDown())
                        {
                            ChangeAnim(Constants.ANIM_RUN);
                            rb.velocity = transform.forward * speed * Time.deltaTime;
                        }
                        else if (DifferentColorUp())
                        {
                            ChangeAnim(Constants.ANIM_IDLE);
                            rb.velocity = Vector3.zero;
                        }
                  
                    }
                }
            }
            else
            {
                ChangeAnim("run");
                rb.velocity = transform.forward * speed * Time.deltaTime;
            }

        }

        else if (moveVector == Vector3.zero)
        {

            rb.velocity = Vector3.zero;
        }

    }

   
}
