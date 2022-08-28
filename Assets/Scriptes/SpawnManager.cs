using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Spawner[] spawns;
    [SerializeField] Enemy[] enemyPrefabs;
    List<Enemy> enemiesGroup = new List<Enemy>();

}
