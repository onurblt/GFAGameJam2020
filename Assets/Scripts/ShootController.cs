using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject snowBall;
    public GameObject player;

    public float speed;

    private SoundController soundController;

    bool throwing;
    public bool isThrowing { get { return throwing; } }

    // Start is called before the first frame update
    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !throwing)
        {
            //transform.position + new Vector3(0, 1.0f, 0);
            //player.transform.position + new Vector3(0, 0.5f, 0);
            Vector3 newPos = transform.position + new Vector3(0, 0.5f, 0);
            GameObject newSnowBall = Instantiate(snowBall, newPos, Quaternion.identity);
            Rigidbody newSnowBallRigidbody = newSnowBall.GetComponent<Rigidbody>();
            newSnowBallRigidbody.useGravity = true;
            newSnowBallRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
            Destroy(newSnowBall, 1);

            soundController.PlaySnowballEffect();
            StartCoroutine(ThrowEnum());
        }
    }

    IEnumerator ThrowEnum()
    {
        throwing = true;
        yield return new WaitForSeconds(0.5f);
        throwing = false;
    }
   
}
