using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public GameObject footstep;

    Vector3 prevPosition;
    private void Start()
    {
        prevPosition = transform.position;
    }

    public void Generate()
    {
        Vector3 position = transform.position;
        if(Vector3.Distance(position,prevPosition)>1.0f)
        {
            GameObject generated = Instantiate(footstep, transform.position+new Vector3(0,0.00015f,0.0f), transform.rotation);
            Destroy(generated, 5.0f);
            prevPosition = position;
        }
    }
   
}
