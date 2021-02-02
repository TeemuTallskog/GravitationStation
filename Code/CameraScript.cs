using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform playerTransform;
    [SerializeField] private float cameraBoundryLeft; //Max left position of camera
    [SerializeField] private float cameraBoundryRight; // Max right position of camera
    [SerializeField] private float cameraBoundryTop;
    [SerializeField] private float cameraBoundryBottom;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public float PosReturnLeft()
    {
        return cameraBoundryLeft;
    }

    public float PosReturnRight()
    {
        return cameraBoundryRight;
    }
  
    void LateUpdate()
    {
        //current camera pos
        Vector3 cameraPos = transform.position;
        //camera pos = players x cord
        cameraPos.x = Mathf.Clamp(playerTransform.position.x, cameraBoundryLeft, cameraBoundryRight); //cameras x position will be clamped by camera boundries so it won't follow the player outside the level.
        cameraPos.y = Mathf.Clamp(playerTransform.position.y, cameraBoundryBottom, cameraBoundryTop); //cameras y position will be clamped by camera boundries so it won't follow the player outside the level.
        //cameras temp pos = cameras current pos
        transform.position = cameraPos;
    }
}
