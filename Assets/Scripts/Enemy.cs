using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform player;
    public float speed;
    float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0.0f)
        {
            Debug.Log("Dead");
            return;
        }
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);

      
    }


    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("hit");
        if (collision.gameObject.tag=="Snowball")
        {
            Debug.Log("hit");
            health -= 20.0f;
        }
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
