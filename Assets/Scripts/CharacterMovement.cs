using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController controller;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.z = -1;
        }

        controller.Move(dir*speed * Time.deltaTime);
    }
}
