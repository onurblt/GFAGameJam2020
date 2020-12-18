using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject snowBall;
    public GameObject player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = player.transform.position + new Vector3(0, 1, 0);
            GameObject newSnowBall = Instantiate(snowBall, newPos, Quaternion.identity);
            Rigidbody newSnowBallRigidbody = newSnowBall.GetComponent<Rigidbody>();
            newSnowBallRigidbody.useGravity = true;
            newSnowBallRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
            Destroy(newSnowBall, 1);
        }
    }
}
