using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    int health=5;
    public GameObject healthBar;
    public GameObject healthRedPanel;
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
                StartCoroutine(RedScreenBlink());
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

    IEnumerator RedScreenBlink()
    {
        healthRedPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        healthRedPanel.SetActive(false);
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
