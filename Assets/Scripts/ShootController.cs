using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    //Kartopu Objesi
    public GameObject karTopu;

    public float fırlatmaHızı = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody karTopuRigidbody = karTopu.GetComponent<Rigidbody>();
            karTopuRigidbody.useGravity = true;
            karTopuRigidbody.AddForce(transform.forward * fırlatmaHızı, ForceMode.Impulse);
        }
    }
}
