using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public Enemy enemyType;
    public int enemyAmount;
    public float spawnInterval;
    public GameObject path;
    public float timeToNextWave;
}
