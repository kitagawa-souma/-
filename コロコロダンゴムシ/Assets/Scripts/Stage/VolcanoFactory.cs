using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoFactory : MonoBehaviour
{
    public GameObject[] VolcanoPrefabs;
    private Vector3 create_pos;
    private float CreateTime = 0.0f;
    private float CreateTimer = 0.0f;
    private bool VolcanoSpawn = true;
    private int ran_ene;

    // Start is called before the first frame update
    void Start()
    {
        CreateTime = Random.Range(3.5f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CreateTimer += Time.deltaTime;
        if (CreateTimer >= CreateTime &&
            VolcanoSpawn == true)
        {
            create_pos.x = 12.0f;
            create_pos.y = -3.1f;

            ran_ene = Random.Range(0, 6);
            Instantiate(VolcanoPrefabs[ran_ene],
                        create_pos,
                        Quaternion.identity);
            CreateTimer = 0.0f;
            CreateTime = Random.Range(3.5f, 6.0f);
        }
    }
}
