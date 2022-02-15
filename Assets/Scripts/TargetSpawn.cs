using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawn : MonoBehaviour
{
    public GameObject m_target;
    private int score = 0; // Score starts at 0
    public Text scoretext;

    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        float spawnPointX = Random.Range(-2.2f, -.75f); // Target spawn point in goal area
        float spawnPointY = Random.Range(0.0f, 10.0f);
        float spawnPointZ = Random.Range(-5.5f, 5.5f); // Target spawn point in goal area
        Vector3 spawnPosition = new Vector3(spawnPointX, 0.1f, spawnPointZ);

        Instantiate(m_target, spawnPosition, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        scoretext.text = "Score: " + score; // Score increment when spawn target is destroyed
    }

}
