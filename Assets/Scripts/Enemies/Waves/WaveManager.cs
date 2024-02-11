using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Goes through Wave scriptable objects and tells the event bus what enemies it should be saying are spawning
public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;

    private int currentWaveIndex = 0;

    private void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave(waves[currentWaveIndex]));
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemyAmount; i++)
        {
            EventBus<EnemySpawned>.Publish(new EnemySpawned(wave.enemyType, wave.path));
            yield return new WaitForSeconds(wave.spawnInterval);
        }

        currentWaveIndex++;

        if (currentWaveIndex < waves.Length)
        {
            yield return new WaitForSeconds(wave.timeToNextWave);
            StartWave();
        }
    }
}
