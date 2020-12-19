using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public GameObject footstep;

    public void Generate()
    {
        StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameObject generated = Instantiate(footstep, transform.position, transform.rotation);
    }
}
