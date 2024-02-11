using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just spawns the enemies.
public class EnemySpawner : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus<EnemySpawned>.OnEvent += SpawnEnemy;
    }

    private void OnDisable()
    {
        EventBus<EnemySpawned>.OnEvent -= SpawnEnemy;
    }

    void SpawnEnemy(EnemySpawned eventData)
    {
        Enemy newEnemy = Instantiate(eventData.EnemyType, transform.position, Quaternion.identity);
        newEnemy.SetPath(eventData.Path);
    }
}
