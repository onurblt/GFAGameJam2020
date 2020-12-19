﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform player;
    public float speed;
    float health = 100.0f;
    bool hitted;


    public GameObject stun;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {

        controller = gameObject.GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hitted = false;

    }

    // Update is called once per frame
    void Update()
    {
      

        if (hitted)
        {
            stun.SetActive(true);
            return;
        }
        else
        {
            stun.SetActive(false);
        }

        if (health < 0.0f)
        {
            Debug.Log("Dead");
          
            return;
        }

        transform.LookAt(player);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
        Vector3 dir = (player.position-transform.position ).normalized;
        dir.y = 0;
        controller.Move(dir * speed * Time.deltaTime);


    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Snowball")
        {
            Debug.Log("hit");
            StartCoroutine(Slowdown(1.0f));
            health -= 20.0f;
            if (health < 0.0f)
            {
                for (int i = 0; i < GetComponentsInChildren<CapsuleCollider>().Length; i++)
                {
                    GetComponentsInChildren<CapsuleCollider>()[i].enabled = false;
                }

            }
        }
    }
    
    /*
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Snowball")
        {
            Debug.Log("hit");
            StartCoroutine(Slowdown(1.0f));
            health -= 20.0f;

            if(health<0.0f)
            {
                for (int i = 0; i < GetComponentsInChildren<CapsuleCollider>().Length; i++)
                {
                    GetComponentsInChildren<CapsuleCollider>()[i].enabled = false;
                }
               
            }
        }
    }
    */
    IEnumerator Slowdown(float waitTime)
    {
        hitted = true;
        yield return new WaitForSeconds(waitTime);
        hitted = false;
    }
    /*
    private void OnTriggerEnter(Collider collider)
    {

        Debug.Log("hit");
        if (collider.tag == "Snowball")
        {
            Debug.Log("hit");
            health -= 20.0f;
        }
    }
    */
}
