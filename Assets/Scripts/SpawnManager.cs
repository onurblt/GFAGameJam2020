using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int enemyCount;
    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        InvokeRepeating("CheckDeads", 1.0f, 5.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count< enemyCount)
        {
            GameObject enemy = GameObject.Instantiate(enemyPrefab);
            float randAngle = Random.Range(0, 360.0f);
            float radius = 10.0f;
            enemy.transform.position = new Vector3(Mathf.Cos(randAngle * Mathf.Deg2Rad)*radius, 17.60f, Mathf.Sin(randAngle * Mathf.Deg2Rad) * radius);
            enemies.Add(enemy);
        }

    }

    void CheckDeads()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i].GetComponent<Enemy>().isDead)
            {
                GameObject.Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
        }
    }
}
