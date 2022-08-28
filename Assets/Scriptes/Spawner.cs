using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;
    [SerializeField] float spawnTime = 5f;
    float count = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        count += Time.deltaTime;
        if (count >= spawnTime)
        {
            Instantiate(enemies[0], transform.position, Quaternion.identity);
            count = 0;
        }
      
    }

    public void StopSpawn()
    {

    }

}
