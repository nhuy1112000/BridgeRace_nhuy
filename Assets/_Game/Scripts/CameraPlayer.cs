using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
   
    public Transform playerTF;
    public Transform targetTF;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        playerTF = FindObjectOfType<Player>().transform;
    }
    private void LateUpdate()
    {
       
        targetTF.position = Vector3.Lerp(targetTF.position, playerTF.position + offset, Time.deltaTime * 5f);
    }
}

