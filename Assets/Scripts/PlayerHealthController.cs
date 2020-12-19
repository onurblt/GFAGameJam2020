using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    int health=5;
    public GameObject healthBar;
    bool lockHit;
    
    // Start is called before the first frame update
    void Start()
    {
        lockHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < healthBar.transform.childCount; i++)
        {
            if(i<=health)
            {
                healthBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                healthBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (!lockHit)
            {
                health -= 1;
                StartCoroutine(WaitLock());
            }
        }
    }

    IEnumerator WaitLock()
    {

        lockHit = true;
        yield return new WaitForSeconds(4.0f);
        lockHit = false;
    }
   /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
   */
}
