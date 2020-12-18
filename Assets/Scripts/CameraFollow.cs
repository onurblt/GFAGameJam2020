using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followHeight = 7f;
    public float followDistence = 6f;
    public float followHeightSpeed = 0.9f;

    private Transform Player;

    private float targetHeight;
    private float currentHeight;
    private float currentRotation;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        targetHeight = Player.position.y + followHeight;

        transform.rotation = Quaternion.Euler(0, 0, 0);
        currentRotation = transform.eulerAngles.y;

        currentHeight =  Mathf.Lerp(transform.position.y, targetHeight, followHeight * Time.deltaTime);

        Quaternion euler = Quaternion.Euler(0f, currentRotation, 0f);

        Vector3 targetPosition = Player.position /* (euler * Vector3.forward)*/-new Vector3(0,0,1) * followDistence;

        targetPosition.y = currentHeight;

        transform.position = targetPosition;
        transform.LookAt(Player);

    }
}
