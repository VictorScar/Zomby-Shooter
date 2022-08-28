using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Spawner[] spawns;
    [SerializeField] Enemy[] enemyPrefabs;
    [SerializeField] List<Enemy> enemiesGroup = new List<Enemy>();
    [SerializeField] List<Enemy> enemiesOnScene = new List<Enemy>();
    [SerializeField] float spawnTime = 10f;
    float count = 0;

    private void Update()
    {
        count += Time.deltaTime;
        if (count >= spawnTime)
        {
            for (int i = 0; i < enemiesGroup.Count; i++)
            {
                enemiesOnScene.Add(Instantiate(enemiesGroup[i], spawns[Random.Range(0, spawns.Length)].transform.position, Quaternion.identity));
            }
            count = 0;
            IncreaseDungerLevel();
        }

    }

    public void IncreaseDungerLevel()
    {
        enemiesGroup.Add(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
    }

    public void KillAllZombieOnScene()
    {
        foreach (Enemy enemy in enemiesOnScene)
        {
            if (enemy != null)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
