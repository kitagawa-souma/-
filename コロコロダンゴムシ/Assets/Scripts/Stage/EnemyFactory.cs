using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public float up_lim;
    public float down_lim;

    float CreateTimer = 0.0f;
    float CreateTime = 0.0f;
    float StartTimer = 0.0f;
    int ran_ene;
    bool enemySpawn = true;
    float rand_pos = 0.0f;

    void Start()
    {
        CreateTime = Random.Range(0.5f, 1.0f);
    }
    void Update()
    {
        rand_pos = Random.Range(down_lim, up_lim);
        CreateTimer += Time.deltaTime;
        StartTimer += Time.deltaTime;

        if (CreateTimer >= CreateTime &&
            enemySpawn == true)
        {
            Vector3 create_pos = transform.position;
            create_pos.x = rand_pos;
            create_pos.y = 6.0f;

            //create_pos.y += Random.Range(-2.0f, 2.0f);
            ran_ene = Random.Range(0, 3);
            Instantiate(EnemyPrefabs[ran_ene],
                        create_pos,
                        Quaternion.identity);
            CreateTimer = 0.0f;
            CreateTime = Random.Range(1.5f, 3.0f);
        }
    }
}