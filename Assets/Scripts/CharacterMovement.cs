using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController controller;
    public CameraFollow cameraFollow;

    public float speed;

    private SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraFollow.enabled = false;
        soundController = FindObjectOfType<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow.enabled = true;
        float movement =0;
        float side = 0;
        if (Input.GetKey(KeyCode.A))
        {
            side = -1;
            soundController.PlayWalkEffect();
        }
        if (Input.GetKey(KeyCode.D))
        {
            side = 1;
            soundController.PlayWalkEffect();
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement = 1;
            soundController.PlayWalkEffect();
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = -1;
            soundController.PlayWalkEffect();
        }

        if (movement != 0.0f)
        {
            Quaternion rot = transform.rotation;
            float turnSpeed = speed * 50.0f;
            rot = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y + side * turnSpeed * Time.deltaTime, rot.eulerAngles.z);
            transform.rotation = rot;
        }

        Vector3 right = transform.right;

        controller.Move(new Vector3(right.x*movement,0, right.z * movement) * speed * Time.deltaTime);

    }
}
