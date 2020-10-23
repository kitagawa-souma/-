using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    float CreateTimer = 0.0f;
    float CreateTime = 0.0f;
    float StartTimer = 0.0f;
    int ran_ene;
    bool enemySpawn = true;

    void Start()
    {
        CreateTime = Random.Range(1.5f, 3.0f);
    }
    void Update()
    {
        CreateTimer += Time.deltaTime;
        StartTimer += Time.deltaTime;

        if (CreateTimer >= CreateTime &&
            enemySpawn == true)
        {
            Vector3 create_pos = transform.position;

            //create_pos.y += Random.Range(-2.0f, 2.0f);
            ran_ene = Random.Range(1, 3);
            Instantiate(EnemyPrefabs[ran_ene],
                        transform.position,
                        Quaternion.identity);
            CreateTimer = 0.0f;
            CreateTime = Random.Range(1.5f, 3.0f);
        }
    }
}