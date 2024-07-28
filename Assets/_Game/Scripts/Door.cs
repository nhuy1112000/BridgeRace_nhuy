using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed;
    private bool isMoving = false;
    private Vector3 targetPosition;
    void Start()
    {
        // Đặt vị trí mục tiêu
        targetPosition = new Vector3(transform.position.x, transform.position.y - 5f, transform.position.z);
      
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

           
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
              
                transform.position = targetPosition;
                isMoving = false;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
          
            isMoving = true;
      
    }
}
