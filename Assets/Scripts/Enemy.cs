using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private Transform player;
    public float speed;
    int health = 5;
    bool hitted;
    bool dead;
    public bool isDead { get { return dead; } }

    public GameObject stun;

    private NavMeshAgent agent;

    private SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hitted = false;
        soundController = FindObjectOfType<SoundController>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
      

        if (hitted)
        {
            soundController.PlaySnowmanRoar();

            Vector3 rotation = stun.transform.localRotation.eulerAngles;
            rotation.y += Time.deltaTime * 100.0f;
            stun.transform.localRotation = Quaternion.Euler(rotation);
            stun.SetActive(true);

            agent.speed = 0.0f;
            return;
        }
        else
        {

            agent.speed = speed;
            stun.SetActive(false);
        }

        if (dead)
        {
            //Debug.Log("Dead");
            agent.isStopped=true;
            Vector3 rotEuler = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(90, rotEuler.y, rotEuler.z);
            return;
        }
        /*
        transform.LookAt(player);
        Vector3 dir = (player.position-transform.position ).normalized;
        dir.y = 0;
        transform.position += dir * Time.deltaTime * speed;
        Vector3 rot=transform.rotation.eulerAngles;
        transform.rotation=Quaternion.Euler(15,rot.y,rot.z);
        */
        agent.SetDestination(player.position);
    }

    /*
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
    */
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Snowball")
        {
            Debug.Log("hit");
            StartCoroutine(Slowdown(1.0f));
            health -= 1;

            if(health<=0)
            {
                dead = true;
                for (int i = 0; i < GetComponentsInChildren<CapsuleCollider>().Length; i++)
                {
                    GetComponentsInChildren<CapsuleCollider>()[i].enabled = false;
                }
               
            }
        }
    }
    
    IEnumerator Slowdown(float waitTime)
    {
        hitted = true;
        yield return new WaitForSeconds(waitTime);
        hitted = false;
    }

    
   
}
