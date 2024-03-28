using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwEnemies : MonoBehaviour
{
    public List<Transform> hivenPosition;

    public float spawnTime;
    public float currentTime;
    public GameObject enemy;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if(currentTime >= spawnTime)
        {
            currentTime = 0;
            GameObject enemyGameObject = Instantiate(enemy);

            int index = Random.Range(0, 6);
            enemyGameObject.transform.position = hivenPosition[index].position;
        }
    }
}
